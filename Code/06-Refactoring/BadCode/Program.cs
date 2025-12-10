namespace BadCode
{
    public class Program
    {

        static List<Order> allOrders = new List<Order>();
        static double vat = 0.20;
        static Dictionary<string, double> promoCodes = new Dictionary<string, double>()
    {
        {"PROMO10", 0.10},
        {"PROMO20", 0.20},
        {"VIP", 0.30}
    };

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("1 Add Order");
                Console.WriteLine("2 Show Total Price");
                Console.WriteLine("3 Exit");
                var c = Console.ReadLine();

                if (c == "1")
                {
                    var o = new Order();
                    o.id = allOrders.Count + 1;
                    o.Items = new List<OrderItem>();
                    Console.WriteLine("enter promo code or empty:");
                    o.promo = Console.ReadLine();

                    string name = "";
                    while (name != "0")
                    {
                        Console.WriteLine("product name or 0:");
                        name = Console.ReadLine();
                        if (name != "0")
                        {
                            Console.WriteLine("price:");
                            double p = double.Parse(Console.ReadLine());
                            Console.WriteLine("qty:");
                            int q = int.Parse(Console.ReadLine());
                            o.Items.Add(new OrderItem() { Name = name, Quantity = q, Price = p });
                        }
                    }

                    Console.WriteLine("discount (0 to 1):");
                    o.discount = double.Parse(Console.ReadLine());
                    allOrders.Add(o);
                    Console.WriteLine("order saved");
                }
                else if (c == "2")
                {
                    Console.WriteLine("order id:");
                    int id = int.Parse(Console.ReadLine());
                    double total = CalculatePrice(id);
                    Console.WriteLine("total: " + total);
                }
                else if (c == "3")
                {
                    return;
                }
            }
        }

        public static double CalculatePrice(int id)
        {
            Order o = null;
            foreach (var x in allOrders)
            {
                if (x.id == id)
                    o = x;
            }

            double t = 0;
            for (int i = 0; i < o.Items.Count; i++)
            {
                t += o.Items[i].Price * o.Items[i].Quantity;
            }

            if (o.discount > 0)
            {
                t = t - (t * o.discount);
            }

            if (o.promo != null && o.promo != "")
            {
                foreach (var kv in promoCodes)
                {
                    if (kv.Key == o.promo)
                    {
                        t = t - (t * kv.Value);
                    }
                }
            }

            t = t + (t * vat);

            return t;
        }
    }

    public class Order
    {
        public int id;
        public List<OrderItem> Items;
        public double discount;
        public string promo;
    }

    public class OrderItem
    {
        public string Name;
        public int Quantity;
        public double Price;
    }

}
