#pragma checksum "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec427da0cbf4faed3e48b4b654e2eea3af37f8cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Details.cshtml", typeof(AspNetCore.Views_Product_Details))]
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
#line 1 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\_ViewImports.cshtml"
using Start;

#line default
#line hidden
#line 2 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\_ViewImports.cshtml"
using Start.Models;

#line default
#line hidden
#line 5 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
using Start.Models.Viewmodels;

#line default
#line hidden
#line 6 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
using System.IO;

#line default
#line hidden
#line 7 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
using System.Drawing;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec427da0cbf4faed3e48b4b654e2eea3af37f8cd", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b27c5daccd6be6cd39384be0392c9649397c9dc5", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDetailViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
  
    ViewData["Title"] = "Product details";
    Layout = "~/Views/Shared/_Layout.cshtml";
    

#line default
#line hidden
            BeginContext(220, 59, true);
            WriteLiteral("\r\n\r\n<div class=\"container-fluid col-md-offset-3\">\r\n    <h2>");
            EndContext();
            BeginContext(280, 10, false);
#line 13 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
   Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(290, 78, true);
            WriteLiteral("</h2>\r\n    <div class=\"row\">\r\n        <div class=\"col-xs-4\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 368, "\"", 392, 1);
#line 16 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
WriteAttributeValue("", 374, ViewBag.ImageData, 374, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(393, 133, true);
            WriteLiteral(" style=\"max-width:100%;\" />\r\n        </div>\r\n        <div class=\"col-xs-4\">\r\n            <h4>Current price:</h4>\r\n            <h4><b>");
            EndContext();
            BeginContext(527, 11, false);
#line 20 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
              Write(Model.Price);

#line default
#line hidden
            EndContext();
            BeginContext(538, 64, true);
            WriteLiteral("</b></h4>\r\n\r\n            <h4>Calories:</h4>\r\n            <h4><b>");
            EndContext();
            BeginContext(603, 14, false);
#line 23 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
              Write(Model.Calories);

#line default
#line hidden
            EndContext();
            BeginContext(617, 64, true);
            WriteLiteral("</b></h4>\r\n\r\n            <h4>Description:</h4>\r\n            <h4>");
            EndContext();
            BeginContext(682, 17, false);
#line 26 "C:\Users\Michael\Desktop\IB Project\IB_Project\Start\Views\Product\Details.cshtml"
           Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(699, 288, true);
            WriteLiteral(@"</h4>
        </div>
    </div>
    <div class=""col-md-3 col-md-offset-1"" style=""margin-top:40px;"">
        <button type=""button"" class=""btn btn-primary btn-lg btn-block"" style=""background-color:forestgreen""><i class=""fas fa-cart-plus""></i>  Add To Cart</button>
    </div>
</div>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDetailViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
