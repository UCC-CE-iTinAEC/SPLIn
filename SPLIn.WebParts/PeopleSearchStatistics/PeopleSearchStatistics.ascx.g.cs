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
    
    
    public partial class PeopleSearchStatistics {
        
        public static implicit operator global::System.Web.UI.TemplateControl(PeopleSearchStatistics target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        private void @__BuildControlTree(global::SPLIn.WebParts.PeopleSearchStatistics @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"

<script type=""text/javascript"">
    function showPeopleSearchStatistics(result) {
        var statisticsHTML = '  <div class=""srch-stats"">';
        var resultFrom = result.people._start ? result.people._start : 0;
        var resultTo = result.people._count ? resultFrom + result.people._count : result.people._total;
        if (result.people._total > 0) {
            resultFrom += 1;
        }
        statisticsHTML += '         <b>' + resultFrom + '-' + resultTo + '</b> of ' + result.people._total + ' results';
        statisticsHTML += '     </div>';

        $(""#SPLInPeopleStatistics"").html(statisticsHTML);
    }
</script>

<div id=""SPLInPeopleStatistics"" class=""srch-WPBody""></div>"));
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
