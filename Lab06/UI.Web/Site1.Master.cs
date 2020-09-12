using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string HeaderText
        {
            get
            {
                return HeaderText;
            }
            set
            {
                lblHeader.Text = value;
            }
        }
        public TreeView TreeNav
        {
            get
            {
                return TreeViewNavegacion;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}