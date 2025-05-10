namespace rentalapp;

public class Bike : IInfoDisplay, IRentalItem
{
    public int BikeId { get; private set; }
    public string Type { get; private set; }
    private string Make { get; set; }
    private string Colour { get; set; }
    public bool IsRented { get; private set; }

    public Bike(int bikeId, string type, string make, string colour)
    {
        BikeId = bikeId;
        Type = type;
        Make = make;
        Colour = colour;
        IsRented = false;
    }

    public string DisplayDetails()
    {
        return $"[{Type}] {Make} ({Colour})";
    }

    public void Rent()
    {
        if (!IsRented)
        {
            IsRented = true;
            Console.WriteLine($"[{Type}] {BikeId} ({Colour} {Make}) is now rented.");
        }
        else Console.WriteLine("Bike is already being rented.");
    }

    public void Return()
    {
        if (IsRented)
        {
            IsRented = false;
            Console.WriteLine($"[{Type}] {BikeId} ({Colour} {Make}) is now returned.");
        }
        else Console.WriteLine("Bike is already returned.");
    }
}