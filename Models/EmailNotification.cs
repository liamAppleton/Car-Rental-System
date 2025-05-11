namespace rentalapp;

public class EmailNotification : INotification
{
    public void SendMessage(string contactDetails, string message)
    {
        Console.WriteLine($"Email to ${contactDetails} : {message}");
    }
}