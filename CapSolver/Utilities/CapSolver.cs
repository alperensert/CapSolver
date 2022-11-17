namespace CapSolver.Utilities;

[System.Serializable]
public class CapSolverException : System.Exception
{
    public int ErrorId { get; set; }

    public string ErrorCode { get; set; }

    public string ErrorDescription { get; set; }

    public CapSolverException(int errorId, string errorCode, string errorDescription) : base(string.Format("[{0}]: {1}", errorCode, errorDescription))
    {
        ErrorId = errorId;
        ErrorCode = errorCode;
        ErrorDescription = errorDescription;
    }
}