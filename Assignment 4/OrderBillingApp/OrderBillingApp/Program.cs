using OrderBillingApp.Services;

namespace OrderBillingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderBillingService service =
                new OrderBillingService();

            decimal subTotal =
                service.CalculateSubTotal(1000, 5);

            Console.WriteLine("Sub Total : " + subTotal);

            decimal discount =
                service.CalculateDiscount(subTotal);

            Console.WriteLine("Discount : " + discount);

            decimal finalAmount =
                service.CalculateFinalAmount(1000, 5);

            Console.WriteLine("Final Amount : " + finalAmount);

            Console.ReadLine();
        }
    }
}
