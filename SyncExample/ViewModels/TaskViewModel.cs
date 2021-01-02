using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SyncExample.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SyncExample.ViewModels
{
    public class TaskViewModel : BindableBase, IDialogAware
    {
        private string _title = "TTask";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public TaskViewModel()
        {
            Button1Click = new DelegateCommand(Button1ClickExe);
        }

        private ObservableCollection<DTO> _dataGridSource = new ObservableCollection<DTO>();

        public event Action<IDialogResult> RequestClose;

        public ObservableCollection<DTO> DataGridSource
        {
            get { return _dataGridSource; }
            set { SetProperty(ref _dataGridSource, value); }
        }

        // 処理の実装
        public DelegateCommand Button1Click { get; }
        private void Button1ClickExe()
        {
            var context = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Run(() => GetData()).ContinueWith(x =>
            {
                DataGridSource = x.Result;
                MessageBox.Show("完了");
            }, context);
        }

        private ObservableCollection<DTO> GetData()
        {
            //var dto = o as DTO;
            //if(dto == null)
            //{
            //    return;
            //}

            var result = new ObservableCollection<DTO>();
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }
            return result;

        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
