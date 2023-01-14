public sealed class Singleton
{
    private static readonly Lazy<Singleton> Lazy = new(() => new Singleton());
    private Singleton() { }
    public static Singleton GetInstance() => Lazy.Value;
}