namespace rentalapp;

public class SmsNotification : INotification
{
    public void SendMessage(string contactDetails, string message)
    {
        Console.WriteLine($"SMS to ${contactDetails} : {message}");
    }
}