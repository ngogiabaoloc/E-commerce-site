#pragma checksum "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d225e50be70707f5dd01be7394dae856d1ba401"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Make_Index), @"mvc.1.0.view", @"/Views/Make/Index.cshtml")]
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
#line 1 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/_ViewImports.cshtml"
using vroom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/_ViewImports.cshtml"
using vroom.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d225e50be70707f5dd01be7394dae856d1ba401", @"/Views/Make/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17ed6b5db9ad501af2cfbc4ddb284bb7ad745248", @"/Views/_ViewImports.cshtml")]
    public class Views_Make_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<vroom.Models.Make>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info\">Makes of Vehicle</h2>\r\n    </div>\r\n    <div class=\"col-6 text-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d225e50be70707f5dd01be7394dae856d1ba4014108", async() => {
                WriteLiteral("<i class=\"fas fa-motorcycle\"></i> &nbsp; Add New Make");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n    <br />\r\n\r\n    <div class=\"col-12\">\r\n        <table class=\"table table-striped border\">\r\n            <tr class=\"table-info\">\r\n                <th>\r\n                    ");
#nullable restore
#line 26 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>");
#nullable restore
#line 28 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n            \r\n");
#nullable restore
#line 31 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 35 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
           Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            WriteLiteral("                ");
#nullable restore
#line 39 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
           Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
            WriteLiteral("\r\n<td class=\"text-right\">\r\n                <div>\r\n");
            WriteLiteral("                    <a type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1421, "\"", 1469, 1);
#nullable restore
#line 46 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
WriteAttributeValue("", 1428, Url.Action("edit", new { id = item.Id }), 1428, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n                    <a type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1541, "\"", 1591, 1);
#nullable restore
#line 47 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
WriteAttributeValue("", 1548, Url.Action("delete", new { id = item.Id }), 1548, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n\r\n                </div>\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 53 "/Users/ngogiabaoloc/Downloads/Final Project/vroom/vroom/Views/Make/Index.cshtml"
                
             }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </table>\r\n    </div>\r\n\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<vroom.Models.Make>> Html { get; private set; }
    }
}
#pragma warning restore 1591
