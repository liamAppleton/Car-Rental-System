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
    private VehicleQueryConsoleUI<IRentalItem> _vehicleQueryConsoleUI
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
    public void Run()
    {



        bool isQuit = false;
        AnsiConsole.MarkupLine("[bold underline green]Welcome to Car Rental Enterprise[/]\n");
        AnsiConsole.MarkupLine("[blue]------------------------------------------[/]");
        AnsiConsole.MarkupLine("[yellow]Manage your fleet of cars and bikes seamlessly[/]");
        AnsiConsole.MarkupLine("[blue]------------------------------------------[/]\n");
        AnsiConsole.MarkupLine("[italic dim]Press Enter to continue...[/]");

        Console.ReadLine();

        while (!isQuit)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select an option:")
                .AddChoices(new string[]
                {
                        "Vehicle display options",
                        "Send a message"
                })
            );


            Console.WriteLine(selection);
            isQuit = true;
        }
    }
}