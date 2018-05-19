using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace DisplayDetailInPopupWindow.Models {
    public class ConnectionRepository {
        public static OleDbConnection GetDataConnection() {
            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/data.mdb"));
            return connection;
        }
    }
    public static class CustomerRepository {
        public static DataTable GetCustomers() {
            DataTable dataTableCustomers = new DataTable();
            using (OleDbConnection connection = ConnectionRepository.GetDataConnection()) {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = "SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [Country], [City] FROM [Customers]";
                adapter.Fill(dataTableCustomers);
            }
            return dataTableCustomers;
        }
    }
    public static class OrderRepository {
        public static DataTable GetOrders(string _customerID) {
            DataTable dataTableOrders = new DataTable();
            using (OleDbConnection connection = ConnectionRepository.GetDataConnection()) {
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Empty, connection);
                adapter.SelectCommand.CommandText = string.Format("SELECT [OrderID], [CustomerID], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipCountry], [ShipPostalCode], [ShippedDate] FROM [Orders] WHERE [CustomerID] = '{0}'", _customerID);
                adapter.Fill(dataTableOrders);
            }
            return dataTableOrders;
        }
    }
}