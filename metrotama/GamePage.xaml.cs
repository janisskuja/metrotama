using System.Linq;
using TCD.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonoGame.Framework;


namespace metrotama
{
    /// <summary>
    /// The root page used to display the game.
    /// </summary>
    public sealed partial class GamePage : LayoutAwarePage
    {
        readonly Game1 _game;

        public GamePage(string launchArguments)
        {
            this.InitializeComponent();

            // Create the game.
            _game = XamlGame<Game1>.Create(launchArguments, Window.Current.CoreWindow, DxSwapChainPanel);
        }

        private void AppBar_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the app bar's root Panel.
            var root = ((AppBar)sender).Content as Panel;
            if (root == null) return;
            // Get the Panels that hold the controls.
            foreach (var child in root.Children.Cast<Panel>().SelectMany(panel => panel.Children))
            {
                base.StartLayoutUpdates(child, new RoutedEventArgs());
            }
        }

        private void AppBar_Unloaded(object sender, RoutedEventArgs e)
        {
            // Get the app bar's root Panel.
            var root = ((AppBar)sender).Content as Panel;
            if (root == null) return;
            // Get the Panels that hold the controls.
            foreach (var child in root.Children.Cast<Panel>().SelectMany(panel => panel.Children))
            {
                base.StopLayoutUpdates(child, new RoutedEventArgs());
            }
        }
    }
}
