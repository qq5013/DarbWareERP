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
using System.Windows.Shapes;
using System.IO;
using ViewModel.訊息相關;


namespace DarbWareERP.控制項
{
    /// <summary>
    /// 欄位格式設定.xaml 的互動邏輯
    /// </summary>
    public partial class 欄位格式設定 : Window
    {
        static string 欄位格式儲存位置 = @"C:\temps\datagrid\";
        static DataGrid datagrid;
        string tag;
        public 欄位格式設定(DataGrid dg, string tag)
        {
            InitializeComponent();
            datagrid = dg;
            this.tag = tag;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            欄位格式儲存(tag);
            訊息ViewModel.訊息顯示(0);
        }
        public static void 欄位格式儲存(string 檔案名稱)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                if (!Directory.Exists(欄位格式儲存位置))
                {
                    Directory.CreateDirectory(欄位格式儲存位置);
                }
                fs = new FileStream(欄位格式儲存位置 + 檔案名稱 + ".dat", FileMode.Create);
                bw = new BinaryWriter(fs);                
                for (int i = 0; i < datagrid.Columns.Count; i++)
                {
                    double value = datagrid.Columns[i].Width.DisplayValue;
                    bw.Write(value);
                    string name = datagrid.Columns[i].Header.ToString();
                    int order = datagrid.Columns[i].DisplayIndex;                                        
                    bw.Write(name);
                    bw.Write(order);
                }

            }
            catch
            {
                MessageBox.Show("保存文件失敗");
            }
            finally
            {
                bw.Flush();
                bw.Close();
                fs.Close();
            }
        }

        public static void 欄位格式讀取(DataGrid dg, string 檔案名稱)
        {
            FileStream fs = null;
            BinaryReader br = null;
            if (!Directory.Exists(欄位格式儲存位置))
            {
                return;
            }
            if (!File.Exists(欄位格式儲存位置 + 檔案名稱 + ".dat"))
            {
                return;
            }
            try
            {
                fs = new FileStream(欄位格式儲存位置 + 檔案名稱 + ".dat", FileMode.Open);
                br = new BinaryReader(fs);                
                for (int i = 0; i < dg.Columns.Count; i++)
                {
                    dg.Columns[i].Width = br.ReadDouble();
                    string name = br.ReadString();
                    int order= br.ReadInt32();
                    dg.Columns.First(x => x.Header.ToString() == name).DisplayIndex = order;
                }
            }
            catch
            {
                MessageBox.Show("讀取文件失敗");
            }
            finally
            {
                if (br != null)
                {
                    br.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}
