#pragma checksum "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6447d404aaab83e326265e236238d97d27a2897"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Photos_Photo), @"mvc.1.0.view", @"/Views/Photos/Photo.cshtml")]
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
#line 1 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6447d404aaab83e326265e236238d97d27a2897", @"/Views/Photos/Photo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a5253ebc5933e0fb83929063fd828f628f4b080", @"/Views/_ViewImports.cshtml")]
    public class Views_Photos_Photo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FollowMe.Web.ViewModels.Photos.AllPhotoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"text-sm-center\">\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 125, "\"", 147, 1);
#nullable restore
#line 4 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 131, Model.ImagePath, 131, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"singlePhoto\" />\r\n    <div><input class=\"invisible\" id=\"photoId\" name=\"photoId\"");
            BeginWriteAttribute("value", " value=\"", 231, "\"", 248, 1);
#nullable restore
#line 5 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 239, Model.Id, 239, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /></div>\r\n</div>\r\n<div class=\"row justify-content-center\">\r\n    <a");
            BeginWriteAttribute("href", " href=\"", 316, "\"", 385, 4);
            WriteAttributeValue("", 323, "/Comments/CreatePhotoComment?id=", 323, 32, true);
#nullable restore
#line 8 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 355, Model.Id, 355, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 364, "&userId=", 364, 8, true);
#nullable restore
#line 8 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 372, Model.UserId, 372, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-lg text-center\">Create comment</a>\r\n</div>\r\n<hr />\r\n<div>\r\n");
#nullable restore
#line 12 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
     foreach (var comment in Model.Comments)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"commentPhoto\"");
            BeginWriteAttribute("id", " id=\"", 559, "\"", 575, 1);
#nullable restore
#line 14 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 564, comment.Id, 564, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <a class=\"pull-left\"");
            BeginWriteAttribute("href", " href=\"", 611, "\"", 656, 2);
            WriteAttributeValue("", 618, "/Profiles/Profile?id=", 618, 21, true);
#nullable restore
#line 15 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 639, comment.SentById, 639, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <img class=\"media-object\" id=\"commentPicture\"");
            BeginWriteAttribute("src", " src=\"", 721, "\"", 774, 1);
#nullable restore
#line 16 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 727, comment.SentByUserCharacteristicsCoverImageUrl, 727, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </a>\r\n            <p>\r\n                ");
#nullable restore
#line 19 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
           Write(comment.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n            <p class=\"text-right\">\r\n                <i class=\"fas fa-user\"></i>By ");
#nullable restore
#line 22 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
                                         Write(comment.SentByUserCharacteristicsFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n            <p>\r\n                ");
#nullable restore
#line 25 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
           Write(comment.CreatedOn.ToString("MM/dd/yy H:mm:ss", CultureInfo.CreateSpecificCulture("en-US")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n            <a class=\"btn\"");
            BeginWriteAttribute("href", " href=\"", 1181, "\"", 1219, 2);
            WriteAttributeValue("", 1188, "/Comments/Delete?id=", 1188, 20, true);
#nullable restore
#line 27 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 1208, comment.Id, 1208, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fas fa-times\"></i></a>\r\n            <a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1293, "\"", 1329, 2);
            WriteAttributeValue("", 1300, "/Comments/Edit?id=", 1300, 18, true);
#nullable restore
#line 28 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
WriteAttributeValue("", 1318, comment.Id, 1318, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit comment</a>\r\n        </div>\r\n        <hr />\r\n");
#nullable restore
#line 31 "D:\FollowMe\FollowMe\Web\FollowMe.Web\Views\Photos\Photo.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FollowMe.Web.ViewModels.Photos.AllPhotoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
