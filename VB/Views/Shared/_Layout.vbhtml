<!DOCTYPE HTML>

<html>
<head>
    <title>@ViewData("Title")</title>
    <script src="@Url.Content("~/Scripts/JSCustom.js")" type="text/javascript"></script>
    @Html.DevExpress().GetStyleSheets(
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}, 
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.PivotGrid}, 
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor}, 
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors}, 
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, 
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.Chart}, 
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report},
	New StyleSheet With {.ExtensionSuite = ExtensionSuite.Scheduler})
@Html.DevExpress().GetScripts(
	New Script With {.ExtensionSuite = ExtensionSuite.GridView}, 
	New Script With {.ExtensionSuite = ExtensionSuite.PivotGrid}, 
	New Script With {.ExtensionSuite = ExtensionSuite.HtmlEditor}, 
	New Script With {.ExtensionSuite = ExtensionSuite.Editors}, 
	New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, 
	New Script With {.ExtensionSuite = ExtensionSuite.Chart}, 
	New Script With {.ExtensionSuite = ExtensionSuite.Report},
	New Script With {.ExtensionSuite = ExtensionSuite.Scheduler})
</head>

<body>
    @RenderBody()
</body>
</html>