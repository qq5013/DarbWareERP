using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 邏輯Bll.訊息相關;

namespace ViewModel.訊息相關
{
    public class 訊息ViewModel
    {
        int 訊息代碼 { get; set; }
        string 中文描述 { get; set; }
        string 英文描述 { get; set; }
        MessageBoxButton 訊息選項 { get; set; }
        MessageBoxImage 訊息圖示 { get; set; }
        public static void 訊息顯示(int 錯誤代碼)
        {
            string 錯誤訊息 = "";
            string 抬頭 = "";
            string 標題 = "";

            switch (語言設定Bll.語言)
            {
                case 語言設定Bll.語言版本enum.中文:
                    錯誤訊息 = _訊息表[錯誤代碼].中文描述;
                    抬頭 = "代碼: ";
                    標題 = "提示訊息";
                    break;
                case 語言設定Bll.語言版本enum.英文:
                    錯誤訊息 = _訊息表[錯誤代碼].英文描述;
                    抬頭 = "code: ";
                    標題 = "Message";
                    break;
                default:
                    break;
            }
            MessageBox.Show(抬頭 + 錯誤代碼 + " \r" + 錯誤訊息, 標題, _訊息表[錯誤代碼].訊息選項, _訊息表[錯誤代碼].訊息圖示);
        }
        private static List<訊息ViewModel> _訊息表 = new List<訊息ViewModel>
        {
            new 訊息ViewModel {訊息代碼=0,中文描述="儲存完畢" , 英文描述="Save Complete",訊息選項= MessageBoxButton.OK,訊息圖示=MessageBoxImage.Information}
        };
    }
}
