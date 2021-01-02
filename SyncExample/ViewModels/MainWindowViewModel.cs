using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SyncExample.Entities;
using SyncExample.Views;
using System;
using System.Collections.ObjectModel;

namespace SyncExample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IDialogService _dialogService;

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;

            SyncExampleButton = new DelegateCommand(SyncExampleButtonExe);
            AsyncExampleButton = new DelegateCommand(AsyncExampleButtonExe);
            ThreadPoolButton = new DelegateCommand(ThreadPoolButtonExe);
            TaskButton = new DelegateCommand(TaskButtonExe);
            AsyncAwaitButton = new DelegateCommand(AsyncAwaitButtonExe);
            AsyncAwaitCancelButton = new DelegateCommand(AsyncAwaitCancelButtonExe); ;
        }


        public DelegateCommand SyncExampleButton { get; }
        private void SyncExampleButtonExe()
        {
            _dialogService.ShowDialog(nameof(Sync), null, null);
        }
        public DelegateCommand AsyncExampleButton { get; }
        private void AsyncExampleButtonExe()
        {
            _dialogService.ShowDialog(nameof(Thread), null, null);
        }
        public DelegateCommand ThreadPoolButton { get; }
        private void ThreadPoolButtonExe()
        {
            _dialogService.ShowDialog(nameof(ThreadPool), null, null);
        }
        public DelegateCommand TaskButton { get; }
        private void TaskButtonExe()
        {
            _dialogService.ShowDialog(nameof(Task), null, null);
        }
        public DelegateCommand AsyncAwaitButton { get; }
        private void AsyncAwaitButtonExe()
        {
            _dialogService.ShowDialog(nameof(AsyncAwait), null, null);
        }
        public DelegateCommand AsyncAwaitCancelButton { get; }
        private void AsyncAwaitCancelButtonExe()
        {
            _dialogService.ShowDialog(nameof(AsyncAwaitCancel), null, null);
        }

    }
}
