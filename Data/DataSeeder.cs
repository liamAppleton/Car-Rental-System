namespace rentalapp;

public class DataSeeder
{
    public List<Bike> GetBikes()
    {
        return new List<Bike>
            {
                new Bike(Guid.NewGuid(), "Mountain", "Trek", "Blue"),
                new Bike(Guid.NewGuid(), "Road", "Giant", "Red"),
                new Bike(Guid.NewGuid(), "Hybrid", "Cannondale", "Green"),
                new Bike(Guid.NewGuid(), "Electric", "Specialized", "Black"),
                new Bike(Guid.NewGuid(), "BMX", "Mongoose", "Yellow")
            };
    }

    public List<Car> GetCars()
    {
        return new List<Car>
            {
                new Car(Guid.NewGuid(), "Sedan", "Toyota", "Camry", 2020, "Black"),
                new Car(Guid.NewGuid(), "SUV", "Ford", "Escape", 2021, "White"),
                new Car(Guid.NewGuid(), "Hatchback", "Honda", "Civic", 2019, "Red"),
                new Car(Guid.NewGuid(), "Convertible", "BMW", "Z4", 2022, "Blue"),
                new Car(Guid.NewGuid(), "Truck", "Chevrolet", "Silverado", 2023, "Silver")
            };
    }

    public List<Customer> GetCustomers()
    {
        return new List<Customer>
            {
                new Customer(Guid.NewGuid(), "Alice Johnson", 30),
                new Customer(Guid.NewGuid(), "Bob Smith", 25),
                new Customer(Guid.NewGuid(), "Charlie Brown", 35),
                new Customer(Guid.NewGuid(), "Daisy White", 28),
                new Customer(Guid.NewGuid(), "Ethan Black", 40)
            };
    }
}