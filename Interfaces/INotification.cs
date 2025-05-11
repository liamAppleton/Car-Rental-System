namespace rentalapp;

public interface INotification
{
    void SendMessage(string contactDetails, string message);
}