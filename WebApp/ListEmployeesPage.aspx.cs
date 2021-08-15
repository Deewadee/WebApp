using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class ListEmployeesPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayDefaultPageButton.Text = "Главная страница";
            displayPreviousButton.Text = "Предыдущая страница";

            if (!IsPostBack)
            {
                AddEmployeesIntoViewState();
                BindData();
                AddReferenceUrlIntoViewState();
            }

            messageLabel.Text = $"Количество имён, начинающихся с буквы '{Letter}' равно: {NumberWords}";
        }

        protected void GridViewPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployees.PageIndex = e.NewPageIndex;

            BindData();
        }

        private void BindData()
        {
            if (Employees != null)
            {
                gvEmployees.DataSource = Employees;
                gvEmployees.DataBind();
            }
        }

        protected void DisplayEmployeePage(object sender, EventArgs e)
        {
            int businessEntityId = int.Parse((sender as LinkButton).CommandArgument);
            AddEmployeeIntoSession(businessEntityId);

            DisplayNewPage("EmployeePage.aspx");
        }

        private void AddEmployeeIntoSession(int id)
        {
            var employee = Employees.Where(pers => pers.BusinessEntityId == id);

            AddObjectIntoSession("Employee", employee);
        }

        private void AddObjectIntoSession(string sessionObjectName, object addedObject)
        {
            Session[sessionObjectName] = addedObject;
        }

        private void AddReferenceUrlIntoViewState()
        {
            string refUrl = Request.UrlReferrer.ToString();

            AddObjectIntoViewState("RefUrl", refUrl);
        }

        private void AddEmployeesIntoViewState()
        {
            List<Employee> employees = EmployeeStorage.GetEmployees(Letter, true);

            AddObjectIntoViewState("Employees", employees);
        }

        private void AddObjectIntoViewState(string viewStateObjectName, object addedObject)
        {
            ViewState[viewStateObjectName] = addedObject;
        }

        protected void DisplayDefaultPage(object sender, EventArgs e)
        {
            DisplayNewPage("Default.aspx");
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

        private string Letter
        {
            get
            {
                return Request.QueryString["Letter"];
            }
        }

        private List<Employee> Employees
        {
            get
            {
                return (List<Employee>)ViewState["Employees"];
            }
        }

        private int NumberWords
        {
            get
            {
                List<Employee> employees = Employees;

                return (int)employees.Count();
            }
        }
    }
}