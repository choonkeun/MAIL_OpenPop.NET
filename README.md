# MAIL_OpenPop.NET
Auto Download eMails from External Mail Service using OpenPop.NET 

### Sample C# Mail Code

--Build Message
MailMessage msg = new MailMessage();
msg.From = new MailAddress("example@gmail.com", "Example");
msg.To.Add("friend_a@example.com");
msg.To.Add(new MailAddress("friend_b@example.com", "Friend B"));
msg.Priority = MailPriority.High;
msg.Subject = "Hey, a fabulous site!";
msg.Body = "Hello everybody,<br /> Just Like a Magic. Be sure to visit it soon.";
msg.IsBodyHtml = true;
msg.Attachments.Add(new Attachment("C:\\Site.lnk"));

--Send Message using SMTP
SmtpClient smtp = new SmtpClient();
smtp.Host = "smtp.gmail.com";
smtp.Port = 578;
smtp.EnableSsl = true;
smtp.UseDefaultCredentials = false;
smtp.Credentials = new System.Net.NetworkCredential("example@GMX.com", "buzzwrd");
smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
smtp.Send(msg);
