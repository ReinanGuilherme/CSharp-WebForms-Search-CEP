using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Search_CEP__WebForms_
{
    public partial class SearchHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvSearchHistory.DataSource = (List<ModelCEP>)Session["SearchList"];
            gvSearchHistory.DataBind();
        }
    }
}