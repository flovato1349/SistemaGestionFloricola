using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGF.Site
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Me.ValidarSesion();

            if(!IsPostBack)
            {
                //var Duplicados = Me.Usuario.Menus.GroupBy(x => x.ModuloID).SelectMany(x => x.Skip(1));
                if (Me.Usuario.Menus.Count(f => f.ModuloID == MenuModulo.Cultivo && f.EstadoPermiso == 1) == 0)
                    div_Cultivo.Visible = false;
                if (Me.Usuario.Menus.Count(f => f.ModuloID == MenuModulo.Poscosecha && f.EstadoPermiso == 1) == 0)
                    div_Poscosecha.Visible = false;
                if (Me.Usuario.Menus.Count(f => f.ModuloID == MenuModulo.Empaque && f.EstadoPermiso == 1) == 0)
                    div_Empaque.Visible = false;
                if (Me.Usuario.Menus.Count(f => f.ModuloID == MenuModulo.Comercial && f.EstadoPermiso == 1) == 0)
                    div_Comercial.Visible = false;
                if (Me.Usuario.Menus.Count(f => f.ModuloID == MenuModulo.Compras && f.EstadoPermiso == 1) == 0)
                    div_Recepcion.Visible = false;
                if (Me.Usuario.Menus.Count(f => f.ModuloID == MenuModulo.TalentoHumano && f.EstadoPermiso == 1) == 0)
                    div_TH.Visible = false;
                if (Me.Usuario.Menus.Count(f => f.ModuloID == MenuModulo.Administracion && f.EstadoPermiso == 1) == 0)
                    div_Administracion.Visible = false;

                SGF_Site master = (SGF_Site)Page.Master;
                master.ViewMenu(false);

                //foreach ( var menu in Duplicados )
                //{
                //    if (Me.Usuario.Menues.Count(f => f.MENU.ToLower() == "emision" && f.MENUESTADO == true) == 0)
                //        div_Emision.Visible = false;

                //    if (menu.ModuloID == MenuModulo.Cultivo)
                //        div_Cultivo.Visible = true;
                //    if (menu.ModuloID == MenuModulo.TalentoHumano)
                //        div_TH.Visible = true;
                //}
            }

        }
    }
}