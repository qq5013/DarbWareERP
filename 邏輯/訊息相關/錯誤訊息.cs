using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 邏輯.訊息相關
{
    public class 錯誤訊息
    {
        int 錯誤代碼 { get; set; }
        string 中文描述 { get; set; }
        string 英文描述 { get; set; }
        MessageBoxButton 訊息選項 { get; set; }
        MessageBoxImage 訊息圖示 { get; set; }
        public static void 錯誤訊息顯示(int 錯誤代碼)
        {
            string 錯誤訊息="";
            string 抬頭 = "";
            string 標題 = "";
            switch (Model.參數設定.語言)
            {
                case Model.參數設定._語言版本.中文:
                    錯誤訊息 = _錯誤訊息表[錯誤代碼].中文描述;
                    抬頭 = "錯誤代碼: ";
                    標題 = "錯誤訊息";
                    break;
                case Model.參數設定._語言版本.英文:
                    錯誤訊息 = _錯誤訊息表[錯誤代碼].英文描述;
                    抬頭 = "Error code: ";
                    標題 = "Error Message";
                    break;
                default:
                    break;
            }
            MessageBox.Show(抬頭+錯誤代碼+" \r"+錯誤訊息,標題, _錯誤訊息表[錯誤代碼].訊息選項, _錯誤訊息表[錯誤代碼].訊息圖示);
        }
        private static List<錯誤訊息> _錯誤訊息表 = new List<錯誤訊息>
        {
            new 錯誤訊息 {錯誤代碼=0,中文描述="帳號或密碼錯誤" , 英文描述="ID or PassWord is wrong",訊息選項= MessageBoxButton.OK,訊息圖示=MessageBoxImage.Exclamation},
            new 錯誤訊息 {錯誤代碼=1,中文描述="欄位TYPE錯誤" , 英文描述="FIELD TYPE is wrong",訊息選項= MessageBoxButton.OK,訊息圖示=MessageBoxImage.Error}
        };


    }
}
