//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace T4範本
{
    using System;
    using System.Collections.Generic;
    using Model;
    using System.ComponentModel;
    
    public class Dept_1ViewModel : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    	private  Dept_1Model dept_1Model {get;set;}
    	public  Dept_1ViewModel()
    	{
    		dept_1Model = new Dept_1Model();
        	序號  = "";
        	員工編號  = "";
        	姓名  = "";
        	備註  = "";
        	輸入人員  = "";
        	輸入地點  = "";
        	增刪修  = "";
        	選擇  = "";
    	}
        public string 序號 { get{ if (dept_1Model.序號==null) {dept_1Model.序號="";}  return dept_1Model.序號 ;} set{dept_1Model.序號 = value; 	OnPropertyChanged("序號");} }
        public byte 人員別 { get{return dept_1Model.人員別 ;} set{dept_1Model.人員別 = value;	OnPropertyChanged("人員別"); } }
        public string 員工編號 { get{ if (dept_1Model.員工編號==null) {dept_1Model.員工編號="";}  return dept_1Model.員工編號 ;} set{dept_1Model.員工編號 = value; 	OnPropertyChanged("員工編號");} }
        public string 姓名 { get{ if (dept_1Model.姓名==null) {dept_1Model.姓名="";}  return dept_1Model.姓名 ;} set{dept_1Model.姓名 = value; 	OnPropertyChanged("姓名");} }
        public string 備註 { get{ if (dept_1Model.備註==null) {dept_1Model.備註="";}  return dept_1Model.備註 ;} set{dept_1Model.備註 = value; 	OnPropertyChanged("備註");} }
        public System.DateTime 輸入日期 { get{return dept_1Model.輸入日期 ;} set{dept_1Model.輸入日期 = value;	OnPropertyChanged("輸入日期"); } }
        public string 輸入人員 { get{ if (dept_1Model.輸入人員==null) {dept_1Model.輸入人員="";}  return dept_1Model.輸入人員 ;} set{dept_1Model.輸入人員 = value; 	OnPropertyChanged("輸入人員");} }
        public string 輸入地點 { get{ if (dept_1Model.輸入地點==null) {dept_1Model.輸入地點="";}  return dept_1Model.輸入地點 ;} set{dept_1Model.輸入地點 = value; 	OnPropertyChanged("輸入地點");} }
        public string 增刪修 { get{ if (dept_1Model.增刪修==null) {dept_1Model.增刪修="";}  return dept_1Model.增刪修 ;} set{dept_1Model.增刪修 = value; 	OnPropertyChanged("增刪修");} }
        public string 選擇 { get{ if (dept_1Model.選擇==null) {dept_1Model.選擇="";}  return dept_1Model.選擇 ;} set{dept_1Model.選擇 = value; 	OnPropertyChanged("選擇");} }
        public int 管制碼 { get{return dept_1Model.管制碼 ;} set{dept_1Model.管制碼 = value;	OnPropertyChanged("管制碼"); } }
        public short srvdbid { get{return dept_1Model.srvdbid ;} set{dept_1Model.srvdbid = value;	OnPropertyChanged("srvdbid"); } }
        public int pkid { get{return dept_1Model.pkid ;} set{dept_1Model.pkid = value;	OnPropertyChanged("pkid"); } }
        public int logid { get{return dept_1Model.logid ;} set{dept_1Model.logid = value;	OnPropertyChanged("logid"); } }
        public int linkid { get{return dept_1Model.linkid ;} set{dept_1Model.linkid = value;	OnPropertyChanged("linkid"); } }
    }
}
