namespace rentalapp;

public class Bike : IInfoDisplay, IRentalItem
{
    private int BikeId { get; set; }
    private string Make { get; set; }
    private string Colour { get; set; }
    public bool IsRented { get; private set; }

    public Bike(int bikeId, string make, string colour)
    {
        BikeId = bikeId;
        Make = make;
        Colour = colour;
        IsRented = false;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"[BIKE] {Make} ({Colour})");
    }

    public void Rent()
    {
        if (!IsRented)
        {
            IsRented = true;
            Console.WriteLine($"[BIKE] {BikeId} ({Colour} {Make}) is now rented.");
        }
        else Console.WriteLine("Bike is already being rented.");
    }

    public void Return()
    {
        if (IsRented)
        {
            IsRented = false;
            Console.WriteLine($"[BIKE] {BikeId} ({Colour} {Make}) is now returned.");
        }
        else Console.WriteLine("Bike is already returned.");
    }
}