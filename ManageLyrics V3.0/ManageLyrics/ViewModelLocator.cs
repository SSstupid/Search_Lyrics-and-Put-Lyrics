namespace ManageLyrics;

public class ViewModelLocator
{
    #region Public Properties

    /// <summary>
    /// Singleton instance of the locator
    /// </summary>
    public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

    #endregion

    /// <summary>
    /// The application view model
    /// </summary>
    public static ThemesViewModel ThemesViewModel => IoC.Get<ThemesViewModel>();
}