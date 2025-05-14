namespace rentalapp;

public class DataSeeder
{
    public List<Bike> GetBikes()
    {
        return new List<Bike>
        {
            new Bike(Guid.NewGuid(), "BIKE", "Trek", "Blue"),
            new Bike(Guid.NewGuid(), "BIKE", "Giant", "Red"),
            new Bike(Guid.NewGuid(), "BIKE", "Cannondale", "Green"),
            new Bike(Guid.NewGuid(), "BIKE", "Specialized", "Black"),
            new Bike(Guid.NewGuid(), "BIKE", "Mongoose", "Yellow"),
            new Bike(Guid.NewGuid(), "BIKE", "Scott", "Purple"),
            new Bike(Guid.NewGuid(), "BIKE", "Merida", "Orange"),
            new Bike(Guid.NewGuid(), "BIKE", "Cervelo", "White"),
            new Bike(Guid.NewGuid(), "BIKE", "BMC", "Gray"),
            new Bike(Guid.NewGuid(), "BIKE", "Fuji", "Pink")
        };
    }

    public List<Car> GetCars()
    {
        return new List<Car>
        {
            new Car(Guid.NewGuid(), "CAR", "Toyota", "Camry", 2020, "Black"),
            new Car(Guid.NewGuid(), "CAR", "Ford", "Escape", 2021, "White"),
            new Car(Guid.NewGuid(), "CAR", "Honda", "Civic", 2019, "Red"),
            new Car(Guid.NewGuid(), "CAR", "BMW", "Z4", 2022, "Blue"),
            new Car(Guid.NewGuid(), "CAR", "Chevrolet", "Silverado", 2023, "Silver"),
            new Car(Guid.NewGuid(), "CAR", "Mazda", "CX-5", 2021, "Green"),
            new Car(Guid.NewGuid(), "CAR", "Hyundai", "Tucson", 2022, "Gray"),
            new Car(Guid.NewGuid(), "CAR", "Nissan", "Altima", 2020, "Gold"),
            new Car(Guid.NewGuid(), "CAR", "Kia", "Sportage", 2023, "Orange"),
            new Car(Guid.NewGuid(), "CAR", "Tesla", "Model 3", 2024, "Black")
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
            new Customer(Guid.NewGuid(), "Ethan Black", 40),
            new Customer(Guid.NewGuid(), "Fiona Green", 22),
            new Customer(Guid.NewGuid(), "George King", 38),
            new Customer(Guid.NewGuid(), "Hannah Lee", 33),
            new Customer(Guid.NewGuid(), "Isaac Newton", 45),
            new Customer(Guid.NewGuid(), "Jane Doe", 29)
        };
    }
}