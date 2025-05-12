namespace rentalapp;

public class Customer
{
    private Guid CustomerId { get; set; }
    public string Name { get; private set; }
    private int Age { get; set; }
    private IRentalItem? CurrentlyRenting { get; set; }

    public Customer(Guid customerId, string name, int age)
    {
        CustomerId = customerId;
        Name = name;
        Age = age;
    }

    public string GetDetails()
    {
        return $"{CustomerId}: {Name} ({Age})";
    }

    public void ViewCurrentlyRenting()
    {
        if (CurrentlyRenting != null)
        {
            CurrentlyRenting.GetVehicleDetails();
        }
        else
        {
            Console.WriteLine($"{Name} is not currently renting.");
        }

    }

}