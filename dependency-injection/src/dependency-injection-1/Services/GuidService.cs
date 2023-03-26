public class GuidService
{
    private Guid _guid;
    public GuidService()
    {
        _guid = System.Guid.NewGuid();
    }

    public Guid GetGuid()
    {
        return _guid;
    }
}
