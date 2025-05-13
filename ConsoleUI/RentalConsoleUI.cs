using Spectre.Console;

namespace rentalapp;

public class RentalConsoleUI<T> where T : class, IRentalItem
{
    private RentalManagement<T> _rentalManagement;
    private CustomerManagement _customerManagement;

    public RentalConsoleUI(RentalManagement<T> rentalManagement, CustomerManagement customerManagement)
    {
        _rentalManagement = rentalManagement;
        _customerManagement = customerManagement;
    }

    public DisplayAllRentalVehicles()
    {
        if (_rentalManagement.RentedVehicles.Count == 0)
        {
            AnsiConsole.WriteLine("[red] No rented vehicles [/]");
        }
        else
        {
            var table = new Table();
            table.AddColumn("Vehicle Details");
            table.AddColumn("Rented By");

            foreach (Rental rental in _rentalManagement.RentedVehicles)
            {
                string details = rental.Car != null ? rental.Car.GetVehicleDetails() : rental.Bike.GetVehicleDetails();

                string? customerName = _rentalManagement.RentedVehicles
                    .Join(_customerManagement.Customers,
                    rental => rental.CustomerId,
                    customer => customer.CustomerId,
                    (rental, customer) => new { rental, customer })
                    .Where(rentalCustomer => rentalCustomer.rental.RentalId == rental.RentalId)
                    .Select(rentalCustomer => rentalCustomer.customer.Name)
                    .FirstOrDefault();

                table.AddRow(details, customerName);
            }

            AnsiConsole.Write(table);
        }
    }
}