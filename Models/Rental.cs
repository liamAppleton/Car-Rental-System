namespace rentalapp;

public class Rental
{
    public int RentalId { get; private set; }
    public int CustomerId { get; private set; }
    public Car? Car { get; private set; }
    public Bike? Bike { get; private set; }
    public DateOnly RentalStartDate { get; private set; }
    public DateOnly RentalEndDate { get; private set; }

    public Rental(int rentalId, int customerId, Car car, Bike bike, DateOnly rentalStartDate, DateOnly rentalEndDate)
    {
        RentalId = rentalId;
        CustomerId = customerId;
        Car = car;
        Bike = bike;
        RentalStartDate = rentalStartDate;
        RentalEndDate = rentalEndDate;
    }
}