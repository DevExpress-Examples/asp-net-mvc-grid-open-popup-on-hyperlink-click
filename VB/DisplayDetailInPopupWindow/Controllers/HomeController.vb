Imports System.Web.Mvc
Imports DisplayDetailInPopupWindow.Models

Namespace DisplayDetailInPopupWindow.Controllers

    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Public Function MasterAction() As PartialViewResult
            Return PartialView("MasterViewPartial", GetCustomers())
        End Function

        <HttpPost>
        Public Function DetailPartialAction(ByVal _customerID As String) As PartialViewResult
            Return PartialView("DetailViewPartial", GetOrders(_customerID))
        End Function
    End Class
End Namespace
