namespace rentalapp
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSeeder dataSeeder = new DataSeeder();
            List<Car> cars = dataSeeder.GetCars();
            List<Bike> bikes = dataSeeder.GetBikes();
            List<Customer> customers = dataSeeder.GetCustomers();

            EmailNotification emailNotification = new EmailNotification();

            CustomerManagement customerManagement = new CustomerManagement(customers);
            RentalManagement<IRentalItem> rentalManagement = new RentalManagement<IRentalItem>(new List<Rental>(), cars, bikes, emailNotification);
        }
    }
}