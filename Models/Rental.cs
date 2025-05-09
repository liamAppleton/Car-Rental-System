namespace rentalapp;

public class Rental
{
    public int RentalId { get; private set; }
    public int CustomerId { get; private set; }
    public int CarId { get; private set; }
    public DateOnly RentalStartDate { get; private set; }
    public DateOnly RentalEndDate { get; private set; }

    public Rental(int rentalId, int customerId, int carId, DateOnly rentalStartDate, DateOnly rentalEndDate)
    {
        RentalId = rentalId;
        CustomerId = customerId;
        CarId = carId;
        RentalStartDate = rentalStartDate;
        RentalEndDate = rentalEndDate;
    }
}