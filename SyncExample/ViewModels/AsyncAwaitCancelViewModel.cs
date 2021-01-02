using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SyncExample.Domain;
using SyncExample.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SyncExample.ViewModels
{
    public class AsyncAwaitCancelViewModel : BindableBase, IDialogAware
    {
        // キャンセルトークンの設定
        System.Threading.CancellationTokenSource _token;

        private DataBase _dataBase = new DataBase();
        private string _title = "Async Await Cancel";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public AsyncAwaitCancelViewModel()
        {
            Button1Click = new DelegateCommand(Button1ClickExe);
            CancelButtonClick = new DelegateCommand(CancelButtonClickExe);
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
        private async void Button1ClickExe()
        {
            // 普通に同期的な記述で OK
            // メソッドに async 
            // 処理を Task で，await させる

            try
            {
                // キャンセルトークンの設定
                // 非同期処理開始時に new する
                _token = new System.Threading.CancellationTokenSource();

                // 非同期処理メソッドにキャンセルトークン .Token を渡し，監視するようにする
                // Task にも渡せるので，渡しておく
                DataGridSource = await Task.Run(() => _dataBase.GetData(_token.Token), _token.Token);
                MessageBox.Show("完了");
            }
            catch (OperationCanceledException o)
            {
                MessageBox.Show("キャンセルされました");
            }
            finally
            {
                _token.Dispose();
                _token = null;
            }

        }
        // 非同期処理のキャンセル
        public DelegateCommand CancelButtonClick { get; }
        private void CancelButtonClickExe()
        {
            _token?.Cancel();
        }

        // DataBase の処理は別クラスにあるのが普通なので，そちらに移す
        //private ObservableCollection<DTO> GetData()
        //{
        //    //var dto = o as DTO;
        //    //if(dto == null)
        //    //{
        //    //    return;
        //    //}

        //    var result = new ObservableCollection<DTO>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        System.Threading.Thread.Sleep(1000);
        //        result.Add(new DTO(i.ToString(), "Name" + i));
        //    }
        //    return result;

        //}

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
