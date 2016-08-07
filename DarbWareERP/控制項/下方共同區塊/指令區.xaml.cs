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
using ViewModel;
using 報表;
using System.Collections.ObjectModel;
using ViewModel.增刪修;
using System.Reflection;

namespace DarbWareERP.控制項.下方共同區塊
{
    /// <summary>
    /// 指令區.xaml 的互動邏輯
    /// </summary>
    public partial class 指令區 : UserControl
    {
        頁面繼承 page;
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
            if (page.BeforeAddNew())
            {
                page.Status = 增刪修Status.新增;
                指令區按鈕顯示(true);
                導覽區Enable(false);
                page.SetControls();
                導覽區.btn重新整理.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                for (int k = 0; k < page.CollectionViewSources.Count(); k++)
                {
                    if (page.CollectionViewSources[k] != null)
                    {
                        ListCollectionView collectionview = (ListCollectionView)page.CollectionViewSources[k].View;
                        for (int i = 0; i < collectionview.Count; i++)
                        {
                            collectionview.Remove(collectionview.CurrentItem);
                        }
                        if (k == 0)
                        {
                            collectionview.AddNew();
                        }
                    }
                }
                page.SetTextBoxOrdetl();
                page.AfterAddNew();
            }
        }
        private void btn修改_Click(object sender, RoutedEventArgs e)
        {
            if (page.BeforeEdit())
            {
                if (!確認資料是否存在())
                {
                    MessageBox.Show("資料已刪除，不得修改或刪除", "注意", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                page.Status = 增刪修Status.修改;
                指令區按鈕顯示(true);
                導覽區Enable(false);
                page.SetControls();
                for (int i = 0; i < page.CollectionViewSources.Count(); i++)
                {
                    if (page.CollectionViewSources[i] != null)
                    {
                        object source= page.CollectionViewSources[i].Source;                        
                        PropertyInfo count = source.GetType().GetProperty("Count");
                        PropertyInfo items = source.GetType().GetProperty("Item");
                        for (int j = 0; j < Convert.ToInt32(count.GetValue(source)); j++)
                        {
                            object item = items.GetValue(source, new object[] { j });
                            PropertyInfo 增刪修 = item.GetType().GetProperty("增刪修");//在建構式以及指令區設定
                            增刪修.SetValue(item, "E");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                page.AfterEdit();
            }
        }
        private void btn複製_Click(object sender, RoutedEventArgs e)
        {
            if (page.BeforeCopy())
            {
                page.Status = 增刪修Status.複製;
                指令區按鈕顯示(true);
                導覽區Enable(false);
                page.SetControls();
                page.SetTextBoxOrdetl();
                page.AfterCopy();
            }
        }
        private void btn刪除_Click(object sender, RoutedEventArgs e)
        {
            if (page.BeforeDelete())
            {
                if (!確認資料是否存在())
                {
                    MessageBox.Show("資料已刪除，不得修改或刪除", "注意", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
                if (MessageBox.Show("是否刪除此筆資料", "刪除", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    page.DeleteData();
                    MessageBox.Show("刪除成功", "訊息", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                導覽區.btn重新整理.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            page.AfterDelete();
        }

        private void btn儲存_Click(object sender, RoutedEventArgs e)
        {
            if (page.BeforeEndEdit())
            {
                增刪修Status PrevTableStatus = page.Status;
                if (page.Status == 增刪修Status.修改)
                {
                    page.EditBeforeUpdate();
                }
                foreach (CollectionViewSource cv in page.CollectionViewSources)
                {
                    if (cv != null)
                    {
                        ListCollectionView collectionview = (ListCollectionView)cv.View;
                        switch (page.Status)
                        {
                            case 增刪修Status.一般:
                                MessageBox.Show("儲存出錯，Status要設定為新增或修改");
                                break;
                            case 增刪修Status.新增:
                                collectionview.CommitNew();
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                try
                {
                    if (page.UpdateData())
                    {
                        導覽區.查詢();
                        page.Status = 增刪修Status.一般;
                        page.SetControls();
                        page.AfterEndEdit();
                        指令區按鈕顯示(false);
                        導覽區Enable(true);

                    }
                    MessageBox.Show(page.增刪修訊息);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系統錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
                    page.Status = PrevTableStatus;
                }

            }
            else
            {
                MessageBox.Show("請確認是否有輸入錯誤資料", "訊息視窗", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btn取消_Click(object sender, RoutedEventArgs e)
        {
            if (page.BeforeCancelEdit())
            {
                foreach (CollectionViewSource cv in page.CollectionViewSources)
                {
                    if (cv != null)
                    {
                        ListCollectionView collectionview = (ListCollectionView)cv.View;
                        switch (page.Status)
                        {
                            case 增刪修Status.一般:
                                MessageBox.Show("取消出錯，Status要設定為新增或修改");
                                break;
                            case 增刪修Status.新增:
                                collectionview.CancelNew();
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                page.Status = 增刪修Status.一般;
                指令區按鈕顯示(false);
                導覽區Enable(true);
                page.SetControls();
                導覽區.btn重新整理.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                page.AfterCancelEdit();
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
            page = 控制項操作.尋找父代<頁面繼承>(this);
            導覽區 = 控制項操作.用名稱尋找子代<導覽區>(page, "導覽區");
            wrap = 控制項操作.用名稱尋找子代<WrapPanel>(this, "wrappanel指令區");
        }
        private bool 確認資料是否存在()
        {
            bool result = true;
            string pkid = page.目前KeyFldValue;
            導覽區.btn重新整理.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            if (pkid != page.目前KeyFldValue)
            {
                result = false;
            }
            return result;
        }

        private void btn瀏覽_Click(object sender, RoutedEventArgs e)
        {
            表單控制.切換瀏覽頁面(page.瀏覽類型, txbl程式名稱.Text, page.瀏覽代碼, page.資料表名稱);
        }

        private void btn列印_Click(object sender, RoutedEventArgs e)
        {

            預覽報表 report = new 預覽報表(page.CollectionViewSources[0].Source);
            report.ShowDialog();
        }
    }
}
