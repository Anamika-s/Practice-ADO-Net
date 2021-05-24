using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Cts.Ado.Lib.Customer customer = new Cts.Ado.Lib.Customer();
            // List<Cts.Ado.Lib.Customer> customerList = new List<Cts.Ado.Lib.Customer>();
            // Cts.Ado.Lib.CustomerOperations customerOperations = new Cts.Ado.Lib.CustomerOperations();
            // customerList = customerOperations.GetCustomers();
            //foreach(Cts.Ado.Lib.Customer customer in customerList)
            // {
            //     Console.WriteLine(customer.Id + "\t" + customer.Name);
            // }


            // Cts.Ado.Lib.Customer customer = new Cts.Ado.Lib.Customer();
            List<Cts.Ado.Demo.Customer> customerList = new List<Cts.Ado.Demo.Customer>();
            Cts.Ado.Demo.CustomerOperations customerOperations = new Cts.Ado.Demo.CustomerOperations();
            customerList = customerOperations.GetCustomers();
            if (customerList != null)
            {
                foreach (Cts.Ado.Demo.Customer temp in customerList)
                {
                    Console.WriteLine(temp.Id + "\t" + temp.Name);
                }
            }
            else

                Console.WriteLine("No Record");

            Console.WriteLine("Enter ID");
            int id =  int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Quantity");
            int qty = int.Parse(Console.ReadLine());
            bool isInserted = customerOperations.InsertCustomer(id, name, address, qty);
            if (isInserted == true) Console.WriteLine("Record Inserted");
            else Console.WriteLine("Record Not Inserted");



            // Updattion

            Console.WriteLine("Enter ID whode Record to update");
              id = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter Address");
              address = Console.ReadLine();
            Console.WriteLine("Enter Quantity");
            qty = int.Parse(Console.ReadLine());
             bool isUpdated = customerOperations.UpdateCustomer(id, address, qty);
            if (isUpdated == true) Console.WriteLine("Record updated");
            else Console.WriteLine("Record Not updated");



            // Deletion

            Console.WriteLine("Enter ID whode Record to delete");
            id = int.Parse(Console.ReadLine());

            
            bool isDeleted = customerOperations.DeleteCustomer(id);
            if (isDeleted == true) Console.WriteLine("Record deleted");
            else Console.WriteLine("Record Not deleted");

            // Find Customer By Id

            Console.WriteLine("Enter ID whode Record to find");
            id = int.Parse(Console.ReadLine());

            Cts.Ado.Demo.Customer customer = customerOperations.FindCustomerById(id);
            if(customer!=null)
            {
                Console.WriteLine("Record Found");
                Console.WriteLine(customer.Id + "\t" + customer.Name + "\t" + customer.Address+ "\t" + customer.Qty);
            }
            else
                Console.WriteLine("Customer with {0} id does not exist" , id);


        }
    }
}
