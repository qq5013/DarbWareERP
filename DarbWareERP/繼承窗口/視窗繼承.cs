using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Model;
using DarbWareERP.控制項;

namespace DarbWareERP.繼承窗口
{

    public class 視窗繼承 : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; //配合新增修改時，按鈕的顏色
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        private 控制項操作 控制項操作 = new 控制項操作();
        private bool canClose = false;
        private EnumStatus status = EnumStatus.一般;
        private bool _新增修改中 = false;
        protected string _增刪修訊息;
        public string 增刪修訊息 { get { return _增刪修訊息; } set { _增刪修訊息 = value; } }
        public string KeyFldValue { get; set; }
        public string 目前KeyFldValue { get; set; }
        public string 資料表名稱 { get; set; }
        public EnumStatus Status { get { return status; } set { status = value; } } //0瀏覽模式,1新增模式,2修改模式，控制控制項的readonly、enable等             
        public CollectionViewSource CollectionViewSource { get; set; }        
        public bool 新增修改中
        {
            get
            {
                return _新增修改中;
            }
            set
            {
                _新增修改中 = value;
                OnPropertyChanged(new PropertyChangedEventArgs("新增修改中"));
            }
        }

        public 視窗繼承()
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            e.Cancel = !canClose;
        }
        public void CloseWindow()
        {
            canClose = true;
            this.Close();
            canClose = false;
        }
        public virtual bool BeforeAddNew()
        {
            //按下新增按鈕紀錄之前
            return true;
        }
        public virtual void AfterAddNew()
        {
            //按下新增按鈕紀錄之後
            Model.視窗Model.目前編修資料表 = this.Tag.ToString();
            Model.視窗Model.是否可以離開頁面 = false;
            新增修改中 = true;                       
            表單控制.視窗新增儲存顏色修改("btn" + Tag.ToString(),按鈕顏色.增刪修的顏色);
        }
        public virtual bool BeforeCancelEdit()
        {
            Model.視窗Model.是否可以儲存 = true;
            新增修改中 = false;
            return true;
        }
        public virtual void AfterCancelEdit()
        {
            Model.視窗Model.目前編修資料表 = "";
            Model.視窗Model.是否可以離開頁面 = true;
            表單控制.視窗新增儲存顏色修改("btn" + Tag.ToString(),按鈕顏色.預設的顏色);
        }
        public virtual bool BeforeEndEdit()
        {
            //資料驗證
            return Model.視窗Model.是否可以儲存;
        }
        public virtual void AfterEndEdit()
        {
            Model.視窗Model.目前編修資料表 = "";
            Model.視窗Model.是否可以離開頁面 = true;
            表單控制.視窗新增儲存顏色修改("btn" + Tag.ToString(), 按鈕顏色.預設的顏色);
        }
        public virtual bool UpdateData(CollectionViewSource cv)
        {
            //資料存到資料庫
            return true;
        }
        public virtual void SetControls()
        {
            //設定所有控制項的ReadOnly或Enabled屬性
        }
        public virtual void SetDefaultValue()
        {
            //設定新增紀錄時的預設值，觸發於新增時
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //在視窗中用左右鍵控制上一筆下一筆
            base.OnKeyDown(e);
            if (e.Key == Key.Left)
            {
                Button btn上一筆 = 控制項操作.用名稱尋找子代<Button>(this, "btn上一筆");
                btn上一筆.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                this.Focus();
            }
            else if (e.Key == Key.Right)
            {
                Button btn下一筆 = 控制項操作.用名稱尋找子代<Button>(this, "btn下一筆");
                btn下一筆.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                this.Focus();
            }
        }
    }
}



