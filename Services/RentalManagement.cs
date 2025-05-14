namespace rentalapp;

public class RentalManagement<T> where T : class, IRentalItem
{
    public List<Rental> RentedVehicles { get; private set; }
    public List<Car> Cars { get; private set; }
    public List<Bike> Bikes { get; private set; }

    public RentalManagement(List<Rental> rentedVehicles, List<Car> cars, List<Bike> bikes)
    {
        RentedVehicles = rentedVehicles;
        Cars = cars;
        Bikes = bikes;
    }

    public void AddVehicle(Rental vehicle)
    {
        RentedVehicles.Add(vehicle);

        string vehicleDetails = vehicle.Car != null ? vehicle.Car.GetVehicleDetails() : vehicle.Bike.GetVehicleDetails();
        if (vehicle.Car != null)
        {
            vehicle.Car.Rent();
        }
        else
        {
            vehicle.Bike.Rent();
        }

        Console.WriteLine($"{vehicleDetails} added to rentals.");
    }

    public void RemoveVehicle(Rental vehicle)
    {
        string vehicleDetails = vehicle.Car != null ? vehicle.Car.GetVehicleDetails() : vehicle.Bike.GetVehicleDetails();
        string displayMessage = !RentedVehicles.Contains(vehicle) ? "not currently rented." : "removed from rentals";

        if (vehicle.Car != null)
        {
            RentedVehicles.Remove(vehicle);
            vehicle.Car.Return();
        }
        else
        {
            RentedVehicles.Remove(vehicle);
            vehicle.Bike.Return();
        }

        Console.WriteLine($"{vehicleDetails} {displayMessage}");
    }
}