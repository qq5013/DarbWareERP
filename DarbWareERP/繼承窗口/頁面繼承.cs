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
using Model;
using System.ComponentModel;
using 邏輯Bll.視窗相關;
using System.Reflection;

namespace DarbWareERP.繼承窗口
{
    public class 頁面繼承 : Page
    {
        private bool _新增修改中 = false;
        private EnumStatus status = EnumStatus.一般;
        private string[] _資料表名稱;
        protected string _增刪修訊息;
        private string _目前KeyFldValue;
        private string keyFldValue;        
        public string Pkid { get; set; }
        public string KeyFldValue
        {
            get { return keyFldValue; }
            set
            {
                keyFldValue = value;
                Model.視窗Model.KeyFldValue = value;
            }
        }
        public string 目前KeyFldValue
        {
            get
            {
                return _目前KeyFldValue;
            }
            set
            {
                _目前KeyFldValue = value;
                Model.視窗Model.目前KeyFldValue = value;
            }
        }
        public string[] 資料表名稱
        {
            get { return _資料表名稱; }
            set
            {
                _資料表名稱 = value;
                Model.視窗Model.資料表名稱 = value;
            }
        }
        public string 瀏覽代碼 { get; set; }
        public string 明細瀏覽代碼 { get; set; }
        public CollectionViewSource[] CollectionViewSources { get { return collectionViesSources; } set { collectionViesSources = value; } }
        private CollectionViewSource[] collectionViesSources = new CollectionViewSource[5];
        public EnumStatus Status { get { return status; } set { status = value; } } //0瀏覽模式,1新增模式,2修改模式，控制控制項的readonly、enable等         
        public 控制項操作 控制項操作 = new 控制項操作();
        public string 增刪修訊息 { get { return _增刪修訊息; } set { _增刪修訊息 = value; } }
        public bool 新增修改中
        {
            get
            {
                return _新增修改中;
            }
            set
            {
                _新增修改中 = value;
            }
        }
        public 頁面繼承()
        {
            表單控制.目前頁面 = this;
            初始值設定();
            目前KeyFldValue = "";            
        }
       
        public virtual void 初始值設定()
        {
            資料表名稱 = new string[5];
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
                新增修改刪除Bll page = new 新增修改刪除Bll();
                return page.取得放行碼(Pkid);
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
            增修共同處理(true);
        }
        public virtual bool BeforeCancelEdit()
        {
            視窗Model.是否可以儲存 = true;
            return true;
        }
        public virtual void AfterCancelEdit()
        {
            if (視窗Model.放行碼 > 0)
            {
                新增修改刪除Bll page = new 新增修改刪除Bll();
                page.刪除放行碼();
            }
            增修共同處理(false);
        }
        public virtual bool BeforeEndEdit()
        {
            //資料驗證
            return 視窗Model.是否可以儲存;
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
            新增修改刪除Bll page = new 新增修改刪除Bll();
            return page.取得放行碼(Pkid);
        }
        public virtual void DeleteData(string pkid)
        {
            新增修改刪除Bll page = new 新增修改刪除Bll();
            page.刪除(pkid);
        }
        public virtual void AfterDelete()
        {
            if (視窗Model.放行碼 > 0)
            {
                新增修改刪除Bll page = new 新增修改刪除Bll();
                page.刪除放行碼();
            }
        }
        public virtual bool UpdateData(CollectionViewSource[] cv, EnumStatus status)
        {
            //資料存到資料庫
            Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetName().Name == "邏輯");
            Type type = assembly.GetTypes().FirstOrDefault(x => x.Name == Title + "Bll");
            新增修改刪除Bll instance = (新增修改刪除Bll)Activator.CreateInstance(type);
            return instance.UpdateData(cv, out this._增刪修訊息, Status);
        }
        public virtual void SetControls()
        {
            //設定所有控制項的ReadOnly或Enabled屬性
        }
        public virtual void SetDefaultValue()
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
