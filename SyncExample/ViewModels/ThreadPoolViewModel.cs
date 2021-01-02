using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SyncExample.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SyncExample.ViewModels
{
    public class ThreadPoolViewModel : BindableBase, IDialogAware
    {
        private string _title = "Thread Pool";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ThreadPoolViewModel()
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
            System.Threading.ThreadPool.QueueUserWorkItem(GetData);
        }

        private void GetData(object o)
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

            DataGridSource = result;
            MessageBox.Show("完了");
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
