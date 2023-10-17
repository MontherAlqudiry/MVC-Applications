﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"dependencies": {
    "Microsoft.AspNetCore.Diagnostics": "1.0.0",
        "Microsoft.AspNetCore.Mvc": "1.0.1",
            "Microsoft.AspNetCore.Razor.Tools": {
        "version": "1.0.0-preview2-final",
            "type": "build"
    };
    "Microsoft.AspNetCore.Routing": "1.0.1",
        "Microsoft.AspNetCore.Server.IISIntegration": "1.0.0",
            "Microsoft.AspNetCore.Server.Kestrel": "1.0.1",
                "Microsoft.AspNetCore.StaticFiles": "1.0.0",
                    "Microsoft.Extensions.Configuration.EnvironmentVariables": "1.0.0",
                        "Microsoft.Extensions.Configuration.Json": "1.0.0",
                            "Microsoft.Extensions.Logging": "1.0.0",
                                "Microsoft.Extensions.Logging.Console": "1.0.0",
                                    "Microsoft.Extensions.Logging.Debug": "1.0.0",
                                        "Microsoft.Extensions.Options.ConfigurationExtensions": "1.0.0",
                                            "Microsoft.VisualStudio.Web.BrowserLink.Loader": "14.0.0"
},

"tools": {
    "BundlerMinifier.Core": "2.0.238",
        "Microsoft.AspNetCore.Razor.Tools": "1.0.0-preview2-final",
            "Microsoft.AspNetCore.Server.IISIntegration.Tools": "1.0.0-preview2-final"
},

"frameworks": {
    "net452": { }
};

"buildOptions": {
    "emitEntryPoint": true,
        "preserveCompilationContext": true
},

"publishOptions": {
    "include": [
        "wwwroot",
        "**/*.cshtml",
        "appsettings.json",
        "web.config"
    ]
},

"scripts": {
    "prepublish": ["bower install", "dotnet bundle"],
        "postpublish": ["dotnet publish-iis --publish-folder %publish:OutputPath% --framework %publish:FullTargetFramework%"]
}
}