﻿using metrotama.Domain.Repository;
using System.IO;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace metrotama
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static string DBPath = string.Empty;
        public static string CurrentUserName = string.Empty;
        private DatabaseInitRepository InitRepo = new DatabaseInitRepository();
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            var gamePage = Window.Current.Content as GamePage;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (gamePage == null)
            {
                // Create a main GamePage
                gamePage = new GamePage(args.Arguments);

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }
                // TODO: Get user name from windows live account
                CurrentUserName = "TestUser";
                // Get a reference to the SQLite database 
                DBPath = Path.Combine(
                    Windows.Storage.ApplicationData.Current.LocalFolder.Path, "metrotama.db");
                // Initialize the database if necessary 
                InitRepo.InitializeTables();
                InitRepo.InitializeData();
                // Place the GamePage in the current Window
                Window.Current.Content = gamePage;
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity

            deferral.Complete();
        }
    }
}
