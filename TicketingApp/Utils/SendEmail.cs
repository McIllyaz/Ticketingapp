using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace TicketingApp.Utils
{
    public class SendEmail
    {
        public static bool SendEmailToken(int token, string receiver)
        {
            bool isSend = false;
            try
            {
                // Buat objek klien email
                SmtpClient smtpClient = new SmtpClient("smtp.yourprovider.com"); // Gantilah dengan server SMTP yang sesuai

                // Tentukan informasi kredensial
                smtpClient.Credentials = new NetworkCredential("tiketln.app@gmail.com", "ingatmati"); // Gantilah dengan email dan password Anda

                // Tentukan pengaturan klien email (misalnya, port)
                smtpClient.Port = 587; // Gantilah dengan port yang sesuai

                // Buat objek email
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("tiketln.app@gmail.com"); // Gantilah dengan alamat email pengirim
                mailMessage.To.Add(receiver); // Gantilah dengan alamat email penerima
                mailMessage.Subject = "KODE VERIFIKASI GANTI PASSWORD AKUN";
                mailMessage.Body = "Kode verifikasi anda adalah :\n" + token + "\nToken hanya berlaku dalam 5 menit.";

                // Kirim email
                smtpClient.Send(mailMessage);
                isSend = true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
            }
            return isSend;
        }

        public static bool datajpg()
        {
            bool isSend = false;
            try
            {
                string fromAddress = "@gmail.com";
                string toAddress = "@email";
                string subject = "Subject of the Email";
                string body = "Body of the Email";

                // Gantilah dengan path file gambar JPEG yang ingin Anda kirim
                string imagePath = @"C:\Downloads\Ticketingapp\Ticketingapp-master\TicketingApp\Docs\Image.jpg";

                MailMessage mailMessage = new MailMessage(fromAddress, toAddress, subject, body);

                // Tambahkan lampiran (Attachment) ke email
                Attachment attachment = new Attachment(imagePath);
                mailMessage.Attachments.Add(attachment);

                // Buat objek klien email
                SmtpClient smtpClient = new SmtpClient("smtp.yourprovider.com"); // Gantilah dengan server SMTP yang sesuai

                // Tentukan informasi kredensial (sesuaikan dengan kebutuhan keamanan Anda)
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("tiketln.app@gmail.com", "ingatmati"); // Gantilah dengan email dan password Anda

                // Tentukan pengaturan klien email (misalnya, port)
                smtpClient.Port = 587; // Gantilah dengan port yang sesuai
                smtpClient.EnableSsl = true; // Aktifkan SSL jika diperlukan oleh server

                // Kirim email
                smtpClient.Send(mailMessage);
                isSend = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return isSend;
        }

    }
}
