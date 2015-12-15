using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 邏輯
{
    public class 信件
    {
        public string 寄件者 { get; set; }
                
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25)
        {
            Credentials = new NetworkCredential("momo16542", "mo20140429"),
            EnableSsl = true
        };
        public AttachmentCollection Attachments { get; set; }
        public MailMessage Message { get; set; }
        public 信件(string 寄件者)
        {
            this.寄件者 = 寄件者;
        }

        public bool 寄信(string 收信者, string 主旨, string 內容)
        {
            bool boolean = true;
            this.Message = new MailMessage(寄件者, 收信者, 主旨, 內容);
            Attachment attachment = new Attachment(@"F:\0129.xml");
            if (Attachments != null)
            {
                foreach (Attachment at in Attachments)
                {
                    Message.Attachments.Add(at);
                }
            }
            try
            {
                smtp.Send(Message);
            }
            catch (Exception ex)
            {
                FileStream file = File.Create(@"C:\temps\錯誤信息+" + DateTime.Now.ToShortTimeString() + ".txt");
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(ex.ToString());
                sw.Close();
                file.Close();
                boolean = false;
            }
            return boolean;
        }
    }
}
