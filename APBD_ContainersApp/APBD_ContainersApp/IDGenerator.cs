namespace APBD_ContainersApp;

public class IdGenerator
{
    private static int _id=1;

    public static int GetNewId()
    {
        return _id++;
    }
}
