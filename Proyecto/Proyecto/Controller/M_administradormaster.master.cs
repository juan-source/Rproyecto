﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_M_administradormaster : System.Web.UI.MasterPage
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
            else if (int.Parse(Session["id"].ToString()) == 3)
            {
                Response.Redirect("Perfil_Usuario.apsx");
            }
        }
    }


    protected void Lb_cerrar_admin_Click(object sender, EventArgs e)
    {
        Session["id"] = null;
        Response.Redirect("Login.aspx");
    }
}
