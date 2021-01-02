using SyncExample.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncExample.Domain
{
    internal sealed class DataBase
    {
        

        internal ObservableCollection<DTO> GetData(System.Threading.CancellationToken token)
        {
            //var dto = o as DTO;
            //if(dto == null)
            //{
            //    return;
            //}

            var result = new ObservableCollection<DTO>();
            for (int i = 0; i < 5; i++)
            {
                // 引数のキャンセルトークンを随時監視する
                // この例外は debug ではプログラムが一時停止するが，exe で実行すると出ないので安心してほしい 
                token.ThrowIfCancellationRequested();

                System.Threading.Thread.Sleep(1000);
                result.Add(new DTO(i.ToString(), "Name" + i));
            }
            return result;

        }

        internal void Cancel()
        {

        }

    }
}
