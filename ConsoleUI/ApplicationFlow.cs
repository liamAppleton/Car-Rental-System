namespace rentalapp;

using Spectre.Console;

public class ApplicationFlow
{
    private List<Car> _cars;
    private List<Bike> _bikes;
    private List<Customer> _customers;
    private CustomerManagement _customerManagement;
    private RentalManagement<IRentalItem> _rentalManagement;
    private CustomerConsoleUI _customerConsoleUI;
    private RentalConsoleUI<IRentalItem> _rentalConsoleUI;
    private VehicleQueryConsoleUI<IRentalItem> _vehicleQueryConsoleUI;
    private EmailNotification _emailNotification;
    private SmsNotification _smsNotification;

    public ApplicationFlow()
    {
        DataSeeder dataSeeder = new DataSeeder();
        _cars = dataSeeder.GetCars();
        _bikes = dataSeeder.GetBikes();
        _customers = dataSeeder.GetCustomers();

        _emailNotification = new EmailNotification();
        _smsNotification = new SmsNotification();

        _customerManagement = new CustomerManagement(_customers);
        _rentalManagement = new RentalManagement<IRentalItem>(new List<Rental>(), _cars, _bikes, _emailNotification);

        _customerConsoleUI = new CustomerConsoleUI(_customerManagement);
        _rentalConsoleUI = new RentalConsoleUI<IRentalItem>(_rentalManagement, _customerManagement);
        _vehicleQueryConsoleUI = new VehicleQueryConsoleUI<IRentalItem>(_rentalManagement);
    }

    public void DisplayAppIntro()
    {
        AnsiConsole.MarkupLine("[bold underline green]Welcome to Car Rental Enterprise[/]\n");
        AnsiConsole.MarkupLine("[blue]------------------------------------------[/]");
        AnsiConsole.MarkupLine("[yellow]Manage your fleet of cars and bikes seamlessly[/]");
        AnsiConsole.MarkupLine("[blue]------------------------------------------[/]\n");
        AnsiConsole.MarkupLine("[italic dim]Press Enter to continue...[/]");

        Console.ReadLine();
    }

    public void VehicleDisplayOperations()
    {


        bool isReturn = false;
        while (!isReturn)
        {
            var optionSelection = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("\nView all:")
            .AddChoices(new string[]
            {
                    "Customers",
                    "Cars",
                    "Bikes",
                    "Available cars",
                    "Available bikes",
                    "Rented cars",
                    "Rented bikes",
                    "Return"
            })
            );

            switch (optionSelection)
            {
                case "Customers":
                    _customerConsoleUI.DisplayAllCustomers();
                    break;
                case "Cars":
                    _vehicleQueryConsoleUI.DisplayAllCars();
                    break;
                case "Bikes":
                    _vehicleQueryConsoleUI.DisplayAllBikes();
                    break;
                case "Available cars":
                    _vehicleQueryConsoleUI.DisplayCarsByRentalStatus(false);
                    break;
                case "Available bikes":
                    _vehicleQueryConsoleUI.DisplayBikesByRentalStatus(false);
                    break;
                case "Rented cars":
                    _vehicleQueryConsoleUI.DisplayCarsByRentalStatus(true);
                    break;
                case "Rented bikes":
                    _vehicleQueryConsoleUI.DisplayBikesByRentalStatus(true);
                    break;
                case "Return":
                    isReturn = true;
                    break;
            }
        }

    }

    public void HandleCustomerOpertions()
    {
        bool isReturn = false;
        while (!isReturn)
        {
            var optionSelection = AnsiConsole.Prompt(
             new SelectionPrompt<string>()
             .Title("\nSelect an operation:")
             .AddChoices(new string[]
             {
                "Add new customer",
                "Remove existing customer",
                "Return"
             })
            );

            switch (optionSelection)
            {
                case "Add new customer":
                    _customerConsoleUI.AddInputCustomer();
                    break;
                case "Remove existing customer":
                    _customerConsoleUI.RemoveInputCustomer();
                    break;
                case "Return":
                    isReturn = true;
                    break;
            }

            _customerConsoleUI.DisplayAllCustomers();
        }

    }

    public void Run()
    {
        bool isQuit = false;

        while (!isQuit)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("\nSelect an option:")
                .AddChoices(new string[]
                {
                        "Vehicle display options",
                        "Customer operations",
                        "Send a message",
                        "Quit"
                })
            );

            switch (selection)
            {
                case "Vehicle display options":
                    VehicleDisplayOperations();
                    break;
                case "Customer operations":
                    HandleCustomerOpertions();
                    break;
                case "Send a message":
                    //
                    break;
                case "Quit":
                    isQuit = true;
                    break;
            }

        }
    }
}