#pragma checksum "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "429dd0f3712a7322b70271de46c7d2f9797fce8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Experiments_Delete), @"mvc.1.0.view", @"/Views/Experiments/Delete.cshtml")]
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
#line 1 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\_ViewImports.cshtml"
using DataSpace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\_ViewImports.cshtml"
using DataSpace.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"429dd0f3712a7322b70271de46c7d2f9797fce8c", @"/Views/Experiments/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f8052906e74db7d5f903f098e6f7dd4f9ed4e48", @"/Views/_ViewImports.cshtml")]
    public class Views_Experiments_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DataSpace.Models.Experiment>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Experiment</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DateOfSubmission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DateOfSubmission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 22 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EvaluationStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 25 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EvaluationStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 28 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Author));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 31 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Author.Affiliation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 34 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 37 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 40 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TOA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 43 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TOA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 46 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Aim));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 49 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Aim));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 52 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Objective));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 55 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Objective));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 58 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Summary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 61 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Summary));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 64 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ModuleDrawing));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 67 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ModuleDrawing));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 70 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 73 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 76 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ExperimentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 79 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ExperimentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 82 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.FeildOfResearch));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 85 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.FeildOfResearch));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 88 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SocialEconomicObjective));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 91 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SocialEconomicObjective));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 94 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LeadIstitution));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 97 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LeadIstitution.ABN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 100 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Mission));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 103 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Mission.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "429dd0f3712a7322b70271de46c7d2f9797fce8c16096", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "429dd0f3712a7322b70271de46c7d2f9797fce8c16363", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 108 "C:\Users\heiye\Desktop\2020Summer\capstone\DataSpace\DataSpace\DataSpace\Views\Experiments\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ExperimentID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "429dd0f3712a7322b70271de46c7d2f9797fce8c18186", async() => {
                    WriteLiteral("Back to List");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DataSpace.Models.Experiment> Html { get; private set; }
    }
}
#pragma warning restore 1591
