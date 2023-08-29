using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main()
    {

        Console.WriteLine("----------------Send A verfication code to mail----------------");
        string senderEmail = "Write your gmail here";
        Console.Write("Enter a gmail: ");
        string receiverEmail = Console.ReadLine(); //Enter receiver email

        string password = "nlsesctyunihtbsw"; 

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(senderEmail, password),
            EnableSsl = true,
        };

        Random rand = new Random();
        int number = rand.Next(1, 100); // Generate random number 

        MailMessage mail = new MailMessage(senderEmail, receiverEmail)
        {
            Subject = "Verification code",                      // Type here what you want its not important
            Body = $"Your verification code is: {number}",
        };

        try
        {
            smtpClient.Send(mail);
            Console.WriteLine("Mail sended successfuly!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mail gonderilmedi");
        }
    }
}
