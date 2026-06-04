using SmartCourierApp.Models;
using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Notifications;
using SmartCourierApp.Invoices;
using SmartCourierApp.Services;

Console.WriteLine("=== Smart Courier Booking System ===");

Console.Write("Enter Customer Name: ");
string name = Console.ReadLine();

Console.Write("Enter Customer Email: ");
string email = Console.ReadLine();

Console.Write("Enter Mobile Number: ");
string mobile = Console.ReadLine();

Console.Write("Enter Parcel Weight: ");
double weight = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter Source City: ");
string source = Console.ReadLine();

Console.Write("Enter Destination City: ");
string destination = Console.ReadLine();

Console.WriteLine("Select Delivery Type");
Console.WriteLine("1. Standard");
Console.WriteLine("2. Express");
Console.WriteLine("3. International");

int deliveryChoice = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Select Notification Type");
Console.WriteLine("1. Email");
Console.WriteLine("2. SMS");
Console.WriteLine("3. WhatsApp");

int notificationChoice = Convert.ToInt32(Console.ReadLine());

Customer customer = new Customer
{
    Name = name,
    Email = email,
    Mobile = mobile
};

Parcel parcel = new Parcel
{
    Weight = weight,
    SourceCity = source,
    DestinationCity = destination
};

CourierBooking booking = new CourierBooking
{
    Customer = customer,
    Parcel = parcel
};

IDeliveryChargeCalculator calculator;
string deliveryType;

switch (deliveryChoice)
{
    case 1:
        calculator = new StandardDeliveryCalculator();
        deliveryType = "Standard";
        break;

    case 2:
        calculator = new ExpressDeliveryCalculator();
        deliveryType = "Express";
        break;

    default:
        calculator = new InternationalDeliveryCalculator();
        deliveryType = "International";
        break;
}

booking.DeliveryType = deliveryType;

INotificationService notification;

switch (notificationChoice)
{
    case 1:
        notification = new EmailNotificationService();
        break;

    case 2:
        notification = new SmsNotificationService();
        break;

    default:
        notification = new WhatsAppNotificationService();
        break;
}

IInvoiceGenerator invoice = new ConsoleInvoiceGenerator();

CourierBookingService service =
    new CourierBookingService(
        calculator,
        notification,
        invoice);

service.BookCourier(booking);

Console.ReadLine();