#pragma checksum "C:\Users\H357358\source\repos\JewelleryShop\Views\Home\EstimatePopup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d67aaf41d782fd32f5842c4d88f9a59d14de8ab3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EstimatePopup), @"mvc.1.0.view", @"/Views/Home/EstimatePopup.cshtml")]
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
#line 1 "C:\Users\H357358\source\repos\JewelleryShop\Views\_ViewImports.cshtml"
using JewelleryShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\H357358\source\repos\JewelleryShop\Views\_ViewImports.cshtml"
using JewelleryShop.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\H357358\source\repos\JewelleryShop\Views\_ViewImports.cshtml"
using JewelleryShop.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d67aaf41d782fd32f5842c4d88f9a59d14de8ab3", @"/Views/Home/EstimatePopup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0377601b91e86a3495b2c395c548aecb7ff89df3", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EstimatePopup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EstimatePopupModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    
    <div class=""modal fade"" id=""showEstimate"">
        <div class=""modal-dialog modal-lg"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"">Estimate</h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"">
                        <span>x</span>
                    </button>
                </div>
                <div class=""modal-body"" id=""showestimatebody"">
                    ");
#nullable restore
#line 14 "C:\Users\H357358\source\repos\JewelleryShop\Views\Home\EstimatePopup.cshtml"
               Write(Model.ShowMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EstimatePopupModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
