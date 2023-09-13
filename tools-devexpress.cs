// registrace NuGet feedu
nuget sources Add -Name "DevExpress NuGet Feed" -Source "https://nuget.devexpress.com/{authorization key}/api"

// nastavit NuGet v %AppData%\NuGet\NuGet.config
<configuration>
     <packageSources>
         ...
         <add key="DevExpress NuGet Feed"
              value="https://nuget.devexpress.com/{authorization key}/api" />
         <!-- or -->
         <add key="DevExtreme ASP.NET MVC Controls"
              value="%ProgramFiles%\DevExpress 23.1\DevExtreme\System\DevExtreme\Bin\AspNetCore" />
     </packageSources>
 </configuration>

 // přidat NuGet balíčky do projektu
dotnet add package DevExtreme.AspNet.Data
dotnet add package -v 23.1.3 DevExtreme.AspNet.Core

// client side balíčky
npm: https://www.npmjs.com
libman: https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli

// instalovat node.js
https://nodejs.org/en

// instalovat DevExtreme
npm init -y
npm i devextreme-dist@23.1 devextreme-aspnet-data

// instalovat libman
dotnet tool install -g Microsoft.Web.LibraryManager.Cli

// libman.json
{
    "version": "1.0",
    "defaultProvider": "cdnjs",
    "libraries": [
        {
            // add this file if your project does not include it yet
            "library": "jquery@3.5.1",
            "provider": "cdnjs",
            "destination": "wwwroot/js/devextreme",
            "files": [
                "jquery.js"
            ]
        },
        {
            "library": "cldrjs@0.5.1",
            "provider": "cdnjs",
            "destination": "wwwroot/js/devextreme/"
        },
        {
            "library": "globalize@1.4.2",
            "provider": "cdnjs",
            "destination": "wwwroot/js/devextreme/"
        },
        {
            // required for client-side export
            "library": "jszip@3.2.1",
            "provider": "cdnjs",
            "destination": "wwwroot/js/devextreme/"
        },
        {
            "library": "node_modules/devextreme-dist/js/",
            "provider": "filesystem",
            "destination": "wwwroot/js/devextreme/"
        },
        {
            // required if you set up localization
            "library": "node_modules/devextreme-dist/js/localization/",
            "provider": "filesystem",
            "destination": "wwwroot/js/devextreme/localization"
        },
        {
            // required if you use a VectorMap control
            "library": "node_modules/devextreme-dist/js/vectormap-data/",
            "provider": "filesystem",
            "destination": "wwwroot/js/devextreme/vectormap-data"
        },
        {
            "library": "node_modules/devextreme-dist/css/dx.light.css",
            "provider": "filesystem",
            "destination": "wwwroot/css/devextreme/"
        },
        {
            "library": "node_modules/devextreme-dist/css/icons/",
            "provider": "filesystem",
            "destination": "wwwroot/css/devextreme/icons"
        },
        {
            // required if you use one of the Material Design Themes
            "library": "node_modules/devextreme-dist/css/fonts/",
            "provider": "filesystem",
            "destination": "wwwroot/css/devextreme/fonts"
        },
        {
            "library": "node_modules/devextreme-aspnet-data/js/dx.aspnet.data.js",
            "provider": "filesystem",
            "destination": "wwwroot/js/devextreme"
        }
    ]
}

// restore libman balíčků
libman restore

// aktualizace _Layout.cshtml
<head>
    ...
    @* Uncomment to use the HtmlEditor control *@
    @* <script src="https://unpkg.com/devextreme-quill/dist/dx-quill.min.js"></script> *@

    @* Uncomment to use the Gantt control *@ 
    @*<link href="~/css/devextreme/dx-gantt.css" rel="stylesheet" />*@

    @* Uncomment to use the Diagram control *@
    @*<link href="~/css/devextreme/dx-diagram.css" rel="stylesheet" />*@

    <link href="~/css/devextreme/dx.light.css" rel="stylesheet" />

    @* Uncomment to use the Gantt control *@ 
    @*<script src="~/js/devextreme/dx-gantt.js"></script>*@

    @* Uncomment to use the Diagram control *@
    @*<script src="~/js/devextreme/dx-diagram.js"></script>*@

    <script src="~/js/devextreme/jquery.js"></script>

    @* Uncomment to use Globalize for localization *@
    @*<script src="~/js/devextreme/cldr.js"></script>*@
    @*<script src="~/js/devextreme/cldr/event.js"></script>*@
    @*<script src="~/js/devextreme/cldr/supplemental.js"></script>*@
    @*<script src="~/js/devextreme/cldr/unresolved.js"></script>*@
    @*<script src="~/js/devextreme/globalize.js"></script>*@
    @*<script src="~/js/devextreme/globalize/message.js"></script>*@
    @*<script src="~/js/devextreme/globalize/number.js"></script>*@
    @*<script src="~/js/devextreme/globalize/currency.js"></script>*@
    @*<script src="~/js/devextreme/globalize/date.js"></script>*@

    @* Uncomment to enable client-side export *@
    @*<script src="~/js/devextreme/jszip.js"></script>*@

    <script src="~/js/devextreme/dx.all.js"></script>

    @* Uncomment to provide geo-data for the VectorMap control *@
    @*<script src="~/js/devextreme/vectormap-data/world.js"></script>*@

    <script src="~/js/devextreme/dx.aspnet.mvc.js"></script> 
    <script src="~/js/devextreme/dx.aspnet.data.js"></script>
</head>

// importovat namespace do _ViewImports.cshtml
@using DevExtreme.AspNet.Mvc

// nastavit JSON serializer
services.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

// povolit controllery i u Razor Pages
app.MapControllers();