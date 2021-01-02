using SyncExample.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using SyncExample.ViewModels;

namespace SyncExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<Sync, SyncViewModel>();
            containerRegistry.RegisterDialog<Thread, ThreadViewModel>();
            containerRegistry.RegisterDialog<ThreadPool, ThreadPoolViewModel>();
            containerRegistry.RegisterDialog<Task, TaskViewModel>();
            containerRegistry.RegisterDialog<AsyncAwait,AsyncAwaitViewModel>();
            containerRegistry.RegisterDialog<AsyncAwaitCancel,AsyncAwaitCancelViewModel>();
        }
    }
}
