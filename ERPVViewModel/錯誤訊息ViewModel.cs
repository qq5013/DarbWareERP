using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 邏輯Bll.訊息相關;

namespace ViewModel
{
    public class 錯誤訊息ViewModel
    {
        int 錯誤代碼 { get; set; }
        string 中文描述 { get; set; }
        string 英文描述 { get; set; }
        MessageBoxButton 訊息選項 { get; set; }
        MessageBoxImage 訊息圖示 { get; set; }
        public static void 錯誤訊息顯示(int 錯誤代碼)
        {
            string 錯誤訊息 = "";
            string 抬頭 = "";
            string 標題 = "";

            switch (語言設定Bll.語言)
            {
                case 語言設定Bll.語言版本enum.中文:
                    錯誤訊息 = _錯誤訊息表[錯誤代碼].中文描述;
                    抬頭 = "錯誤代碼: ";
                    標題 = "錯誤訊息";
                    break;
                case 語言設定Bll.語言版本enum.英文:
                    錯誤訊息 = _錯誤訊息表[錯誤代碼].英文描述;
                    抬頭 = "Error code: ";
                    標題 = "Error Message";
                    break;
                default:
                    break;
            }
            MessageBox.Show(抬頭 + 錯誤代碼 + " \r" + 錯誤訊息, 標題, _錯誤訊息表[錯誤代碼].訊息選項, _錯誤訊息表[錯誤代碼].訊息圖示);
        }
        private static List<錯誤訊息ViewModel> _錯誤訊息表 = new List<錯誤訊息ViewModel>
        {
            new 錯誤訊息ViewModel {錯誤代碼=0,中文描述="帳號或密碼錯誤" , 英文描述="ID or PassWord is wrong",訊息選項= MessageBoxButton.OK,訊息圖示=MessageBoxImage.Exclamation},
            new 錯誤訊息ViewModel {錯誤代碼=1,中文描述="欄位TYPE錯誤" , 英文描述="FIELD TYPE is wrong",訊息選項= MessageBoxButton.OK,訊息圖示=MessageBoxImage.Error},
            new 錯誤訊息ViewModel {錯誤代碼=2,中文描述="日期格式輸入錯誤" , 英文描述="Date TYPE is wrong",訊息選項= MessageBoxButton.OK,訊息圖示=MessageBoxImage.Exclamation}
        };
    }
}
