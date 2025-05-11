namespace rentalapp;

public class RentalManagement<T> where T : class, IRentalItem, IInfoDisplay
{
    private List<Rental> RentedVehicles { get; set; }
    private List<Car> Cars { get; set; }
    private List<Bike> Bikes { get; set; }
    private INotification NotificationSystem { get; set; }

    public RentalManagement(List<Car> cars, List<Bike> bikes, INotification notificationSystem)
    {
        RentedVehicles = new List<Rental>();
        Cars = cars;
        Bikes = bikes;
        NotificationSystem = notificationSystem;
    }

    public void NotifyCustomer(string contactDetails, string message)
    {
        NotificationSystem.SendMessage(contactDetails, message);
    }

    public void AddVehicle(Rental vehicle)
    {
        RentedVehicles.Add(vehicle);
        string displayMessage = vehicle.Car != null ? vehicle.Car.DisplayDetails() : vehicle.Bike.DisplayDetails();

        Console.WriteLine($"{displayMessage} added to rentals.");
    }

    public void RemoveVehicle(Rental vehicle)
    {
        string displayMessage = vehicle.Car != null ? vehicle.Car.DisplayDetails() : vehicle.Bike.DisplayDetails();

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

    public void DisplayAllRentedVehicles()
    {
        if (RentedVehicles.Count == 0)
        {
            Console.WriteLine("No rented vehicles.");
        }
        else
        {
            Console.WriteLine("Rented vehicles:");
            foreach (Rental rental in RentedVehicles)
            {
                string displayMessage = rental.Car != null ? rental.Car.DisplayDetails() : rental.Bike.DisplayDetails();
                Console.WriteLine(displayMessage);
            }
        }
    }


}