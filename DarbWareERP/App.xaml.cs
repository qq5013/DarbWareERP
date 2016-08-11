using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DarbWareERP
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {        
        private ResourceDictionary _當前語言包 = Application.LoadComponent(
                                 new Uri(@"語言\zh-TW.xaml", UriKind.Relative))
                        as ResourceDictionary;
        public ResourceDictionary 當前語言包 { get { return _當前語言包; } set { _當前語言包 = value; } }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;
            ResourceDictionary langRd = null;
            if (currentCultureInfo.Name != "zh-TW")
            {
                try
                {
                    langRd =
                        Application.LoadComponent(
                                 new Uri(@"語言\" + currentCultureInfo.Name + ".xaml", UriKind.Relative))
                        as ResourceDictionary;
                }
                catch
                {
                }
                if (langRd != null)
                {                    
                    this.Resources.MergedDictionaries.Remove(當前語言包);
                    this.Resources.MergedDictionaries.Add(langRd);
                    當前語言包 = langRd;
                }
            }
        }
    }
}
