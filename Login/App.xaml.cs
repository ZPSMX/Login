#if WINDOWS
using Microsoft.UI.Windowing;
using Windows.Graphics;
using Microsoft.Maui.Platform;
#endif

namespace Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            // Establecer las dimensiones de la ventana
            window.Width = 800;
            window.Height = 600;
            window.MaximumWidth = 800;
            window.MaximumHeight = 600;
            window.MinimumWidth = 800;
            window.MinimumHeight = 600;
            window.Title = "Login";

#if WINDOWS
            // Centrar la ventana solo en Windows
            window.Created += (s, e) =>
            {
                var nativeWindow = window.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
                if (nativeWindow != null)
                {
                    var appWindow = nativeWindow.GetAppWindow();
                    var displayArea = DisplayArea.GetFromWindowId(appWindow.Id, DisplayAreaFallback.Primary);
                    var screenWidth = displayArea.WorkArea.Width;
                    var screenHeight = displayArea.WorkArea.Height;

                    var windowWidth = appWindow.Size.Width;
                    var windowHeight = appWindow.Size.Height;

                    // Calcular la posición para centrar la ventana
                    int x = (int)((screenWidth - windowWidth) / 2);
                    int y = (int)((screenHeight - windowHeight) / 2);

                    appWindow.Move(new Windows.Graphics.PointInt32(x, y));
                }
            };
#endif

            return window;
        }
    }
}
