﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPLIn.WebParts {
    using System.Web;
    using System.Text.RegularExpressions;
    using Microsoft.SharePoint.WebPartPages;
    using Microsoft.SharePoint.WebControls;
    using System.Web.Security;
    using Microsoft.SharePoint.Utilities;
    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using Microsoft.SharePoint;
    using System.Web.UI;
    using System.Web.Profile;
    using System.Text;
    using System.Web.Caching;
    using System.Web.UI.WebControls;
    using System.Configuration;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.SessionState;
    using System.Web.UI.HtmlControls;
    
    
    public partial class PeopleSearchBox {
        
        public static implicit operator global::System.Web.UI.TemplateControl(PeopleSearchBox target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::SPLIn.WebParts.PeopleSearchBox @__ctrl) {
            @__ctrl.SetRenderMethodDelegate(new System.Web.UI.RenderMethod(this.@__Render__control1));
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__Render__control1(System.Web.UI.HtmlTextWriter @__w, System.Web.UI.Control parameterContainer) {
            @__w.Write("\r\n\r\n<script type=\"text/javascript\" src=\"//platform.linkedin.com/in.js\">\r\n    api_" +
                    "key: ");
     @__w.Write( LinkedInApiKey );

            @__w.Write("\r\n    authorize: ");
       @__w.Write( RememberMe.ToString().ToLower() );

            @__w.Write(@"
</script>

<link rel=""stylesheet"" href=""//ajax.googleapis.com/ajax/libs/jqueryui/1.8.4/themes/base/jquery-ui.css"">
<script src=""//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"" type=""text/javascript""></script>
<script src=""//ajax.googleapis.com/ajax/libs/jqueryui/1.8.4/jquery-ui.min.js"" type=""text/javascript""></script>

<script type=""text/javascript"">
    //https://developer.linkedin.com/documents/people-search-api
    var availableTags = [
			""first-name:"",
			""last-name:"",
			""company-name:"",
            ""current-company:"",
            ""title:"",
            ""current-title:"",
            ""school-name:"",
            ""current-school:"",
            ""country-code:"",
            ""postal-code:""
		];

    function loadPeopleSearchData(facetCode, bucketCode) {
        var searchQuery = $(""#SPLInSearchBox"").val();
        if (searchQuery == """") {
            return;
        }

        if (!IN.API) {
            alert(""Please set the LinkedIn API Key web part property"");
            return;
        }

        var url = ""/people-search:(people:(");
                                   @__w.Write( DataFields );

            @__w.Write(")\";\r\n\r\n        if (typeof getPeopleSearchRefinerFields == \'function\') {\r\n        " +
                    "    url += \",\" + getPeopleSearchRefinerFields();\r\n        }\r\n\r\n        for (var " +
                    "i in availableTags) {\r\n            var tag = availableTags[i];\r\n            sear" +
                    "chQuery = searchQuery.replace(tag, \"&\" + tag.replace(\":\", \"=\"));\r\n        }\r\n\r\n " +
                    "       url += \")?keywords=\" + searchQuery;\r\n\r\n        if (typeof getPeopleSearch" +
                    "Refiners == \'function\') {\r\n            url += \"&\" + getPeopleSearchRefiners();\r\n" +
                    "        }\r\n\r\n        if (facetCode && bucketCode) {\r\n            url += \"&facet=" +
                    "\" + facetCode + \",\" + bucketCode;\r\n        }\r\n\r\n        if (typeof getPeopleSear" +
                    "chResultCount == \'function\') {\r\n            url += \"&\" + getPeopleSearchResultCo" +
                    "unt();\r\n        }\r\n\r\n        IN.API.Raw(url).result(function (result) {\r\n       " +
                    "     if (typeof showPeopleSearchResults == \'function\') {\r\n                showPe" +
                    "opleSearchResults(result);\r\n            }\r\n            if (typeof showPeopleSear" +
                    "chRefiners == \'function\') {\r\n                showPeopleSearchRefiners(result);\r\n" +
                    "            }\r\n            if (typeof showPeopleSearchStatistics == \'function\') " +
                    "{\r\n                showPeopleSearchStatistics(result);\r\n            } \r\n        " +
                    "})\r\n        .error(function (error) {\r\n            if (error.status === 401) {\r\n" +
                    "                // try it again\r\n                var oldToken = IN.ENV.auth.oaut" +
                    "h_token;\r\n                IN.User.refresh();\r\n                // since the refre" +
                    "sh method is asynchronous but doesn\'t provide a callback, we have to poll\r\n     " +
                    "           function tryAgain() {\r\n                    setTimeout(function () {\r\n" +
                    "                        if (oldToken !== IN.ENV.auth.oauth_token) {\r\n           " +
                    "                 loadPeopleSearchData();\r\n                        }\r\n           " +
                    "             else {\r\n                            setTimeout(tryAgain, 100);\r\n   " +
                    "                     }\r\n                    }, 100);\r\n                }\r\n       " +
                    "         tryAgain();\r\n            }\r\n        });\r\n    }\r\n\r\n    $(document).ready" +
                    "(function () {\r\n\r\n        function split(val) {\r\n            return val.split(/ " +
                    "\\s*/);\r\n        }\r\n        function extractLast(term) {\r\n            return spli" +
                    "t(term).pop();\r\n        }\r\n\r\n        $(\'#SPLInSearchBox\')\r\n            .bind(\'ke" +
                    "ypress\', function (e) {\r\n                if (e.keyCode == 13) {\r\n               " +
                    "     e.preventDefault();\r\n                    loadPeopleSearchData();\r\n         " +
                    "       }\r\n            })\r\n\t\t    .bind(\"keydown\", function (event) {\r\n\t\t        i" +
                    "f (event.keyCode === $.ui.keyCode.TAB && $(this).data(\"autocomplete\").menu.activ" +
                    "e) {\r\n    \t\t        event.preventDefault();\r\n    \t\t    }\r\n    \t    })\r\n\t\t    .au" +
                    "tocomplete({\r\n\t\t\t    minLength: 0,\r\n\t\t\t    source: function (request, response) " +
                    "{\r\n\t\t\t        // delegate back to autocomplete, but extract the last term\r\n\t\t\t  " +
                    "      response($.ui.autocomplete.filter(\r\n\t\t\t\t\t    availableTags, extractLast(re" +
                    "quest.term)));\r\n\t\t\t    },\r\n\t\t\t    focus: function () {\r\n\t\t\t        // prevent va" +
                    "lue inserted on focus\r\n\t\t\t        return false;\r\n\t\t\t    },\r\n\t\t\t    select: funct" +
                    "ion (event, ui) {\r\n\t\t\t        var terms = split(this.value);\r\n\t\t\t        // remo" +
                    "ve the current input\r\n\t\t\t        terms.pop();\r\n\t\t\t        // add the selected it" +
                    "em\r\n\t\t\t        terms.push(ui.item.value);\r\n\t\t\t        this.value = terms.join(\" " +
                    "\");\r\n\t\t\t        return false;\r\n\t\t\t    }\r\n\t\t    });\r\n    });\r\n</script>\r\n\r\n<div>\r" +
                    "\n    <table class=\"ms-sbtable ms-sbtable-ex\" cellpadding=\"0\" cellspacing=\"0\" bor" +
                    "der=\"0\">\r\n        <tr class=\"ms-sbrow\">\r\n            <td class=\"ms-sbcell\">\r\n   " +
                    "             <input type=\"text\" name=\"SPLInSearchBox\" id=\"SPLInSearchBox\" class=" +
                    "\"ms-sbplain\" style=\"margin:0px; width:368px;\" />\r\n            </td>\r\n           " +
                    " <td class=\"ms-sbgo ms-sbcell\">\r\n                <a href=\"javascript:loadPeopleS" +
                    "earchData()\"><img style=\"border-width:0px;\" class=\"srch-gosearchimg\" onmouseover" +
                    "=\"this.src=\'\\u002f_layouts\\u002fimages\\u002fgosearchhover30.png\'\" onmouseout=\"th" +
                    "is.src=\'\\u002f_layouts\\u002fimages\\u002fgosearch30.png\'\" src=\"/_layouts/images/g" +
                    "osearch30.png\" /></a>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</div>");
        }
        
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
