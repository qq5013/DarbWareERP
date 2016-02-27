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

namespace DarbWareERP.控制項.下方共同區塊
{
    /// <summary>
    /// 指令區.xaml 的互動邏輯
    /// </summary>
    public partial class 指令區 : UserControl
    {
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
            控制項可否編輯(true);
            顯示儲存和取消鍵();
        }
        private void ButtonEnable(bool enable)
        {
            控制項操作 控制項操作 = new 控制項操作();
            WrapPanel wrap = 控制項操作.用名稱尋找子代<WrapPanel>(this, "wrappanel指令區");
            foreach (UIElement element in wrap.Children)
            {
                ((Button)element).IsEnabled = enable; //儲存和取消鍵另外設定
            }
        }
        private void 顯示儲存和取消鍵()
        {
            btn儲存.Visibility = Visibility.Visible;
            btn儲存.IsEnabled = true;
            btn取消.Visibility = Visibility.Visible;
            btn取消.IsEnabled = true;
        }
        private void 隱藏儲存和取消鍵()
        {
            btn儲存.Visibility = Visibility.Hidden;
            btn儲存.IsEnabled = false;
            btn取消.Visibility = Visibility.Hidden;
            btn取消.IsEnabled = false;
        }

        private void btn儲存_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn取消_Click(object sender, RoutedEventArgs e)
        {
            控制項可否編輯(false);
            隱藏儲存和取消鍵();
        }

        private void 控制項可否編輯(bool 可否編輯)
        {
            控制項操作 控制項操作 = new 控制項操作();
            視窗繼承 window = 控制項操作.尋找父代<視窗繼承>(this);
            控制項操作.設定TextboxReadonly(window, !可否編輯);
            ButtonEnable(!可否編輯);
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
    }
}
