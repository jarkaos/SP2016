using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Navigation;

namespace CreateSiteUsingWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            SPSite site = new SPSite("http://sp2016:41056");
            SPWeb web = site.OpenWeb();
            SPWebCollection subsites = web.Webs;
            SPWeb newweb = subsites.Add(
                "Customersupport",
                "Customer supprt site",
                "Customer support site",
                1033,
                "STS#0",
                false,
                false);

            MessageBox.Show("A new sie has been created..");
        }

        private void button_AddItems_Click(object sender, EventArgs e)
        {
            SPSite site = new SPSite("http://sp2016:41056");
            SPWeb web = site.RootWeb.Webs["Customersupport"];
            SPNavigationNode node = new SPNavigationNode(textBox_Title.Text, textBox_Url.Text, true);
            web.Navigation.QuickLaunch.AddAsLast(node);
            web.Navigation.TopNavigationBar.AddAsLast(node);

            MessageBox.Show("Node has been added...");
        }

        private void button_CreateList_Click(object sender, EventArgs e)
        {
            SPSite site = new SPSite("http://sp2016:41056");
            SPWeb web = site.RootWeb.Webs["Customersupport"];

            //Create new list
            Guid newGuid = web.Lists.Add(
                "BelfastCustomers",
                "Belfast customers list",
                SPListTemplateType.GenericList);

            SPList list = web.Lists[newGuid];

            //Add some columns
            list.Fields.Add("FirstName", SPFieldType.Text, true);
            list.Fields.Add("LastName", SPFieldType.Text, true);
            list.Fields.Add("Country", SPFieldType.Text, true);

            StringCollection viewFields = new StringCollection();

            viewFields.Add("FirstName");
            viewFields.Add("LastName");
            viewFields.Add("Country");

            string query = "<Where><Eq><FieldRef Name=\"Country\"/>" +
                "<Value Type=\"Text\">USA</Value></Eq></Where>";

            list.Views.Add("USA View", viewFields, query, 10, true, false);

            MessageBox.Show("Done");

        }
    }
}
