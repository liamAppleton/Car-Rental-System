namespace rentalapp;

public class RentalManagement<T> where T : class, IRentalItem
{
    public List<Rental> RentedVehicles { get; private set; }
    public List<Car> Cars { get; private set; }
    public List<Bike> Bikes { get; private set; }
    private INotification _notificationSystem;

    public RentalManagement(List<Rental> rentedVehicles, List<Car> cars, List<Bike> bikes, INotification notificationSystem)
    {
        RentedVehicles = rentedVehicles;
        Cars = cars;
        Bikes = bikes;
        _notificationSystem = notificationSystem;
    }

    public void NotifyCustomer(string contactDetails, string message)
    {
        _notificationSystem.SendMessage(contactDetails, message);
    }

    public void AddVehicle(Rental vehicle)
    {
        RentedVehicles.Add(vehicle);

        string displayMessage;
        if (vehicle.Car != null)
        {
            displayMessage = vehicle.Car.GetVehicleDetails();
            vehicle.Car.Rent();
        }
        else
        {
            displayMessage = vehicle.Bike.GetVehicleDetails();
            vehicle.Bike.Rent();
        }

        Console.WriteLine($"{displayMessage} added to rentals.");
    }

    public void RemoveVehicle(Rental vehicle)
    {
        string displayMessage = vehicle.Car != null ? vehicle.Car.GetVehicleDetails() : vehicle.Bike.GetVehicleDetails();
        // Return() needs to be called here
        if (!RentedVehicles.Contains(vehicle))
        {
            Console.WriteLine($"{displayMessage} not currently rented.");
        }
        else
        {
            RentedVehicles.Remove(vehicle);
            Console.WriteLine($"{displayMessage} removed from rentals.");
        }
    }
}