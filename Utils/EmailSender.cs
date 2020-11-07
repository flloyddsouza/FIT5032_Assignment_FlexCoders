using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FlexCoders_Assignment.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String fromEmail, String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress(fromEmail, "FlexCoders Web Application");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);           
            var response = client.SendEmailAsync(msg);
        }

        public void sendMultipleEmail(String subject, String contents, List<EmailAddress> tos)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("dsouzaflloyd.11@gmail.com", "FlexCoders Web Application");
            var toEmails = new List<EmailAddress>()
                        {
                              new EmailAddress("dsouzaflloyd.11@gmail.com", "Elmer Thomas"),
                              new EmailAddress("flloyd.1996@gmail.com", "Elmer Thomas Personal"),
                               new EmailAddress("fdso0003@student.monash.edu", "Elmer Thomas Personal")
                        };
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }


       
        

    }
}