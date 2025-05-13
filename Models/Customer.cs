namespace rentalapp;

public class Customer
{
    private Guid CustomerId { get; set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
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

    public string GetCurrentlyRenting()
    {
        if (CurrentlyRenting != null)
        {
            return CurrentlyRenting.GetVehicleDetails();
        }
        else
        {
            return $"{Name} is not currently renting.";
        }

    }

}