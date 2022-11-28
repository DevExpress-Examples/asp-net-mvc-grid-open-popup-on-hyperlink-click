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
