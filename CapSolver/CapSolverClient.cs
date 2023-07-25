using System.Text;
using CapSolver.Models.Responses;
using CapSolver.Tasks;
using CapSolver.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CapSolver;

public class CapSolverClient
{
    private readonly HttpClient _httpClient;
    private static readonly Uri HostUrl = new Uri("https://api.capsolver.com");
    private static readonly Uri BetaHostUrl = new Uri("https://api-beta.capsolver.com");
    private readonly string _clientKey;
    private Proxy? _proxy;

    public CapSolverClient(string clientKey, bool beta = false)
    {
        _clientKey = clientKey;
        _httpClient = new HttpClient { BaseAddress = beta ? BetaHostUrl : HostUrl };
    }

    public async Task<float> GetBalance()
    {
        var data = new VanillaTask(_clientKey);
        var response = await MakeRequest(Endpoints.Balance, JsonConvert.SerializeObject(data));
        var r = await CheckResponse<GetBalance>(response);
        return r.Balance;
    }

    public async Task<List<string?>> GetPackages()
    {
        var data = new VanillaTask(_clientKey);
        var response = await MakeRequest(Endpoints.Balance, JsonConvert.SerializeObject(data));
        var r = await CheckResponse<GetBalance>(response);
        return r.Packages;
    }

    public async Task<TaskResponse<T>> GetTaskResult<T>(string taskId) where T : ITaskResponse
    {
        var vt = new VanillaTask(_clientKey)
        {
            TaskId = taskId
        };
        var response = await MakeRequest(Endpoints.GetTaskResult, JsonConvert.SerializeObject(vt));
        var r = await CheckResponse<TaskResponse<T>>(response);
        return r;
    }

    public async Task<T> JoinTaskResult<T>(string taskId, int maximumTime = 120) where T : ITaskResponse
    {
        var vt = new VanillaTask(_clientKey)
        {
            TaskId = taskId
        };
        for (var i = 0; i < maximumTime; i++)
        {
            var response = await MakeRequest(Endpoints.GetTaskResult, JsonConvert.SerializeObject(vt));
            var r = await CheckResponse<TaskResponse<T>>(response);
            if (IsReady(r) && r.Solution != null)
            {
                return r.Solution;
            }
            await Task.Delay(1000);
        }
        throw new CapSolverException(-1, "MAXIMUM_TIME_EXCEED", "Maximum time is exceed.");
    }

    public async Task<string> CreateTask(ITask task)
    {
        var t = new VanillaTask(_clientKey);
        t.UseAppId();
        string data;
        switch (task)
        {
            case IProxyTask when IsProxyActive():
            {
                var vt = JObject.FromObject(t);
                var to = JObject.FromObject(task);
                var p = JObject.FromObject(_proxy!);
                p.Merge(to);
                vt["task"] = p;
                data = vt.ToString();
                break;
            }
            case IProxyTask when !IsProxyActive():
            {
                var vt = JObject.FromObject(t);
                var to = JObject.FromObject(task);
                to["type"] += "ProxyLess";
                vt["task"] = to;
                data = vt.ToString();
                break;
            }
            default:
            {
                var vt = JObject.FromObject(t);
                var to = JObject.FromObject(task);
                vt["task"] = to;
                data = vt.ToString();
                break;
            }
        }
        var method = task switch
        {
            AntiAkamaiBMPTask => Endpoints.CreateTaskAntiAkamai,
            AntiKasadaTask => Endpoints.CreateTaskKasada,
            _ => Endpoints.CreateTask
        };
        if (task is HCaptchaTurboTask && IsProxyActive() == false)
            throw new CapSolverException(13, "PROXY_NEEDED", "HCaptchaTurboTask requires your own proxies.");
        var r = await CheckResponse<CreateTaskResponse>(await MakeRequest(method, data));
        return r.TaskId;
    }

    public bool IsProxyActive() => _proxy != null;

    public void SetProxy(Proxy proxy) => _proxy = proxy;

    public void DisableProxy() => _proxy = null;

    private bool IsReady<T>(TaskResponse<T> response) where T : ITaskResponse => response.Status == "ready";

    private async Task<HttpResponseMessage> MakeRequest(string endpoint, string data)
    {
        var dataString = new StringContent(data, Encoding.UTF8, "application/json");
        HttpResponseMessage response;
        try
        {
            response = await _httpClient.PostAsync(endpoint, dataString);
        }
        catch (Exception)
        {
            throw new CapSolverException(-1, "UNABLE_TO_MAKE_REQUEST", "Something is happened while making request");
        }
        var r = JsonConvert.DeserializeObject<ErrorResponse>(await response.Content.ReadAsStringAsync());
        CheckResponse(r);
        return response;
    }

    private void CheckResponse(ErrorResponse? response)
    {
        if (response == null)
        {
            throw new CapSolverException(-1, "NO_RESPONSE", "The response is empty.");
        }
        else if (response.ErrorId != 0)
        {
            throw new CapSolverException(response.ErrorId, response.ErrorCode!, response.ErrorDescription!);
        }
    }

    private async Task<T> CheckResponse<T>(HttpResponseMessage response) where T : ErrorResponse
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
        }
        catch(Exception)
        {
            throw new CapSolverException(-2, "NOT_VALID_RESPONSE", "The response is not valid.");
        }
    }
}
