Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.OleDb
Imports System.Data

Namespace DisplayDetailInPopupWindow.Models
	Public Class ConnectionRepository
		Public Shared Function GetDataConnection() As OleDbConnection
			Dim connection As OleDbConnection = New OleDbConnection()
			connection.ConnectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Server.MapPath("~/App_Data/data.mdb"))
			Return connection
		End Function
	End Class
	Public Class CustomerRepository
		Private Sub New()
		End Sub
		Public Shared Function GetCustomers() As DataTable
			Dim dataTableCustomers As DataTable = New DataTable()
			Using connection As OleDbConnection = ConnectionRepository.GetDataConnection()
				Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(String.Empty, connection)
				adapter.SelectCommand.CommandText = "SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [Country], [City] FROM [Customers]"
				adapter.Fill(dataTableCustomers)
			End Using
			Return dataTableCustomers
		End Function
	End Class
	Public Class OrderRepository
		Private Sub New()
		End Sub
		Public Shared Function GetOrders(ByVal _customerID As String) As DataTable
			Dim dataTableOrders As DataTable = New DataTable()
			Using connection As OleDbConnection = ConnectionRepository.GetDataConnection()
				Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(String.Empty, connection)
				adapter.SelectCommand.CommandText = String.Format("SELECT [OrderID], [CustomerID], [Freight], [ShipName], [ShipAddress], [ShipCity], [ShipCountry], [ShipPostalCode], [ShippedDate] FROM [Orders] WHERE [CustomerID] = '{0}'", _customerID)
				adapter.Fill(dataTableOrders)
			End Using
			Return dataTableOrders
		End Function
	End Class
End Namespace