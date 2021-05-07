#pragma checksum "C:\Users\Ngenx\source\repos\signalR\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66dc76719052b6aabfd6024c1b8913375466cf45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Ngenx\source\repos\signalR\Views\_ViewImports.cshtml"
using signalR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ngenx\source\repos\signalR\Views\_ViewImports.cshtml"
using signalR.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"66dc76719052b6aabfd6024c1b8913375466cf45", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ccf5ef6052655444d8299f2b587956b48469c72", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Ngenx\source\repos\signalR\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66dc76719052b6aabfd6024c1b8913375466cf453372", async() => {
                WriteLiteral("\r\n        <input type=\"text\" name=\"name\" id=\"name\" class=\"form-control\" />\r\n");
                WriteLiteral("    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <button class=""btn btn-success"" id=""myBtn"">Submit</button>

    <div class=""list-group"">
        <div class=""list-group"" id=""messageList"">
            <a href=""#"" class=""list-group-item list-group-item-action"">Messages <span style=""color:white;"" class=""badge bg-secondary rounded-pill"" id=""badgeId""></span></a>
        </div>
    </div>

    <div class=""list-group"" id=""messageList"">
    </div>
    <script>
        document.getElementById(""myBtn"").addEventListener(""click"", submitForm, false);
        var ws = new WebSocket('wss://localhost:44367/ws');

        var number = 0;

        ws.onmessage = function (event) {
            //alert(""onmessage event: "" + event.data);
            addMessage(JSON.parse(event.data));
        }
        ws.onopen = function (event) {
            // ws.send(""Start"");
            alert(""onopen event: "" + event.data);
        }

        ws.onclose = function () {
            alert(""closed"");
        }
        ws.onerror = function () {
           ");
            WriteLiteral(@" alert(""error"");
        }

        function submitForm() {
            let name = document.getElementById(""name"").value;
            var person = {
                id: 15,
                sender: ""Mueni"",
                date: new Date(),
                message: name
            };
            addMessage(person);
            console.log(person);
            ws.send(JSON.stringify(person));
        }
        //function addMessage(message) {
        //    number++;
        //    div = document.getElementById('messageList');
        //    badge = document.getElementById('badgeId');

        //    newlink = document.createElement('a');
        //    newlink.setAttribute('class', 'list-group-item list-group-item-action');
        //    newlink.setAttribute('href', '#');

        //    var node = document.createTextNode(message);
        //    var badgeNo = document.createTextNode(number);
        //    badge.appendChild(badgeNo);
        //    newlink.appendChild(node);
        //    ");
            WriteLiteral(@"div.appendChild(newlink);
        //}

        function addMessage(messageObject) {
            
            console.log(messageObject);
            var newitem = `<a href=""#"" class=""list-group-item list-group-item-action"">
                <div class=""d-flex w-100 justify-content-between"">
                    <h5 class=""mb-1"">${messageObject.sender}</h5>
                    <small class=""text-muted"">${messageObject.date}</small>
                </div>
                <p class=""mb-1"">${messageObject.message}</p>
                <small class=""text-muted"">EDMS Chat</small>
            </a>`;

            document.getElementById(""messageList"").innerHTML += newitem;
    }


    </script>
");
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