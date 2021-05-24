using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Ado.Lib
{
    public class CustomerOperations
    {
        List<Customer> customerList = null;
        public CustomerOperations()
        {
            if(customerList == null )
            {
                customerList = new List<Customer>
                {
                    new Customer() { Id=1, Name ="Deepak", Address="Delhi", Qty=90},
                    new Customer() { Id=2, Name ="Ajay", Address="NDelhi", Qty=20},
                    new Customer() { Id=3, Name ="Sagar", Address="Calcutta", Qty=40},
                    new Customer() { Id=4, Name ="Deepak Garg", Address="ODelhi", Qty=90},
                    new Customer() { Id=5, Name ="Pradeep", Address="Bombay", Qty=90},
                    new Customer() { Id=6, Name ="Deepak", Address="Delhi", Qty=90}

                };

            }
        }
        public List<Customer> GetCustomers()
        {
            if (customerList != null)
            {
                return customerList;
            }
            else
                return null;
        }

        public bool AddCustomer(Customer customer)
        {
            
            if (customer != null)
            {
                customerList.Add(customer);
                return true;
            }
            else
                return false;
            
        }



        public bool UpdateCustomer(int id, string address, int qty)
        {
            bool isUpdated = false;
            foreach(Customer temp in customerList)
            {
                if(temp.Id== id)
                {
                    temp.Address = address;
                    temp.Qty = qty;
                    isUpdated = true;
                    break;
                }
               
            }
            return isUpdated;
        }

        public bool DeleteCustomer(int id)
        {

            bool isDeleted = false;
            foreach (Customer temp in customerList)
            {
                if (temp.Id == id)
                {
                    customerList.Remove(temp);
                    isDeleted = true;
                    break;
                }
                
            }
            return isDeleted;
        }


        public Customer FindCustomer(int id)
        {

            Customer customer = null;
            foreach (Customer temp in customerList)
            {
                if (temp.Id == id)
                {
                    customer = new Customer();
                    customer = temp;
                    break;

                }
            }
            return customer;
        }
    }
}
