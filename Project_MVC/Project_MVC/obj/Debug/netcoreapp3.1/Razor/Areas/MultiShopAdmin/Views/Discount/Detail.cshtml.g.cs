#pragma checksum "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d18252110b96b490c9d60bbc791a69572f62e0ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MultiShopAdmin_Views_Discount_Detail), @"mvc.1.0.view", @"/Areas/MultiShopAdmin/Views/Discount/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d18252110b96b490c9d60bbc791a69572f62e0ac", @"/Areas/MultiShopAdmin/Views/Discount/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"122cb2f108d4a82b276030bdd0a764ab88af8a16", @"/Areas/MultiShopAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_MultiShopAdmin_Views_Discount_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Discount>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("h6 text-decoration-none text-truncate"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container bootdey\">\r\n<div class=\"col-md-12\">\r\n<section class=\"panel\">\r\n      <div class=\"panel-body\">\r\n          <div class=\"col-md-6\">\r\n              <h2>Discount Detail</h2>\r\n              <h4>Id:");
#nullable restore
#line 13 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n              <br>\r\n          </div>\r\n          <div class=\"col-md-6\">\r\n              <h4 class=\"pro-d-title\">  \r\n                <strong>Name:</strong>");
#nullable restore
#line 18 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                                 Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n              </h4>\r\n              <div class=\"product_meta\">\r\n                  <p class=\"posted_in\"> <strong>Products:</strong>  ");
#nullable restore
#line 21 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                                                                Write(Model.Products==null?0:Model.Products.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                  <div class=\"main d-flex\">\r\n");
#nullable restore
#line 23 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                       if (Model.Products!=null)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                                 foreach (Product product in Model.Products){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg-3 col-md-4 col-sm-6 pb-1\">\r\n            <div class=\"product-item bg-light mb-4\">\r\n                <div class=\"product-img position-relative overflow-hidden\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d18252110b96b490c9d60bbc791a69572f62e0ac7818", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1080, "~/assets/img/", 1080, 13, true);
#nullable restore
#line 29 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
AddHtmlAttributeValue("", 1093, product.ProductImages.FirstOrDefault(p=>p.Primary==true)?.Name, 1093, 63, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 29 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
AddHtmlAttributeValue("", 1163, product.Name, 1163, 13, false);

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
            WriteLiteral("\r\n                </div>\r\n                <div class=\"text-center py-4\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d18252110b96b490c9d60bbc791a69572f62e0ac10098", async() => {
#nullable restore
#line 32 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                                                                                                                                        Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                                                                                                                    WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <div class=\"d-flex align-items-center justify-content-center mt-2\">\r\n                        <h5>$");
#nullable restore
#line 34 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                        Write(product.CheckDiscount());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5><h6 class=\"text-muted ml-2\"><del>$");
#nullable restore
#line 34 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
                                                                                       Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</del></h6>
                    </div>
                    <div class=""d-flex align-items-center justify-content-center mb-1"">
                        <small class=""fa fa-star text-primary mr-1""></small>
                        <small class=""fa fa-star text-primary mr-1""></small>
                        <small class=""fa fa-star text-primary mr-1""></small>
                        <small class=""fa fa-star text-primary mr-1""></small>
                        <small class=""fa fa-star text-primary mr-1""></small>
                        <small>(99)</small>
                    </div>
                </div>
            </div>
        </div>
");
#nullable restore
#line 47 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Discount\Detail.cshtml"
 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                  </div>\r\n              </div>\r\n          </div>\r\n      </div>\r\n  </section>\r\n  </div>\r\n  </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Discount> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
