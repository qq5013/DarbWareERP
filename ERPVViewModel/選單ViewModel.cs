using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 邏輯Bll.視窗相關;

namespace ViewModel
{
    public class 選單ViewModel
    {
        private static 選單ViewModel 選單viewmodel;
        
        public string 系統名稱 { get; private set; }
        private 選單ViewModel()
        {

        }
        public static 選單ViewModel GetInstance()
        {
            if (選單viewmodel == null)
            {
                選單viewmodel = new 選單ViewModel();
            }
            return 選單viewmodel;
        }
        public List<string> 選單按鈕名稱列表()
        {
            List<string> 選單 = new List<string>();
            var qry = (from a in 使用者ViewModel.GetInstance().權限表.AsEnumerable()
                       select a.Field<string>("按鈕名稱")).Distinct();
            foreach (var qq in qry)
            {
                if (!qq.Contains("EE")) //目前系統沒看到的按鈕
                {
                    選單.Add(qq);
                }
            }
            return 選單;
        }
        public List<string> 程式名稱列表(string 系統名) //導覽區的按鈕
        {
            this.系統名稱 = 系統名;
            List<string> 程式名稱列表 = new List<string>();
            var qry = from a in 使用者ViewModel.GetInstance().權限表.AsEnumerable()
                      where a.Field<string>("按鈕名稱") == 系統名稱
                      select a.Field<string>("程式名稱");
            foreach (var qq in qry)
            {
                程式名稱列表.Add(qq);
            }
            return 程式名稱列表;
        }
    }
}
