using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Ado.Lib
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Address { get; set; }
        public int Qty { get; set; }

        public Customer()
        {

        }
        public Customer (int id, string name, string address , int qty)
        {
            Id = id;
            Name = name;
            Address = address;
            Qty = qty;
        }
        //int id;
        //public int Id
        //{
        //    get { return id; }
        //    set { id = value; }
        //}

        //string name;
        //public string Name
        //{
        //    get { return name; }
        //set { name = value; }
        //}
        //string address;
        //public string Address
        //{
        //    get { return address; }
        //    set { address = value; }
        //}
        //int qty;
        //public int Qty
        //{
        //    get { return qty; }
        //    set { qty = value; }

        //}

    }
}
