#pragma checksum "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Add\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a93e92661c5df8e8623ab7d9b28915b4cdc074e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MultiShopAdmin_Views_Add_Detail), @"mvc.1.0.view", @"/Areas/MultiShopAdmin/Views/Add/Detail.cshtml")]
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
#line 3 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\_ViewImports.cshtml"
using Project_MVC.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\_ViewImports.cshtml"
using Project_MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\_ViewImports.cshtml"
using Project_MVC.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a93e92661c5df8e8623ab7d9b28915b4cdc074e", @"/Areas/MultiShopAdmin/Views/Add/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"122cb2f108d4a82b276030bdd0a764ab88af8a16", @"/Areas/MultiShopAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_MultiShopAdmin_Views_Add_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Add>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Add\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container bootdey\">\r\n<div class=\"col-md-12\">\r\n<section class=\"panel\">\r\n      <div class=\"panel-body\">\r\n          <div class=\"col-md-6\">\r\n              <h2>Add Detail</h2>\r\n              <h4>Id:");
#nullable restore
#line 12 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Add\Detail.cshtml"
                Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n              <div class=\"pro-img-details\">\r\n                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0a93e92661c5df8e8623ab7d9b28915b4cdc074e4449", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 350, "~/assets/img/", 350, 13, true);
#nullable restore
#line 14 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Add\Detail.cshtml"
AddHtmlAttributeValue("", 363, Model.Image, 363, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 14 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Add\Detail.cshtml"
AddHtmlAttributeValue("", 382, Model.Image, 382, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n              </div>\r\n              <br>\r\n          </div>\r\n          <div class=\"col-md-6\">\r\n              <h4 class=\"pro-d-title\">  \r\n                <strong>Title:</strong>");
#nullable restore
#line 20 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Add\Detail.cshtml"
                                  Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n              </h4>\r\n              <div class=\"product_meta\">\r\n                  <p class=\"posted_in\"> <strong>Discount:</strong> ");
#nullable restore
#line 23 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Add\Detail.cshtml"
                                                              Write(Model.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n              </div>\r\n          </div>\r\n      </div>\r\n  </section>\r\n  </div>\r\n  </div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Add> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
