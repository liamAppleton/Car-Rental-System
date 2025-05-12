namespace rentalapp;

public class VehicleQuery<T> where T : class, IRentalItem
{
    private RentalManagement<T> _rentalManagement;

    public VehicleQuery(RentalManagement<T> rentalManagement)
    {
        _rentalManagement = rentalManagement;
    }

    public List<Car> GetCurrentlyRentedCars()
    {
        return _rentalManagement.Cars
            .Where(car => car.IsRented)
            .ToList();
    }

    public List<Bike> GetCurrentlyRentedBikes()
    {
        return _rentalManagement.Bikes
            .Where(bike => bike.IsRented)
            .ToList();
    }

    public List<Car> GetCurrentlyAvailableCars()
    {
        return _rentalManagement.Cars
            .Where(car => !car.IsRented)
            .ToList();
    }

    public List<Bike> GetCurrentlyAvailableBikes()
    {
        return _rentalManagement.Bikes
            .Where(bike => !bike.IsRented)
            .ToList();
    }

    public List<Car> GetCarsByColour(string colour)
    {
        try
        {
            return _rentalManagement.Cars
            .Where(car => car.Colour == colour)
            .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No cars of colour: {colour} in database");
            Console.WriteLine($"Error: {ex}");
            return new List<Car>();
        }
    }

    public List<Bike> GetBikesByColour(string colour)
    {
        try
        {
            return _rentalManagement.Bikes
            .Where(bike => bike.Colour == colour)
            .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"No bikes of colour: {colour} in database");
            Console.WriteLine($"Error: {ex}");
            return new List<Bike>();
        }
    }
}