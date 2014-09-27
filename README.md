Autocomplete plus datatables like plugin for MVC projects.

Built on MVC4+, Bootstrap and jQuery.UI.

Installation
-
Install datalist package from [NuGet] (http://nuget.org)
```
PM> Install-Package Datalist
```
Include style sheets
```html
<link href="~/Content/bootstrap.css" rel="stylesheet" />
<link href="~/Content/themes/base/jquery.ui.all.css" rel="stylesheet" />
<link href="~/Content/Datalist/datalist.css" rel="stylesheet" />
```
Render datalist partial before calling RenderBody in your _Layout.cshtml
```cshtml
@Html.Partial("_Datalist")
```
Include scripts
```html
<script src="~/Scripts/jquery-2.1.0.js" />
<script src="~/Scripts/jquery-ui-1.10.4.js" />
<script src="~/Scripts/Datalist/datalist.js" />
```
Implement data source method in DatalistController
```cs
public JsonResult Sample(DatalistFilter filter)
{
    return GetData(new SampleDatalist(), filter);
}
```
Render your datalist inputs using one of datalist's html helpers
```
@Html.DatalistFor(model => model.SampleId)

@Html.Datalist("SampleId", new SampleDatalist())

@Html.DatalistFor(model => model.SampleId, new SampleDatalist())
```

Examples and API documentation
--
Usage examples and API can be found at [Datalist] (http://non-factors.com/Datalist) website.
