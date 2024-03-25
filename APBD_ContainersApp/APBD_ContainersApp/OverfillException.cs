namespace APBD_ContainersApp;

public class OverfillException : ArgumentException
{
    public OverfillException(string msg) : base(msg) {}
}