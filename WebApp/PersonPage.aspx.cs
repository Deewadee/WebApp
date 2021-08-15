using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class PersonPage : Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            displayDefaultPage.Text = "Главная страница";
            displayPreviousPage.Text = "Предыдущая страница";

            if (!IsPostBack)
            {
                ViewState["RefUrl"] = Request.UrlReferrer.ToString();
            }

            BindData();
        }
        private void BindData()
        {
            gvPerson.DataSource = (object)Session["Person"];
            gvPerson.DataBind();
        }
        protected void DisplayDefaultPage(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void DisplayPreviousPage(object sender, EventArgs e)
        {
            string refUrl = ViewState["RefUrl"].ToString();

            if (!string.IsNullOrEmpty(refUrl))
            {
                DisplayNewPage(refUrl);
            }
        }
        private void DisplayNewPage(string pageName)
        {
            Response.Redirect(pageName);
        }
    }
}