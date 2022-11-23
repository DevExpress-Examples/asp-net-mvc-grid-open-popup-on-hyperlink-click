# GridView for ASP.NET MVC - How to Open a Popup Window on a Hyperlink Click

<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e20052/)**
<!-- run online end -->

This example demonstrates how to open a popup dialog when a user clicks a hyperlink in the grid's column.

![GridView for MVC - PopupHyperlink](images/PopupHyperlink.png)

## Setup Master and Detail Grid Views

Define master and detail GridView settings in separate PartialView files and specify their [CallbackRouteValues](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.AutoCompleteBoxBaseSettings.CallbackRouteValues) properties.

```xml
// MasterViewPartial.cshtml
@Html.DevExpress().GridView(settings => {
    settings.Name = "masterGrid";
    settings.CallbackRouteValues = new { Controller = "Home", Action = "MasterAction" };
    settings.KeyFieldName = "CustomerID";
    settings.Columns.Add(col => {
        col.FieldName = "CustomerID";
        col.SetDataItemTemplateContent(container => {
            Html.DevExpress().HyperLink(hlSettings => {
                hlSettings.Name = string.Format("hl_{0}", (container as GridViewDataItemTemplateContainer).VisibleIndex);
                hlSettings.NavigateUrl = "javascript:void(0)";
                hlSettings.Properties.ClientSideEvents.Click = string.Format("function(s, e) {{ OnHyperLinkClick('{0}'); }}", (container as GridViewDataItemTemplateContainer).KeyValue.ToString());
                hlSettings.Properties.Text = "Show Orders";
            }).Render();
        });
    });
    ...
}).Bind(Model).GetHtml()

// DetailViewPartial.cshtml
@Html.DevExpress().GridView(settings => {
    settings.Name = "detailGrid";
    settings.CallbackRouteValues = new { Controller = "Home", Action = "DetailPartialAction" };
    settings.KeyFieldName = "OrderID";
    ...
    settings.ClientSideEvents.BeginCallback = "OnDetailGridBeginCallback";
    settings.ClientSideEvents.EndCallback = "OnDetailGridEndCallback";
}).Bind(Model).GetHtml()
```

## Show the Popup on the Detail Grid View Callback

In the hyperlink's `Click` event handler, send a callback to the detail grid. Pass the row's key value to the server and show the popup window on the detail grid's callback.

```js
// JSCustom.js
var currentCustomerID;
function OnHyperLinkClick(customerID) {
    currentCustomerID = customerID;
    detailGrid.PerformCallback();
}
function OnDetailGridBeginCallback(s, e) {
    e.customArgs["_customerID"] = currentCustomerID;
}
function OnDetailGridEndCallback(s, e) {
    if (!popup.IsVisible()) 
        popup.Show();
}
```

```xml
// DetailViewPartial.cshtml
@Html.DevExpress().GridView(settings => {
    ...
    settings.ClientSideEvents.BeginCallback = "OnDetailGridBeginCallback";
    settings.ClientSideEvents.EndCallback = "OnDetailGridEndCallback";
```

## Specify the Popup's Content

Define the popup window settings and call the [SetContent](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.MVCxPopupWindow.SetContent.overloads) method to render the popup's content.

```xml
// Index.cshtml
@Html.DevExpress().PopupControl(settings => {
    settings.Name = "popup";
    settings.Width = System.Web.UI.WebControls.Unit.Pixel(800);
    settings.Height = System.Web.UI.WebControls.Unit.Pixel(400);
    settings.SetContent(() => {
        Html.RenderPartial("DetailViewPartial", null);
    });
}).GetHtml()

// HomeController.cs
public PartialViewResult DetailPartialAction(string _customerID) {
    return PartialView("DetailViewPartial", OrderRepository.GetOrders(_customerID));
}
```

## Files to Look At

* [HomeController.cs](./CS/DisplayDetailInPopupWindow/Controllers/HomeController.cs)
* [JSCustom.js](./CS/DisplayDetailInPopupWindow/Scripts/JSCustom.js)
* [Index.cshtml](./CS/DisplayDetailInPopupWindow/Views/Home/Index.cshtml)
* [DetailViewPartial.cshtml](./CS/DisplayDetailInPopupWindow/Views/Shared/DetailViewPartial.cshtml)
* [MasterViewPartial.cshtml](./CS/DisplayDetailInPopupWindow/Views/Shared/MasterViewPartial.cshtml)

## Documentation

- [CallbackRouteValues](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.AutoCompleteBoxBaseSettings.CallbackRouteValues)
- [SetContent](https://docs.devexpress.com/AspNetMvc/DevExpress.Web.Mvc.MVCxPopupWindow.SetContent.overloads)

## More Examples

- [Grid View for ASP.NET MVC - How to Use ContentUrl to Display Detail Data within a Popup Window](https://github.com/DevExpress-Examples/how-to-display-detail-data-within-a-popup-window-using-contenturl-mvc-e20051)
- [Grid View for ASP.NET Web Forms - How to Display a Popup Dialog When a User Clicks a Link in a Grid Row](https://github.com/DevExpress-Examples/aspxgridview-display-popup-when-user-clicks-cell-link)
