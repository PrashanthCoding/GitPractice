using System;

class Notification
{
    public virtual void Send() => Console.WriteLine("Sending notification...");
}

class EmailNotification : Notification
{
    public override void Send() => Console.WriteLine("Sending email notification...");
}

class SMSNotification : Notification
{
    public override void Send() => Console.WriteLine("Sending SMS notification...");
}

class Program
{
    static void Main()
    {
        Notification email = new EmailNotification();
        Notification sms = new SMSNotification();
        email.Send();
        sms.Send();
    }
}
