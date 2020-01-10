using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS8___Bank_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //number of people and time until close
            string[] inputSplit = input.Split(' ');

            List<Customer> customerList = new List<Customer>();

            //add all customers to customerList
            for (int i = 0; i < int.Parse(inputSplit[0]); i++)
            {
                string newCustomer = Console.ReadLine();
                string[] newCustomerData = newCustomer.Split(' ');
                customerList.Add(new Customer(int.Parse(newCustomerData[0]), int.Parse(newCustomerData[1])));
            }

            customerList = customerList.OrderByDescending(m => m.money).ToList();
            List<int> servedList = new List<int>(int.Parse(inputSplit[1]));
            for (int i = 0; i < int.Parse(inputSplit[1]); i++)
            {
                servedList.Add(0);
            }

            for (int i = 0; i < customerList.Count; i++)
            {
                int customerTime = customerList[i].time;
                for (int j = customerTime; j >= 0 ; j--)
                {
                    if (servedList[j] == 0)
                    {
                        servedList[j] = customerList[i].money;
                        break;
                    }
                }
            }

            Console.WriteLine(servedList.Sum());
        }

        class Customer
        {
            public int money;
            public int time;

            public Customer(int m, int t)
            {
                time = t;
                money = m;
            }
        }
    }
}
