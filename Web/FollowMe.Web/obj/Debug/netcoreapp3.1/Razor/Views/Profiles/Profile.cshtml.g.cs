#pragma checksum "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9063a416177ed0340beff67cbb6d9c37fbe81ea8"
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
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
using FollowMe.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9063a416177ed0340beff67cbb6d9c37fbe81ea8", @"/Views/Profiles/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a5253ebc5933e0fb83929063fd828f628f4b080", @"/Views/_ViewImports.cshtml")]
    public class Views_Profiles_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FollowMe.Web.ViewModels.Profiles.ProfileViewPersonalDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal ng-pristine ng-valid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("votesForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 7 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
  
    var userId = this.user.GetUserId(this.User);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container bootstrap snippets bootdey"">
    <div class=""row ng-scope"">
        <div class=""col-md-4"">
            <div class=""panel panel-default"">
                <div class=""panel-body text-center"">
                    <div class=""pv-lg""><img");
            BeginWriteAttribute("src", " src=\"", 555, "\"", 581, 1);
#nullable restore
#line 15 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 561, Model.CoverImageUrl, 561, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height:430px; width:450px\"></div>\r\n                    <h3 class=\"m0 text-bold\"></h3>\r\n                    <div class=\"mv-lg\">\r\n                        <p>");
#nullable restore
#line 18 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                      Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p>");
#nullable restore
#line 19 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"text-center\"><a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 916, "\"", 923, 0);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9063a416177ed0340beff67cbb6d9c37fbe81ea87199", async() => {
                WriteLiteral("\r\n                                <div class=\"form-group\">\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Birthday: ");
#nullable restore
#line 34 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                          Write(Model.BirthDate.ToString("dd-MM-yyyy", CultureInfo.CreateSpecificCulture("en-US")));

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Height: ");
#nullable restore
#line 36 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.Height);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Age: ");
#nullable restore
#line 38 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                     Write(Model.Age);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Weight: ");
#nullable restore
#line 40 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.Weight);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Gender: ");
#nullable restore
#line 42 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.Gender);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">City: ");
#nullable restore
#line 44 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                      Write(Model.City);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Eyes color: ");
#nullable restore
#line 46 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                            Write(Model.EyeColor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Hair color: ");
#nullable restore
#line 48 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                            Write(Model.HairColor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">Status: ");
#nullable restore
#line 50 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                                        Write(Model.WeddingStatus);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <hr />\r\n                                    <label class=\"control-label\" for=\"inputContact1\">What are you searching for: ");
#nullable restore
#line 52 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
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
            BeginWriteAttribute("href", " href=\"", 3447, "\"", 3484, 2);
            WriteAttributeValue("", 3454, "/Posts/Create?id=", 3454, 17, true);
#nullable restore
#line 66 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 3471, Model.UserId, 3471, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-lg text-center\">Create new post</a>\r\n</div>\r\n<hr />\r\n");
#nullable restore
#line 69 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
 foreach (var post in Model.UserPosts)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <div class=\"well\">\r\n            <div class=\"media\">\r\n                <a class=\"pull-left\"");
            BeginWriteAttribute("href", " href=\"", 3735, "\"", 3777, 2);
            WriteAttributeValue("", 3742, "/Profiles/Profile?id=", 3742, 21, true);
#nullable restore
#line 74 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 3763, post.SentById, 3763, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <img class=\"media-object\" style=\"height:140px; width:140px;\"");
            BeginWriteAttribute("src", " src=\"", 3861, "\"", 3911, 1);
#nullable restore
#line 75 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 3867, post.SentByUserCharacteristicsCoverImageUrl, 3867, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                </a>\r\n                <div class=\"media-body\">\r\n                    <div class=\"text-muted small ml-3\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9063a416177ed0340beff67cbb6d9c37fbe81ea815413", async() => {
                WriteLiteral("\r\n                            <div>\r\n                                <a class=\"btn btn-primary\"");
                BeginWriteAttribute("onclick", " onclick=\'", 4190, "\'", 4226, 4);
                WriteAttributeValue("", 4200, "sendVote(\"", 4200, 10, true);
#nullable restore
#line 81 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 4210, post.Id, 4210, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4218, "\",", 4218, 2, true);
                WriteAttributeValue(" ", 4220, "true)", 4221, 6, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <i class=\"fa fa-thumbs-up\"></i>\r\n                                </a>\r\n                            </div>\r\n                            <div id=\"votesCount\">");
#nullable restore
#line 85 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                            Write(post.VotesCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n                            <div>\r\n                                <a class=\"btn btn-primary\"");
                BeginWriteAttribute("onclick", " onclick=\'", 4539, "\'", 4576, 4);
                WriteAttributeValue("", 4549, "sendVote(\"", 4549, 10, true);
