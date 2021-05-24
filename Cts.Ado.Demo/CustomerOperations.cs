using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Step 1
using System.Data.SqlClient;
using System.Configuration;

namespace Cts.Ado.Demo
{
    public class CustomerOperations
    {
        // Step2 
        SqlConnection sqlConnection = null;

        // Step 3
        SqlCommand sqlCommand = null;
        //public CustomerOperations()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["customerConnection"].ToString();
        //    sqlConnection = new SqlConnection(connectionString);
        //}
        public SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["customerConnection"].ToString();
            sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }




        List<Customer> customerList = null;
         public List<Customer> GetCustomers()
        {
            using (sqlConnection = GetConnection())
            {
                using (sqlCommand = new SqlCommand("Select * from customers", sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)

                    {
                        customerList = new List<Customer>();
                        while (reader.Read())
                        {
                            Customer customer = new Customer();
                            customer.Id = (int)reader["id"];
                            customer.Name = reader["name"].ToString();
                            customer.Address = reader["address"].ToString();
                            customer.Qty = (int)reader["qty"];
                            customerList.Add(customer);
                        }

                    }
                    reader.Close();
                    sqlConnection.Close();
                    return customerList;

                }
            }
            if (customerList.Count == 0)
                return null;
            //sqlCommand.Dispose();
            //sqlConnection.Dispose();
            }

        public bool InsertCustomer(int id, string name, string address, int qty)
        {
            using(sqlConnection = GetConnection())
            {
                using (sqlCommand = new SqlCommand("Insert into customers(id, name, address, qty) values (@id,@name,@address,@qty)", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@address", address);
                    sqlCommand.Parameters.AddWithValue("@qty", qty);
                    sqlConnection.Open();
                    int count = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                
                     if (count > 0) return true;
                        else return false;
                }

            }
        }



        public bool UpdateCustomer(int id, string address, int qty)
        {
            using (sqlConnection = GetConnection())
            {
                using (sqlCommand = new SqlCommand("Update customers set address=@address , qty=@qty where id=@id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@address", address);
                    sqlCommand.Parameters.AddWithValue("@qty", qty);
                    sqlConnection.Open();
                    int count = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (count > 0) return true;
                    else return false;
                }

            }
        }


        public bool DeleteCustomer(int id)
        {
            using (sqlConnection = GetConnection())
            {
                using (sqlCommand = new SqlCommand("Delete customers where id=@id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                     
                    sqlConnection.Open();
                    int count = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (count > 0) return true;
                    else return false;
                }

            }
        }

        public Customer FindCustomer(int id)
        {
            Customer customer = null;
            using (sqlConnection = GetConnection())
            {
                using (sqlCommand = new SqlCommand("Select * from customers where id=@id", sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        customer = new Customer();
                        customer.Id = (int)reader["id"];
                        customer.Name = reader["name"].ToString();
                        customer.Address = reader["address"].ToString();
                        customer.Qty = (int)reader["qty"];
                    }
                    sqlConnection.Close();
                }
            }
                    return customer;
                }

            }
    }

