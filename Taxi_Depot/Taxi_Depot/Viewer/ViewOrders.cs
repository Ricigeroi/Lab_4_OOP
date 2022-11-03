using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi_depot.Meniu;

namespace Taxi_depot.Viewer
{
    internal class ViewOrders
    {
        public static void viewOrders(MenuItem menuItem)
        {
            if (Points.Actions[0].amount == 0)
            {
                int sum = 0;
                int sum_distance = 0;
                int expenses = 0;
                Console.Clear();
                Console.WriteLine("You have no actions points.");
                Console.WriteLine();
                foreach (Order item in Order.Orders)
                {
                    Console.WriteLine(item.inform());
                    sum += item.GetFare();
                    sum_distance += item.GetDistance();
                }
                foreach (Driver driver in Driver.Drivers)
                {
                    expenses += driver.salary * 50;
                }
                foreach (int fine in Points.Fines)
                {
                    expenses += fine;
                }
                Console.WriteLine("______________________________________________________________");
                Console.WriteLine("Earned today: " + sum + ". Passed km: " + sum_distance);
                Console.WriteLine("Expenses (salary + fines): " + expenses);
                Console.WriteLine("______________________________________________________________");
                Console.WriteLine("TOTAL: " + (sum - expenses));
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                if (Order.Orders.Count() != 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 15);
                    Points.Actions[0].spend();
                    foreach (Order order in Order.Orders)
                    {
                        Taxi taxi = Taxi.Taxis.Find(taxi => taxi.GetStatus() == order.GetId());
                        Driver driver = Driver.Drivers.Find(driver => driver.id_order == order.GetId());
                        Client client = Client.Clients.Find(client => client.GetId() == order.id_client);
                        if (order.progress < 100)
                        {
                            Console.WriteLine("___________________________________________________________________");
                            Console.WriteLine(order.inform());
                            if (client != null)
                            {
                                Console.WriteLine(client.Describe());
                            }
                            else
                            {
                                Console.WriteLine("Undefined client");
                            }
                            if (driver != null)
                            {
                                Console.WriteLine(driver.inform());
                            }
                            else
                            {
                                Console.WriteLine("Undefined driver");
                            }
                            if (taxi != null)
                            {
                                Console.WriteLine(taxi.Describe());
                            }
                            else
                            {
                                Console.WriteLine("Undefined car");
                            }
                            Console.WriteLine("___________________________________________________________________");
                        }
                    }
                }
            }
        }
       
    }
}
