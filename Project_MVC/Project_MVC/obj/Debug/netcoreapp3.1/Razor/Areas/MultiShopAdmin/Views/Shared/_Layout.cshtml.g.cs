#pragma checksum "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56c3fcce910af08f59f79f8291c6be2a8f4be3f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_MultiShopAdmin_Views_Shared__Layout), @"mvc.1.0.view", @"/Areas/MultiShopAdmin/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56c3fcce910af08f59f79f8291c6be2a8f4be3f1", @"/Areas/MultiShopAdmin/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea1790e75319fd184e03cf80992fdd985ac13427", @"/Areas/MultiShopAdmin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_MultiShopAdmin_Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/vendors/mdi/css/materialdesignicons.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/vendors/base/vendor.bundle.base.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/vendors/datatables.net-bs4/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/css/style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("shortcut icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/images/favicon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/images/logo.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/images/logo-mini.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/images/faces/face4.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profile-pic"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/images/faces/face2.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/images/faces/face3.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/images/faces/face5.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("profile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56c3fcce910af08f59f79f8291c6be2a8f4be3f19918", async() => {
                WriteLiteral("\r\n  <!-- Required meta tags -->\r\n  <meta charset=\"utf-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n  <title>Majestic Admin</title>\r\n  <!-- plugins:css -->\r\n  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "56c3fcce910af08f59f79f8291c6be2a8f4be3f110398", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "56c3fcce910af08f59f79f8291c6be2a8f4be3f111576", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n  <!-- endinject -->\r\n  <!-- plugin css for this page -->\r\n  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "56c3fcce910af08f59f79f8291c6be2a8f4be3f112817", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n  <!-- End plugin css for this page -->\r\n  <!-- inject:css -->\r\n  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "56c3fcce910af08f59f79f8291c6be2a8f4be3f114063", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n  <!-- endinject -->\r\n  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "56c3fcce910af08f59f79f8291c6be2a8f4be3f115265", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56c3fcce910af08f59f79f8291c6be2a8f4be3f117148", async() => {
                WriteLiteral(@"
  <div class=""container-scroller"">
    
    <!-- partial:partials/_navbar.html -->
    <nav class=""navbar col-lg-12 col-12 p-0 fixed-top d-flex flex-row"">
      <div class=""navbar-brand-wrapper d-flex justify-content-center"">
        <div class=""navbar-brand-inner-wrapper d-flex justify-content-between align-items-center w-100"">  
          <a class=""navbar-brand brand-logo"" href=""index.html"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "56c3fcce910af08f59f79f8291c6be2a8f4be3f117820", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</a>\r\n          <a class=\"navbar-brand brand-logo-mini\" href=\"index.html\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "56c3fcce910af08f59f79f8291c6be2a8f4be3f119070", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"</a>
          <button class=""navbar-toggler navbar-toggler align-self-center"" type=""button"" data-toggle=""minimize"">
            <span class=""mdi mdi-sort-variant""></span>
          </button>
        </div>  
      </div>
      <div class=""navbar-menu-wrapper d-flex align-items-center justify-content-end"">
        <ul class=""navbar-nav mr-lg-4 w-100"">
          <li class=""nav-item nav-search d-none d-lg-block w-100"">
            <div class=""input-group"">
              <div class=""input-group-prepend"">
                <span class=""input-group-text"" id=""search"">
                  <i class=""mdi mdi-magnify""></i>
                </span>
              </div>
              <input type=""text"" class=""form-control"" placeholder=""Search now"" aria-label=""search"" aria-describedby=""search"">
            </div>
          </li>
        </ul>
        <ul class=""navbar-nav navbar-nav-right"">
          <li class=""nav-item dropdown me-1"">
            <a class=""nav-link count-indicator dropdown-toggle d-flex j");
                WriteLiteral(@"ustify-content-center align-items-center"" id=""messageDropdown"" href=""#"" data-bs-toggle=""dropdown"">
              <i class=""mdi mdi-message-text mx-0""></i>
              <span class=""count""></span>
            </a>
            <div class=""dropdown-menu dropdown-menu-right navbar-dropdown"" aria-labelledby=""messageDropdown"">
              <p class=""mb-0 font-weight-normal float-left dropdown-header"">Messages</p>
              <a class=""dropdown-item"">
                <div class=""item-thumbnail"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "56c3fcce910af08f59f79f8291c6be2a8f4be3f121887", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <div class=""item-content flex-grow"">
                  <h6 class=""ellipsis font-weight-normal"">David Grey
                  </h6>
                  <p class=""font-weight-light small-text text-muted mb-0"">
                    The meeting is cancelled
                  </p>
                </div>
              </a>
              <a class=""dropdown-item"">
                <div class=""item-thumbnail"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "56c3fcce910af08f59f79f8291c6be2a8f4be3f123631", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <div class=""item-content flex-grow"">
                  <h6 class=""ellipsis font-weight-normal"">Tim Cook
                  </h6>
                  <p class=""font-weight-light small-text text-muted mb-0"">
                    New product launch
                  </p>
                </div>
              </a>
              <a class=""dropdown-item"">
                <div class=""item-thumbnail"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "56c3fcce910af08f59f79f8291c6be2a8f4be3f125367", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                </div>
                <div class=""item-content flex-grow"">
                  <h6 class=""ellipsis font-weight-normal""> Johnson
                  </h6>
                  <p class=""font-weight-light small-text text-muted mb-0"">
                    Upcoming board meeting
                  </p>
                </div>
              </a>
            </div>
          </li>
          <li class=""nav-item dropdown me-4"">
            <a class=""nav-link count-indicator dropdown-toggle d-flex align-items-center justify-content-center notification-dropdown"" id=""notificationDropdown"" href=""#"" data-bs-toggle=""dropdown"">
              <i class=""mdi mdi-bell mx-0""></i>
              <span class=""count""></span>
            </a>
            <div class=""dropdown-menu dropdown-menu-right navbar-dropdown"" aria-labelledby=""notificationDropdown"">
              <p class=""mb-0 font-weight-normal float-left dropdown-header"">Notifications</p>
              <a class=""dropdown-item"">
                <di");
                WriteLiteral(@"v class=""item-thumbnail"">
                  <div class=""item-icon bg-success"">
                    <i class=""mdi mdi-information mx-0""></i>
                  </div>
                </div>
                <div class=""item-content"">
                  <h6 class=""font-weight-normal"">Application Error</h6>
                  <p class=""font-weight-light small-text mb-0 text-muted"">
                    Just now
                  </p>
                </div>
              </a>
              <a class=""dropdown-item"">
                <div class=""item-thumbnail"">
                  <div class=""item-icon bg-warning"">
                    <i class=""mdi mdi-settings mx-0""></i>
                  </div>
                </div>
                <div class=""item-content"">
                  <h6 class=""font-weight-normal"">Settings</h6>
                  <p class=""font-weight-light small-text mb-0 text-muted"">
                    Private message
                  </p>
                </div>
              </a>
 ");
                WriteLiteral(@"             <a class=""dropdown-item"">
                <div class=""item-thumbnail"">
                  <div class=""item-icon bg-info"">
                    <i class=""mdi mdi-account-box mx-0""></i>
                  </div>
                </div>
                <div class=""item-content"">
                  <h6 class=""font-weight-normal"">New user registration</h6>
                  <p class=""font-weight-light small-text mb-0 text-muted"">
                    2 days ago
                  </p>
                </div>
              </a>
            </div>
          </li>
          <li class=""nav-item nav-profile dropdown"">
            <a class=""nav-link dropdown-toggle"" href=""#"" data-bs-toggle=""dropdown"" id=""profileDropdown"">
              ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "56c3fcce910af08f59f79f8291c6be2a8f4be3f129584", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
              <span class=""nav-profile-name"">Louis Barnett</span>
            </a>
            <div class=""dropdown-menu dropdown-menu-right navbar-dropdown"" aria-labelledby=""profileDropdown"">
              <a class=""dropdown-item"">
                <i class=""mdi mdi-settings text-primary""></i>
                Settings
              </a>
              <a class=""dropdown-item"">
                <i class=""mdi mdi-logout text-primary""></i>
                Logout
              </a>
            </div>
          </li>
        </ul>
        <button class=""navbar-toggler navbar-toggler-right d-lg-none align-self-center"" type=""button"" data-toggle=""offcanvas"">
          <span class=""mdi mdi-menu""></span>
        </button>
      </div>
    </nav>
    <!-- partial -->
    <div class=""container-fluid page-body-wrapper"">
      <!-- partial:partials/_sidebar.html -->
      <nav class=""sidebar sidebar-offcanvas"" id=""sidebar"">
        <ul class=""nav"">
          <li class=""nav-item"">
            <a cla");
                WriteLiteral(@"ss=""nav-link"" href=""index.html"">
              <i class=""mdi mdi-home menu-icon""></i>
              <span class=""menu-title"">Dashboard</span>
            </a>
          </li>
          <li class=""nav-item"">
            <a class=""nav-link"" data-bs-toggle=""collapse"" href=""#ui-basic"" aria-expanded=""false"" aria-controls=""ui-basic"">
              <i class=""mdi mdi-circle-outline menu-icon""></i>
              <span class=""menu-title"">UI Elements</span>
              <i class=""menu-arrow""></i>
            </a>
            <div class=""collapse"" id=""ui-basic"">
              <ul class=""nav flex-column sub-menu"">
                <li class=""nav-item""> <a class=""nav-link"" href=""pages/ui-features/buttons.html"">Buttons</a></li>
                <li class=""nav-item""> <a class=""nav-link"" href=""pages/ui-features/typography.html"">Typography</a></li>
              </ul>
            </div>
          </li>
          <li class=""nav-item"">
            <a class=""nav-link"" href=""pages/forms/basic_elements.html"">
   ");
                WriteLiteral(@"           <i class=""mdi mdi-view-headline menu-icon""></i>
              <span class=""menu-title"">Form elements</span>
            </a>
          </li>
          <li class=""nav-item"">
            <a class=""nav-link"" href=""pages/charts/chartjs.html"">
              <i class=""mdi mdi-chart-pie menu-icon""></i>
              <span class=""menu-title"">Charts</span>
            </a>
          </li>
          <li class=""nav-item"">
            <a class=""nav-link"" href=""pages/tables/basic-table.html"">
              <i class=""mdi mdi-grid-large menu-icon""></i>
              <span class=""menu-title"">Tables</span>
            </a>
          </li>
          <li class=""nav-item"">
            <a class=""nav-link"" href=""pages/icons/mdi.html"">
              <i class=""mdi mdi-emoticon menu-icon""></i>
              <span class=""menu-title"">Icons</span>
            </a>
          </li>
          <li class=""nav-item"">
            <a class=""nav-link"" data-bs-toggle=""collapse"" href=""#auth"" aria-expanded=""false"" ");
                WriteLiteral(@"aria-controls=""auth"">
              <i class=""mdi mdi-account menu-icon""></i>
              <span class=""menu-title"">User Pages</span>
              <i class=""menu-arrow""></i>
            </a>
            <div class=""collapse"" id=""auth"">
              <ul class=""nav flex-column sub-menu"">
                <li class=""nav-item""> <a class=""nav-link"" href=""pages/samples/login.html""> Login </a></li>
                <li class=""nav-item""> <a class=""nav-link"" href=""pages/samples/login-2.html""> Login 2 </a></li>
                <li class=""nav-item""> <a class=""nav-link"" href=""pages/samples/register.html""> Register </a></li>
                <li class=""nav-item""> <a class=""nav-link"" href=""pages/samples/register-2.html""> Register 2 </a></li>
                <li class=""nav-item""> <a class=""nav-link"" href=""pages/samples/lock-screen.html""> Lockscreen </a></li>
              </ul>
            </div>
          </li>
          <li class=""nav-item"">
            <a class=""nav-link"" href=""documentation/documentation");
                WriteLiteral(".html\">\r\n              <i class=\"mdi mdi-file-document-box-outline menu-icon\"></i>\r\n              <span class=\"menu-title\">Documentation</span>\r\n            </a>\r\n          </li>\r\n        </ul>\r\n      </nav>\r\n        ");
#nullable restore
#line 236 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n    <!-- page-body-wrapper ends -->\r\n  </div>\r\n  <!-- container-scroller -->\r\n\r\n  ");
#nullable restore
#line 242 "C:\Users\sabir\OneDrive\Рабочий стол\Project\Project-MVC\Project_MVC\Project_MVC\Areas\MultiShopAdmin\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts",false));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
