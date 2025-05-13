namespace rentalapp;

public class Rental
{
    public Guid RentalId { get; private set; }
    public Guid CustomerId { get; private set; }
    public Car? Car { get; private set; }
    public Bike? Bike { get; private set; }
    public DateOnly RentalStartDate { get; private set; }
    public DateOnly RentalEndDate { get; private set; }

    public Rental(Guid rentalId, Guid customerId, Car car, Bike bike, DateOnly rentalStartDate, DateOnly rentalEndDate)
    {
        RentalId = rentalId;
        CustomerId = customerId;
        Car = car;
        Bike = bike;
        RentalStartDate = rentalStartDate;
        RentalEndDate = rentalEndDate;
    }
}