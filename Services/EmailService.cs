using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System;

namespace StudentOffice.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "andrei.bagan2@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using(var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("andrei.bagan2@mail.ru", "ZomiHIXoHA2ezkB4ga2Y");
                try
                {
                    await client.SendAsync(emailMessage);
                }
                catch(SmtpCommandException ex)
                {
                    Console.WriteLine("Пользователь с таким email не существует\nКод ошибки:" + ex.Message);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
