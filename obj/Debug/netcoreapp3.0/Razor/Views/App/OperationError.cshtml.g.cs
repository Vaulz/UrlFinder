#pragma checksum "C:\Programms\NetExamenam\Views\App\OperationError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71c48e02cf2a34fd479b6732a2161575ad3e27d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_App_OperationError), @"mvc.1.0.view", @"/Views/App/OperationError.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Programms\NetExamenam\Views\_ViewImports.cshtml"
using NetExamenam;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Programms\NetExamenam\Views\_ViewImports.cshtml"
using NetExamenam.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71c48e02cf2a34fd479b6732a2161575ad3e27d8", @"/Views/App/OperationError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a6809d0fe3a3e854b3876def4ff8921b1ba93da", @"/Views/_ViewImports.cshtml")]
    public class Views_App_OperationError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NetExamenam.Models.OperationErrorModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Programms\NetExamenam\Views\App\OperationError.cshtml"
  
    ViewData["Title"] = "OperationError";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>При выполнении операции произошла ошибка:</h1>\r\n<p>");
#nullable restore
#line 7 "C:\Programms\NetExamenam\Views\App\OperationError.cshtml"
Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\r\n<p>Попробуйте в следующий раз<p>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NetExamenam.Models.OperationErrorModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
