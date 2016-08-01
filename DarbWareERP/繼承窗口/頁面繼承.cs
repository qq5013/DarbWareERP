using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using DarbWareERP;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using ViewModel;
using System.Reflection;
using ViewModel.增刪修;
using System.Windows.Media;

namespace DarbWareERP.繼承窗口
{
    public class 頁面繼承 : Page
    {
        private 增刪修Status status = 增刪修Status.一般;
        protected string _增刪修訊息;
        public string Pkid { get { return 增刪修viewmodel.Pkid; } set { 增刪修viewmodel.Pkid = value; } }
        public string KeyFldValue { get; set; }
        public string 目前KeyFldValue { get; set; }
        public string[] 資料表名稱
        {
            get { return 增刪修viewmodel.資料表名稱; }
        }
        public string 瀏覽代碼 { get; set; }
        public string 明細瀏覽代碼 { get; set; }
        public 瀏覽系列.瀏覽類型Enum 瀏覽類型 { get; set; }
        public CollectionViewSource[] CollectionViewSources { get { return collectionViesSources; } set { collectionViesSources = value; } }
        private CollectionViewSource[] collectionViesSources = new CollectionViewSource[5];
        public 增刪修Status Status { get { return status; } set { status = value; } } //0瀏覽模式,1新增模式,2修改模式，控制控制項的readonly、enable等         
        增刪修ViewModel 增刪修viewmodel = new 增刪修ViewModel();
        //在xaml中設定成statistic resource，配合主索引驗證
        public string 增刪修訊息 { get { return _增刪修訊息; } set { _增刪修訊息 = value; } }
        public bool 新增修改中 { get; set; }
        public 頁面繼承()
        {
            表單控制.目前頁面 = this;
            初始值設定();
            目前KeyFldValue = "";
            this.Style = Application.Current.FindResource("頁面繼承Style") as Style;
            this.Loaded += 頁面繼承_Loaded;
        }
        protected virtual void 頁面繼承_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox txtpkid = 控制項操作.用名稱尋找子代<TextBox>(this, "txtpkid");
            if (txtpkid != null)
            {
                txtpkid.IsReadOnly = true;
            }
            SetControls();
        }
        public virtual void 初始值設定()
        {

        }
        public virtual bool BeforeAddNew()
        {
            //按下新增按鈕紀錄之前
            bool value;
            if (表單控制.目前編修資料表 == "")
            {
                value = true;
            }
            else
            {
                value = false;
                MessageBox.Show(表單控制.目前編修資料表 + "正在編修中");
            }
            return value;
        }
        public virtual void AfterAddNew()
        {
            //按下新增按鈕紀錄之後
            增修共同處理(true);

        }
        public virtual bool BeforeEdit()
        {
            bool result = 檢查有無KeyFldValue();
            if (result == false)
            {
                return result;
            }
            else
            {
                return 增刪修viewmodel.取得放行碼(Pkid);
            }
        }
        public virtual void AfterEdit()
        {
            增修共同處理(true);
        }
        public virtual bool BeforeCopy()
        {
            bool result = 檢查有無KeyFldValue();
            return result;
        }

        public virtual void AfterCopy()
        {
            DependencyObject dobj = this.FindName("grid資料區") as DependencyObject;
            foreach (object obj in LogicalTreeHelper.GetChildren(dobj))
            {
                TextBox txt = obj as TextBox;
                if (txt == null) continue;
                txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
            增修共同處理(true);
        }
        public virtual bool BeforeCancelEdit()
        {
            //取消時，不管資料驗證都可以取消，並且將值設定回true;            
            return true;
        }
        public virtual void AfterCancelEdit()
        {
            增刪修viewmodel.刪除放行碼();
            增修共同處理(false);
        }
        public virtual bool BeforeEndEdit()
        {
            //資料驗證                 
            bool result = true;
            DependencyObject dobj = this.FindName("grid資料區") as DependencyObject;
            foreach (object obj in LogicalTreeHelper.GetChildren(dobj))
            {
                TextBox txt = obj as TextBox;
                if (txt == null) continue;
                if (Validation.GetHasError(txt))
                {
                    result = false; //只要有一個TEXTBOX錯就不能儲存
                    break;
                }
            }
            return result;
        }
        public virtual void SetValueEndEdit()
        {

        }
        public virtual void AfterEndEdit()
        {
            增修共同處理(false);
        }
        public virtual bool BeforeDelete()
        {
            //資料驗證
            if (this.CollectionViewSources[0].Source == null)
            {
                MessageBox.Show("請先選擇一筆資料", "注意", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            return 增刪修viewmodel.取得放行碼(Pkid);
        }
        public virtual void DeleteData()
        {
            增刪修viewmodel.刪除();
        }
        public virtual void AfterDelete()
        {
            增刪修viewmodel.刪除放行碼();
        }
        public virtual bool UpdateData()
        {
            //資料存到資料庫
            return 增刪修viewmodel.UpdateData(collectionViesSources, out this._增刪修訊息, Status, 資料表名稱);
        }
        public virtual void SetControls()
        {
            //設定所有控制項的ReadOnly或Enabled屬性
        }
        public virtual void SetTextBoxOrdetl()
        {
            //設定新增紀錄時的預設值，觸發於新增時
        }
        private bool 檢查有無KeyFldValue()
        {
            bool result = false;
            if (目前KeyFldValue == "")
            {
                MessageBox.Show("請先選擇一筆資料", "注意", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
        /// <summary>
        /// 新增複製修改時，改變按鈕顏色不能返回選單等處理。
        /// </summary>
        /// <param name="是增刪修">增刪修為TRUE，儲存離開為FALSE</param>
        private void 增修共同處理(bool 是否增修)
        {
            新增修改中 = 是否增修;
            表單控制.命令區塊實體.是否可以離開頁面 = !是否增修;
            if (是否增修)
            {
                表單控制.目前編修資料表 = this.Title;
                控制項操作.用名稱尋找子代<Button>(表單控制.切換表單區實體, "btn" + Title).Foreground = 表單控制.增刪修的顏色;
            }
            else
            {
                表單控制.目前編修資料表 = "";
                控制項操作.用名稱尋找子代<Button>(表單控制.切換表單區實體, "btn" + Title).Foreground = 表單控制.預設的顏色;
            }
        }
    }
}
