#pragma checksum "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "01a92f122bda2e272b57110526154587a02ede66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profiles_Profile), @"mvc.1.0.view", @"/Views/Profiles/Profile.cshtml")]
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
#line 1 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\_ViewImports.cshtml"
using FollowMe.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\_ViewImports.cshtml"
using FollowMe.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01a92f122bda2e272b57110526154587a02ede66", @"/Views/Profiles/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a5253ebc5933e0fb83929063fd828f628f4b080", @"/Views/_ViewImports.cshtml")]
    public class Views_Profiles_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FollowMe.Web.ViewModels.Profiles.ProfileViewPersonalDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal ng-pristine ng-valid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<div class=""container bootstrap snippets bootdey"">
    <div class=""row ng-scope"">
        <div class=""col-md-4"">
            <div class=""panel panel-default"">
                <div class=""panel-body text-center"">
                    <div class=""pv-lg""><img");
            BeginWriteAttribute("src", " src=\"", 393, "\"", 419, 1);
#nullable restore
#line 11 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 399, Model.CoverImageUrl, 399, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height:430px; width:450px\"></div>\r\n                    <h3 class=\"m0 text-bold\"></h3>\r\n                    <div class=\"mv-lg\">\r\n                        <p>");
#nullable restore
#line 14 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                      Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 15 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"text-center\"><a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 754, "\"", 761, 0);
            EndWriteAttribute();
            WriteLiteral(@">Send message</a></div>
                </div>
            </div>
        </div>
        <div class=""col-md-8"">
            <div class=""panel panel-default"">
                <div class=""panel-body"">
                    <div class=""h4 text-center"">Personal information</div>
                    <div class=""row pv-lg"">
                        <div class=""col-lg-2""></div>
                        <div class=""col-lg-8"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01a92f122bda2e272b57110526154587a02ede666030", async() => {
                WriteLiteral("\r\n                                <div class=\"form-group\">\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Birthday: ");
#nullable restore
#line 30 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                          Write(Model.BirthDate.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("en-US")));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Height: ");
#nullable restore
#line 32 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.Height);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Age: ");
#nullable restore
#line 34 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                     Write(Model.Age);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Weight: ");
#nullable restore
#line 36 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.Weight);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Gender: ");
#nullable restore
#line 38 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.Gender);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">City: ");
#nullable restore
#line 40 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                      Write(Model.City);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Eyes color: ");
#nullable restore
#line 42 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                            Write(Model.EyeColor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Hair color: ");
#nullable restore
#line 44 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                            Write(Model.HairColor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Status: ");
#nullable restore
#line 46 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.WeddingStatus);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">What are you searching for: ");
#nullable restore
#line 48 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                                            Write(Model.WhatAreYouSearchingFor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                </div>\r\n\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n<hr />\r\n<div class=\"row justify-content-center\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 3285, "\"", 3322, 2);
            WriteAttributeValue("", 3292, "/Posts/Create?id=", 3292, 17, true);
#nullable restore
#line 62 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 3309, Model.UserId, 3309, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-lg text-center\">Create new post</a>\r\n</div>\r\n");
#nullable restore
#line 64 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
 foreach (var post in Model.UserPosts)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <div class=\"well\">\r\n            <div class=\"media\">\r\n                    <img class=\"media-object\" style=\"height:200px; width:200px;\"");
            BeginWriteAttribute("src", " src=\"", 3609, "\"", 3659, 1);
#nullable restore
#line 69 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 3615, post.SentByUserCharacteristicsCoverImageUrl, 3615, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"media-body\">\r\n                    <p class=\"text-right\">");
#nullable restore
#line 71 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                     Write(post.SentByUserCharacteristicsFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>\r\n                        ");
#nullable restore
#line 73 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                   Write(post.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                    <ul class=\"list-inline list-unstyled\">\r\n                        <li><span><i class=\"glyphicon glyphicon-calendar\"></i>");
#nullable restore
#line 76 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                         Write(post.CreatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                        <li></li>\r\n                        <span><i class=\"glyphicon glyphicon-comment\"></i> 2 comments</span>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <hr />\r\n");
#nullable restore
#line 85 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FollowMe.Web.ViewModels.Profiles.ProfileViewPersonalDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
