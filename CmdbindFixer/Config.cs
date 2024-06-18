namespace CmdbindFixer
{
#if EXILED
    public sealed class Config : Exiled.API.Interfaces.IConfig
#else
    public sealed class Config
#endif
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
    }
}
