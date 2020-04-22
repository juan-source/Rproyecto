using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_M_Usuariomaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if (Session["id"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (int.Parse(Session["id"].ToString()) == 1)
            {
                //redirecion al perfil superadmonistrador
            }
            else if (int.Parse(Session["id"].ToString()) == 2)
            {
                Response.Redirect("Perfil_Usuario.aspx");
            }
        }
    }

 

    protected void Lb_cerrar_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
        Response.Redirect("Login.aspx");
    }
}
