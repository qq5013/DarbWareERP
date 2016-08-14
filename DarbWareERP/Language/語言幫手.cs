using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DarbWareERP.語言
{
    class 語言幫手
    {
        private static ResourceDictionary _當前語言包 = Application.LoadComponent(
                                   new Uri(@"Language\zh-TW.xaml", UriKind.Relative))
                          as ResourceDictionary;
        public static ResourceDictionary 當前語言包 { get { return _當前語言包; } set { _當前語言包 = value; } }
        public static void LoadLanguage()
        {
            CultureInfo currentCultureInfo = CultureInfo.CurrentCulture;
            ResourceDictionary langRd = null;
            //if (currentCultureInfo.Name != "zh-TW")
            //{
                try
                {
                    langRd =
                        Application.LoadComponent(
                                 new Uri("Language\\" + currentCultureInfo.Name + ".xaml", UriKind.Relative))
                        as ResourceDictionary;
                }
                catch
                {
                }
                if (langRd != null)
                {
                    App.Current.Resources.MergedDictionaries.Remove(當前語言包);
                    App.Current.Resources.MergedDictionaries.Add(langRd);
                    當前語言包 = langRd;
                }
            //}
        }
        public static void SwitchLanquage(語言 language)
        {
            ResourceDictionary langRd = null;
            string location = "Language/" + 語言文化表[language].ToString() + ".xaml";
            try
            {
                langRd =
                    Application.LoadComponent(new Uri(location, UriKind.Relative))
                    as ResourceDictionary;
            }
            catch
            {
            }
            if (langRd != null)
            {
                App.Current.Resources.MergedDictionaries.Remove(當前語言包);
                App.Current.Resources.MergedDictionaries.Add(langRd);
                當前語言包 = langRd;
            }
        }
        static Dictionary<語言, string> 語言文化表 = new Dictionary<語言, string>()
        {
            {語言.中文,"zh-TW" },
            {語言.English,"en-US" }
        };
    }
    public enum 語言
    {
        中文, English
    }
}
