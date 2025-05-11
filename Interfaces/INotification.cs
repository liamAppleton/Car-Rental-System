namespace rentalapp;

public interface INotification
{
    string SendMessage(Customer customer, string message);
}