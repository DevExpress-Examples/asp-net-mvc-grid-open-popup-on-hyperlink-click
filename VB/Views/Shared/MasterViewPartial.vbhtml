@ModelType System.Data.DataTable
@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "masterGrid"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "MasterAction"}
            settings.KeyFieldName = "CustomerID"
            settings.Columns.Add(
                Sub(col)
                        col.FieldName = "CustomerID"
                        col.SetDataItemTemplateContent(
                              Sub(container)
                                  Html.DevExpress().HyperLink(
                                     Sub(hlSettings)
                                             hlSettings.Name = String.Format("hl_{0}", TryCast(container, GridViewDataItemTemplateContainer).VisibleIndex)
                                             hlSettings.NavigateUrl = "javascript:void(0)"
                                             hlSettings.Properties.ClientSideEvents.Click = string.Format("function(s, e) {{ OnHyperLinkClick('{0}'); }}", TryCast(container, GridViewDataItemTemplateContainer).KeyValue.ToString())
                                             hlSettings.Properties.Text = "Show Orders"
                                     End Sub).Render()
                              End Sub)
                End Sub)
            settings.Columns.Add("CompanyName")
            settings.Columns.Add("ContactName")
            settings.Columns.Add("ContactTitle")
            settings.Columns.Add("Address")
            settings.Columns.Add("Country")
            settings.Columns.Add("City")
End Sub
).Bind(Model).GetHtml()
