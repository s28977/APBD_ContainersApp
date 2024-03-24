namespace APBD_ContainersApp;

public class OverfillException : ArgumentException
{
    public OverfillException() : base() {}
    public OverfillException(string msg) : base(msg) {}
}