#nullable restore
#line 87 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 4559, post.Id, 4559, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4567, "\",", 4567, 2, true);
                WriteAttributeValue(" ", 4569, "false)", 4570, 7, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <i class=\"fa fa-thumbs-down\"></i>\r\n                                </a>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <div>\r\n                            <a class=\"btn\"");
            BeginWriteAttribute("href", " href=\"", 4831, "\"", 4863, 2);
            WriteAttributeValue("", 4838, "/Posts/Delete?id=", 4838, 17, true);
#nullable restore
#line 93 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 4855, post.Id, 4855, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-times\"></i></a>\r\n                        </div>\r\n                    </div>\r\n                    <div>\r\n                        ");
#nullable restore
#line 97 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                   Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <p class=\"text-right\"><i class=\"fas fa-user\"></i>By ");
#nullable restore
#line 99 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                   Write(post.SentByUserCharacteristicsFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p>\r\n                        ");
#nullable restore
#line 101 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                   Write(post.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                    <ul class=\"list-inline list-unstyled\">\r\n                        <li><span><i class=\"fas fa-calendar-alt\"></i>");
#nullable restore
#line 104 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                Write(post.CreatedOn.ToString("MM/dd/yy H:mm:ss", CultureInfo.CreateSpecificCulture("en-US")));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                        <li>\r\n                            <span><i class=\"fas fa-comment\"></i>Comments: ");
#nullable restore
#line 106 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                                     Write(post.CommentsCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </li>\r\n                        <li>\r\n                            <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 5736, "\"", 5766, 2);
            WriteAttributeValue("", 5743, "/Posts/Edit?id=", 5743, 15, true);
#nullable restore
#line 109 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 5758, post.Id, 5758, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit post</a>\r\n                        </li>\r\n                    </ul>\r\n\r\n");
#nullable restore
#line 113 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                     foreach (var comment in post.Comments.OrderByDescending(x => x.CreatedOn))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"comment\" id=\"comment\">\r\n                            <a class=\"pull-left\"");
            BeginWriteAttribute("href", " href=\"", 6071, "\"", 6114, 2);
            WriteAttributeValue("", 6078, "/Profiles/Profile?id=", 6078, 21, true);
#nullable restore
#line 116 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 6099, comment.UserId, 6099, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img class=\"media-object\" style=\"height:50px; width:50px;\"");
            BeginWriteAttribute("src", " src=\"", 6208, "\"", 6259, 1);
#nullable restore
#line 117 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 6214, comment.UserUserCharacteristicsCoverImageUrl, 6214, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            </a>\r\n                            <p>\r\n                                ");
#nullable restore
#line 120 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                           Write(comment.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                            <p class=\"text-right\">\r\n                                <i class=\"fas fa-user\"></i>By ");
#nullable restore
#line 123 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                                                         Write(comment.UserUserCharacteristicsFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                            <p>\r\n                                ");
#nullable restore
#line 126 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                           Write(comment.CreatedOn.ToString("MM/dd/yy H:mm:ss", CultureInfo.CreateSpecificCulture("en-US")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                            <a class=\"btn\"");
            BeginWriteAttribute("href", " href=\"", 6840, "\"", 6878, 2);
            WriteAttributeValue("", 6847, "/Comments/Delete?id=", 6847, 20, true);
#nullable restore
#line 128 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 6867, comment.Id, 6867, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-times\"></i></a>\r\n                            <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 6968, "\"", 7004, 2);
            WriteAttributeValue("", 6975, "/Comments/Edit?id=", 6975, 18, true);
#nullable restore
#line 129 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 6993, comment.Id, 6993, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit comment</a>\r\n                        </div>\r\n                        <hr />\r\n");
#nullable restore
#line 132 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row justify-content-md-end\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 7239, "\"", 7289, 4);
            WriteAttributeValue("", 7246, "/Comments/Create?id=", 7246, 20, true);
#nullable restore
#line 139 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 7266, post.Id, 7266, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7274, "&userId=", 7274, 8, true);
#nullable restore
#line 139 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
WriteAttributeValue("", 7282, userId, 7282, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"margin-right:14px\" class=\"btn btn-primary btn-lg text-center\">Add comment</a>\r\n        </div>\r\n    </div>\r\n    <hr />\r\n");
#nullable restore
#line 143 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Profiles\Profile.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function sendVote(postId, isUpVote) {
            var token = $(""#votesForm input[name=__RequestVerificationToken]"").val();
            var json = { postId: postId, isUpVote: isUpVote };
            var dataInfo = JSON.stringify(json);
            $.ajax({
                url: ""/api/votes"",
                type: ""POST"",
                data: dataInfo,
                contentType: ""application/json; charset=utf-8"",
                dataType: ""json"",
                headers: { ""X-CSRF-TOKEN"": token },
                success: function (data) {
                    $(""#votesCount"").html(data.votesCount);
                }
            });
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> user { get; private set; }
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
