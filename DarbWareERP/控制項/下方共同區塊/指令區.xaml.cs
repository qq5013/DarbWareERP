using DarbWareERP.繼承窗口;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Model;

namespace DarbWareERP.控制項.下方共同區塊
{
    /// <summary>
    /// 指令區.xaml 的互動邏輯
    /// </summary>
    public partial class 指令區 : UserControl
    {
        控制項操作 控制項操作;
        視窗繼承 window;
        導覽區 導覽區;
        WrapPanel wrap;
        public 指令區()
        {
            InitializeComponent();
            btn1.Visibility = Visibility.Hidden;
            btn2.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Hidden;
            btn5.Visibility = Visibility.Hidden;
            btn6.Visibility = Visibility.Hidden;
        }

        private void btn新增_Click(object sender, RoutedEventArgs e)
        {                  
            if (window.BeforeAddNew())
            {
                清除綁定datatable(控制項操作, window);
                BindingListCollectionView collectionview = (BindingListCollectionView)window.CollectionViewSource.View;
                collectionview.AddNew();  //用bindingListCollectionView去增加 修改 Datatable值
                window.Status = EnumStatus.新增;
                指令區按鈕顯示(true);
                導覽區Enable(false);
                window.SetControls();
                window.SetDefaultValue();                
                window.AfterAddNew();                
            }
        }
        private void 清除綁定datatable(控制項操作 控制項操作, 視窗繼承 window)
        {            
            導覽區.btn重新整理.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            DataTable dt = ((DataTable)window.CollectionViewSource.Source);
            dt.Rows.Clear();            
        }

        private void btn儲存_Click(object sender, RoutedEventArgs e)
        {                            
            if (window.BeforeEndEdit())
            {
                EnumStatus PrevTableStatus = window.Status;
                BindingListCollectionView collectionview = (BindingListCollectionView)window.CollectionViewSource.View;
                switch (window.Status)
                {
                    case EnumStatus.一般:
                        MessageBox.Show("儲存出錯，Status要設定為新增或修改");
                        break;
                    case EnumStatus.新增:                        
                        collectionview.CommitNew();
                        break;
                    case EnumStatus.修改:                        
                        collectionview.CommitEdit();
                        break;
                }                

                try
                {
                    if (window.UpdateData(window.CollectionViewSource))
                    {
                        window.Status = 0;
                        window.SetControls();
                        window.AfterEndEdit();
                        指令區按鈕顯示(false);
                        導覽區Enable(true);
                        MessageBox.Show(window.增刪修訊息);
                    }                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "操作錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                    window.Status = PrevTableStatus;
                }
                
            }
            else
            {
                MessageBox.Show("請確認是否有輸入錯誤資料", "訊息視窗", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }       

        private void btn取消_Click(object sender, RoutedEventArgs e)
        {            
            if (window.BeforeCancelEdit())
            {
                BindingListCollectionView collectionview = (BindingListCollectionView)window.CollectionViewSource.View;
                switch (window.Status)
                {
                    case EnumStatus.一般:
                        MessageBox.Show("取消出錯，Status要設定為新增或修改");
                        break;
                    case EnumStatus.新增:
                        collectionview.CancelNew();
                        break;
                    case EnumStatus.修改:
                        collectionview.CancelEdit();
                        break;
                }
                window.Status = EnumStatus.一般;
                指令區按鈕顯示(false);
                導覽區Enable(true);
                window.SetControls();
                導覽區.btn重新整理.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                window.AfterCancelEdit();
            }
        }
        private void 導覽區Enable(bool enable)
        {            
            導覽區.IsEnabled = enable;
        }
             
        private void 指令區按鈕顯示(bool 顯示)
        {           
            
            foreach (UIElement element in wrap.Children)
            {
                ((Button)element).IsEnabled = !顯示; //儲存和取消鍵另外設定
            }
            btn儲存.IsEnabled = 顯示;
            btn取消.IsEnabled = 顯示;
            if (顯示)
            {
                btn儲存.Visibility = Visibility.Visible;
                btn取消.Visibility = Visibility.Visible;
            }
            else
            {
                btn儲存.Visibility = Visibility.Hidden;
                btn取消.Visibility = Visibility.Hidden;
            }
        }
        private void btn新增_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn新增);
        }

        private void btn複製_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn複製);
        }

        private void btn修改_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn修改);
        }

        private void btn刪除_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn刪除);
        }

        private void btn歷史檔案_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn歷史檔案);
        }

        private void btn列印_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn列印);
        }

        private void btn瀏覽_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn瀏覽);
        }

        private void btn清單瀏覽_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            改變ButtonContent(btn清單瀏覽);
        }

        private void 改變ButtonContent(Button btn)
        {
            if (btn.IsEnabled == true)
            {
                Btn圖片替換(btn, btn.Name.ToString().Substring(3) + "00");
            }
            else
            {
                Btn圖片替換(btn, btn.Name.ToString().Substring(3) + "01");
            }
        }

        private void Btn圖片替換(Button btn, string 圖片名稱)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"/DarbWareERP;component/Image/Icon_png/" + 圖片名稱 + ".png", UriKind.Relative));
            btn.Content = image;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            控制項操作 = new 控制項操作();
            window = 控制項操作.尋找父代<視窗繼承>(this);
            導覽區 = 控制項操作.用名稱尋找子代<導覽區>(window, "導覽區");
            wrap = 控制項操作.用名稱尋找子代<WrapPanel>(this, "wrappanel指令區");
        }
        bool bo = true;
        Brush br = null;
        Brush br1 = new SolidColorBrush(Colors.Coral);
        
        private void btn清單瀏覽_Click(object sender, RoutedEventArgs e)
        {            
            if (bo)
            {
                Button QQ = 控制項操作.用名稱尋找子代<Button>(window, "btn導覽區按鈕1");
                br = QQ.Foreground;
                QQ.Foreground = br1;
                bo = !bo;
            }
            else
            {
                Button QQ = 控制項操作.用名稱尋找子代<Button>(window, "btn導覽區按鈕1");
                QQ.Foreground = br;
                bo = !bo;
            }
        }
    }
}
