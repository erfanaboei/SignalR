#pragma checksum "D:\New folder\SignalR\E-Chat\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca76f701be472d3a535967b5833c7694fcf7abbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "D:\New folder\SignalR\E-Chat\Views\_ViewImports.cshtml"
using E_Chat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\New folder\SignalR\E-Chat\Views\_ViewImports.cshtml"
using E_Chat.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\New folder\SignalR\E-Chat\Views\Shared\_Layout.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca76f701be472d3a535967b5833c7694fcf7abbc", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a70601a451627a53cd2e546ccee47ccc0e0f91d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca76f701be472d3a535967b5833c7694fcf7abbc4318", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8""/>
    <title>Metrica - Responsive Bootstrap 4 Admin Dashboard</title>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta content=""A premium admin dashboard template by Mannatthemes"" name=""description""/>
    <meta content=""Mannatthemes"" name=""author""/>

    <!-- App favicon -->
    <link rel=""shortcut icon"" href=""/assets/images/favicon.ico"">

    <!-- App css -->
    <link href=""/assets/css/bootstrap.min.css"" rel=""stylesheet"" type=""text/css""/>
    <link href=""/assets/css/icons.css"" rel=""stylesheet"" type=""text/css""/>
    <link href=""/assets/css/metisMenu.min.css"" rel=""stylesheet"" type=""text/css""/>
    <link href=""/assets/css/style.css"" rel=""stylesheet"" type=""text/css""/>

    ");
#nullable restore
#line 20 "D:\New folder\SignalR\E-Chat\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("MyStyle", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    \r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca76f701be472d3a535967b5833c7694fcf7abbc6323", async() => {
                WriteLiteral(@"

<!-- Top Bar Start -->
<div class=""topbar"">
    <!-- LOGO -->
    <div class=""topbar-left m-0"">
        <a href=""#"" class=""logo"">
            <span>
                <img src=""/assets/images/logo-sm.png"" alt=""logo-small"" class=""logo-sm"">
            </span>
            <span>
                <img src=""/assets/images/logo-dark.png"" alt=""logo-large"" class=""logo-lg"">
            </span>
        </a>
    </div>
    <!--end logo-->
    <!-- Navbar -->
    <nav class=""navbar-custom mr-0"">
        <ul class=""list-unstyled topbar-nav float-right mb-0"">
            
            <li class=""dropdown"">
                <a class=""nav-link dropdown-toggle waves-effect waves-light nav-user"" data-toggle=""dropdown"" href=""#"" role=""button""
                   aria-haspopup=""false"" aria-expanded=""false"">
                    <img src=""/assets/images/users/user-4.jpg"" alt=""profile-user"" class=""rounded-circle""/>
                    <span class=""ml-1 nav-user-name hidden-sm"">");
#nullable restore
#line 48 "D:\New folder\SignalR\E-Chat\Views\Shared\_Layout.cshtml"
                                                          Write(User.FindFirst(ClaimTypes.Name)?.Value);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" <i class=""mdi mdi-chevron-down""></i> </span>
                </a>
                <div class=""dropdown-menu"">
                    <a class=""dropdown-item"" href=""#""><i class=""dripicons-user text-muted mr-2""></i> پروفایل </a>
                    <div class=""dropdown-divider""></div>
                    <a class=""dropdown-item"" href=""#""><i class=""dripicons-exit text-muted mr-2""></i> خروج</a>
                </div>
            </li>
        </ul><!--end topbar-nav-->

        <ul class=""list-unstyled topbar-nav mb-0"">
            <li class=""hide-phone app-search"">
                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca76f701be472d3a535967b5833c7694fcf7abbc8510", async() => {
                    WriteLiteral("\r\n                    <input type=\"text\" placeholder=\"جستجو...\" class=\"form-control\">\r\n                    <a");
                    BeginWriteAttribute("href", " href=\"", 2660, "\"", 2667, 0);
                    EndWriteAttribute();
                    WriteLiteral(">\r\n                        <i class=\"fas fa-search\"></i>\r\n                    </a>\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
            </li>
        </ul>
    </nav>
    <!-- end navbar-->
</div>
<!-- Top Bar End -->

<div class=""page-wrapper"">
    <div class=""page-content"">

        <div class=""container-fluid p-2"" style=""max-height: 90vh; position: fixed"">
            ");
#nullable restore
#line 77 "D:\New folder\SignalR\E-Chat\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </div>
    </div>

</div>

<script src=""/assets/js/jquery.min.js""></script>
<script src=""/assets/js/bootstrap.bundle.min.js""></script>
<script src=""/assets/js/metisMenu.min.js""></script>
<script src=""/assets/js/waves.min.js""></script>
<script src=""/assets/js/jquery.slimscroll.min.js""></script>

<script src=""/assets/js/app.js""></script>

");
#nullable restore
#line 91 "D:\New folder\SignalR\E-Chat\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("MyScript", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 95 "D:\New folder\SignalR\E-Chat\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("OutOfBody", false));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
