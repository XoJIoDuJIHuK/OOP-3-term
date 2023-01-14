public sealed class Tutor
{
    private Random random = new();
    public List<Test> testList;
    private static readonly Lazy<Tutor> Lazy = new(() => new Tutor());
    private Tutor() { testList = new(); }
    public static Tutor GetInstance() => Lazy.Value;
}