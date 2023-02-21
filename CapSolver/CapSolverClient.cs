using System.Text;
using CapSolver.Models.Responses;
using CapSolver.Tasks;
using CapSolver.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CapSolver;

public class CapSolverClient
{
    private readonly static string Balance = "/getBalance";
    private readonly static string CreateTask_ = "/createTask";
    private readonly static string GetTaskResult_ = "/getTaskResult";
    private readonly static string CreateTaskKasada = "/kasada/invoke";
    private readonly static string CreateTaskAntiAkamai = "/akamaibmp/invoke";
    private HttpClient _httpClient;
    private readonly static Uri _hostUrl = new Uri("https://api.capsolver.com");
    private readonly static Uri _betaHostUrl = new Uri("https://api-beta.capsolver.com");
    private readonly string _clientKey;
    private Proxy? _proxy = null;

    public CapSolverClient(string clientKey, bool beta = false)
    {
        _clientKey = clientKey;
        _httpClient = new HttpClient { BaseAddress = beta ? _betaHostUrl : _hostUrl };
    }

    public async Task<float> GetBalance()
    {
        VanillaTask data = new VanillaTask(_clientKey);
        HttpResponseMessage response = await MakeRequest(Balance, JsonConvert.SerializeObject(data));
        var r = JsonConvert.DeserializeObject<GetBalance>(await response.Content.ReadAsStringAsync());
        r = await CheckResponse<GetBalance>(response);
        return r!.Balance;
    }

    public async Task<List<string?>> GetPackages()
    {
        VanillaTask data = new VanillaTask(_clientKey);
        HttpResponseMessage response = await MakeRequest(Balance, JsonConvert.SerializeObject(data));
        var r = JsonConvert.DeserializeObject<GetBalance>(await response.Content.ReadAsStringAsync());
        r = await CheckResponse<GetBalance>(response);
        return r!.Packages;
    }

    public async Task<TaskResponse<T>> GetTaskResult<T>(string taskId) where T : ITaskResponse
    {
        VanillaTask vt = new VanillaTask(_clientKey);
        vt.TaskId = taskId;
        HttpResponseMessage response = await MakeRequest(GetTaskResult_, JsonConvert.SerializeObject(vt));
        var r = JsonConvert.DeserializeObject<TaskResponse<T>>(await response.Content.ReadAsStringAsync());
        r = await CheckResponse<TaskResponse<T>>(response);
        return r;
    }

    public async Task<T> JoinTaskResult<T>(string taskId, int maximumTime = 120) where T : ITaskResponse
    {
        VanillaTask vt = new VanillaTask(_clientKey);
        vt.TaskId = taskId;
        for (int i = 0; i < maximumTime; i++)
        {
            HttpResponseMessage response = await MakeRequest(GetTaskResult_, JsonConvert.SerializeObject(vt));
            var r = JsonConvert.DeserializeObject<TaskResponse<T>>(await response.Content.ReadAsStringAsync());
            r = await CheckResponse<TaskResponse<T>>(response);
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
        VanillaTask t = new VanillaTask(_clientKey);
        t.UseAppId();
        string data;
        if (task is IProxyTask && IsProxyActive())
        {
            JObject vt = JObject.FromObject(t);
            JObject t_ = JObject.FromObject(task);
            JObject p = JObject.FromObject(_proxy!);
            p.Merge(t_);
            vt["task"] = p;
            data = vt.ToString();
        }
        else if (task is IProxyTask && !IsProxyActive())
        {
            JObject vt = JObject.FromObject(t);
            JObject t_ = JObject.FromObject(task);
            t_["type"] += "ProxyLess";
            vt["task"] = t_;
            data = vt.ToString();
        }
        else
        {
            JObject vt = JObject.FromObject(t);
            JObject t_ = JObject.FromObject(task);
            vt["task"] = t_;
            data = vt.ToString();
        }
        string method = CreateTask_;
        if (task is AntiAkamaiBMPTask)
        {
            method = CreateTaskAntiAkamai;
        }
        else if (task is AntiKasadaTask)
        {
            method = CreateTaskKasada;
        }
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
