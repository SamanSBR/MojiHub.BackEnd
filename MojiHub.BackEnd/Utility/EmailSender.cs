using System.Net.Mail;

namespace MojiHub.BackEnd.Utility
{
    public class EmailSender
    {

        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("funkilington@gmail.com", "MojiHub");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("funkilington@gmail.com", "wgmmcjypxcixhxnr");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }

    }
}
