#pragma checksum "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb5cc33d07140e7936557fdefea712ac8dcb6c89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Edit), @"mvc.1.0.view", @"/Views/Home/Edit.cshtml")]
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
#line 1 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\_ViewImports.cshtml"
using ShortUrl;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\_ViewImports.cshtml"
using ShortUrl.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
using ShortUrl.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb5cc33d07140e7936557fdefea712ac8dcb6c89", @"/Views/Home/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c8ac150081a4a61c772aefb169fa4eddb2bf5cd7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShortUrl.Models.Link>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
  
    ViewBag.Title = "Редактирование";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
 using (Html.BeginForm("Edit", "Home", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 12 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
   Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 13 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
   Write(Html.HiddenFor(m => m.Count));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 14 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
   Write(Html.HiddenFor(m => m.CreatedData));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br />\r\n        <p>\r\n\r\n            <h5>\r\n                ");
#nullable restore
#line 19 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
           Write(Html.LabelFor(m => m.LongURL, "Ссылка"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h5>\r\n            <h6>\r\n                ");
#nullable restore
#line 22 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
           Write(Html.ValidationMessageFor(x => x.LongURL, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h6>\r\n            ");
#nullable restore
#line 24 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
       Write(Html.TextBoxFor(m => m.LongURL, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n        <p>\r\n            <h5>\r\n                ");
#nullable restore
#line 29 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
           Write(Html.LabelFor(m => m.ShortUrl, "Короткая ссылка"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h5>\r\n            <h6>\r\n                ");
#nullable restore
#line 32 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
           Write(Html.ValidationMessageFor(x => x.ShortUrl, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </h6>\r\n            ");
#nullable restore
#line 34 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
       Write(Html.TextBoxFor(m => m.ShortUrl, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </p>\r\n        <div class=\"mt-4\">\r\n            <input type=\"submit\" value=\"Отправить\" class=\"btn btn-default bg-warning\" />\r\n        </div>        \r\n    </div>            \r\n");
#nullable restore
#line 41 "C:\Users\gvozd\Desktop\ShortUrl\ShortUrl\Views\Home\Edit.cshtml"
    
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShortUrl.Models.Link> Html { get; private set; }
    }
}
#pragma warning restore 1591
