namespace Design.Patterns.Creational.SingletonSample
{
    public sealed class DotnetSingleton
    {
        // ReSharper disable once InconsistentNaming
        private static readonly DotnetSingleton _instance = new DotnetSingleton();

        private DotnetSingleton()
        {
        }

        public static DotnetSingleton Instance
        {
            get { return _instance; }
        }
    }
}