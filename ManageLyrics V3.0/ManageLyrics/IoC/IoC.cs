using Ninject;
namespace ManageLyrics;

public static class IoC
{
    #region Public Properties

    /// <summary>
    /// The kernel for our IoC container
    /// </summary>
    public static IKernel Kernel { get; private set; } = new StandardKernel();

    #endregion

    #region Constructor

    /// <summary>
    /// Sets up the IoC container, binds all informaiton required and is ready for use
    /// NOTE: Must be called as soon as your application starts up to ensure all
    ///       services can be found
    /// </summary>
    public static void Setup()
    {
        // Bind all required view models
        BindViewModels();
    }

    /// <summary>
    /// Binds all singleton view models
    /// </summary>
    private static void BindViewModels()
    {
        // Bind to a single instance of ThemesViewModel view model
        Kernel.Bind<ThemesViewModel>().ToConstant(new ThemesViewModel());

        // Bind to a single instance of ALSongLyric Logic
        Kernel.Bind<ALSongLyric>().ToConstant(new ALSongLyric());

        // Bind to a single instance of MessageBoxService view model
        Kernel.Bind<MessageBoxService>().ToConstant(new MessageBoxService());

        // Bind to a single instance of open ContactService
        Kernel.Bind<ContactService>().ToConstant(new ContactService());

        // Bind to a single instance of open HelpService
        Kernel.Bind<HelpService>().ToConstant(new HelpService());

    }

    #endregion

    /// <summary>
    /// Get's service for the IoC, of the specified type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Get<T>()
    {
        return Kernel.Get<T>();
    }
}