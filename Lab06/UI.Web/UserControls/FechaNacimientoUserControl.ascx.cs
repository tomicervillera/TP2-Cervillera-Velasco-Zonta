using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.UserControls
{
    public partial class FechaNacimientoUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void fechaNacimientoCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (Convert.ToInt32(args.Value) >= 29 && DDLMesFechaNac.SelectedValue == "02")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        public DropDownList ddlDiaFechaNac
        {
            get
            {
                return DDLDiaFechaNac;
            }
        }
        public DropDownList ddlMesFechaNac
        {
            get
            {
                return DDLMesFechaNac;
            }
        }
        public TextBox añoNacimientoTextBox
        {
            get
            {
                return AñoNacimientoTextBox;
            }
        }
    }
}