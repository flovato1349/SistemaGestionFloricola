using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGF.Site.SGF_Service;
using Telerik.Web.UI;

namespace SGF.Site.TalentoHumano
{
    public partial class Frm_Persona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Me.ValidarSesion();
            if (!IsPostBack)
            {
                SGF_Site master = (SGF_Site)Page.Master;
                master.VisibilityMenuItem = (int)Enums.ModuloIndex.TalentoHumano;
                //LogicClient client = new LogicClient();
                //var _aux = client.Persona_ObtenerTodo();
                //txt_Codigo.Text = _aux.First().Codigo.ToString();
                //txt_Identificacion.Text = _aux.First().Identificacion.ToString();
                //txt_Nombre.Text = _aux.First().Nombre.ToString();
                cargarCombos();
            }
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            LogicClient client = new LogicClient();
            var _personas = client.Persona_BuscarPersonaVTA(new Guid(cmb_BuscarTipoPersona.SelectedValue.ToString()), txt_BuscarCedula.Text, txt_BuscarNombre.Text);
            gv_Persona.DataSource = _personas;
            gv_Persona.DataBind();
        }

        protected void btn_limpiar_Click(object sender, EventArgs e)
        {
            cmb_BuscarTipoPersona.SelectedValue = Guid.Empty.ToString();
            txt_BuscarCedula.Text = string.Empty;
            txt_BuscarNombre.Text = string.Empty;
        }

        protected string ObtenerNombreEstado(Int32 Estado)
        {
            switch (Estado)
            {
                case 0:
                    return "Pasivo";
                case 1:
                    return "Activo";
                case 2:
                    return "Pasivo";
            }
            return "";
        }

        protected void cargarCombos()
        {
            LogicClient client = new LogicClient();
            cmb_BuscarTipoPersona.DataSource = client.TipoPersona_ObtenerTodo();
            cmb_BuscarTipoPersona.DataTextField = "Nombre";
            cmb_BuscarTipoPersona.DataValueField = "TipoPersonaID";
            cmb_BuscarTipoPersona.DataBind();
            cmb_BuscarTipoPersona.Items.Insert(0, new RadComboBoxItem("Seleccione el tipo de Persona", Guid.Empty.ToString()));

            cmb_TipoPersona.DataSource = client.TipoPersona_ObtenerTodo();
            cmb_TipoPersona.DataTextField = "Nombre";
            cmb_TipoPersona.DataValueField = "TipoPersonaID";
            cmb_TipoPersona.DataBind();
            cmb_TipoPersona.Items.Insert(0, new RadComboBoxItem("Seleccione el tipo de Persona", "0"));

            cmb_TipoIdentificacion.DataSource = client.Clasificador_ObtenerPorTipoClasificador((Guid)TipoClasificador.TipoIdentificacion);
            cmb_TipoIdentificacion.DataTextField = "Nombre";
            cmb_TipoIdentificacion.DataValueField = "Valor";
            cmb_TipoIdentificacion.DataBind();
            cmb_TipoIdentificacion.Items.Insert(0, new RadComboBoxItem("Seleccione el tipo de Identificación", "0"));

            cmb_Pais.DataSource = client.Clasificador_ObtenerPorTipoClasificador((Guid)TipoClasificador.Pais);
            cmb_Pais.DataTextField = "Nombre";
            cmb_Pais.DataValueField = "ClasificadorID";
            cmb_Pais.DataBind();
            cmb_Pais.Items.Insert(0, new RadComboBoxItem("Seleccione el País", Guid.Empty.ToString()));

            cmb_EstadoCivil.DataSource = client.Clasificador_ObtenerPorTipoClasificador((Guid)TipoClasificador.EstadoCivil);
            cmb_EstadoCivil.DataTextField = "Nombre";
            cmb_EstadoCivil.DataValueField = "ClasificadorID";
            cmb_EstadoCivil.DataBind();
            cmb_EstadoCivil.Items.Insert(0, new RadComboBoxItem("Seleccione el Estado Civil", Guid.Empty.ToString()));

            cmb_Genero.DataSource = client.Clasificador_ObtenerPorTipoClasificador((Guid)TipoClasificador.Genero);
            cmb_Genero.DataTextField = "Nombre";
            cmb_Genero.DataValueField = "ClasificadorID";
            cmb_Genero.DataBind();
            cmb_Genero.Items.Insert(0, new RadComboBoxItem("Seleccione el Género", Guid.Empty.ToString()));

        }
        protected void gv_Persona_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void gv_Persona_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "editar":

                    hdn_PersonaID.Value = e.CommandArgument.ToString();
                    pnl_Buscar.Visible = false;
                    pnl_Datos.Visible = true;
                    CargarDatos();
                    break;
            }
        }

        protected void btn_Nuevo_Click(object sender, ImageClickEventArgs e)
        {
            pnl_Buscar.Visible = false;
            pnl_Datos.Visible = true;
            LimpiarControles();

        }
        protected void LimpiarControles()
        {
            cmb_TipoIdentificacion.SelectedValue = "0";
            cmb_TipoPersona.SelectedValue = Guid.Empty.ToString();
            cmb_Pais.SelectedValue = Guid.Empty.ToString();
            cmb_EstadoCivil.SelectedValue = Guid.Empty.ToString();
            cmb_Genero.SelectedValue = Guid.Empty.ToString();
            hdn_PersonaID.Value = null;
            txt_Codigo.Text = "";
            txt_Identificacion.Text = "";
            txt_NombrePersona.Text = "";
            txt_RepIdentificacion.Text = "";
            txt_RepNombre.Text = "";
            txt_NombreComercial.Text = "";
            dtp_FechaNacimiento.SelectedDate = null;
            txt_Email.Text = "";
            txt_Telefono.Text = "";
            txt_Celular.Text = "";
            txt_Cargo.Text = "";
            dtp_FechaIngreso.SelectedDate = null;
            dtp_FechaExpiracion.SelectedDate = null;
            txt_Observaciones.Text = "";
            txt_Estado.Text = "";
        }

        private void CargarDatos()
        {
            if (new Guid(hdn_PersonaID.Value) == Guid.Empty) return;

            LogicClient client = new LogicClient();
            SGF_Persona _persona = client.Persona_ObtenerPorID(new Guid(hdn_PersonaID.Value));
            cmb_TipoPersona.SelectedValue = _persona.TipoPersonaID.ToString();
            cmb_TipoIdentificacion.SelectedValue = _persona.TipoIdentificacion.ToString();
            cmb_Pais.SelectedValue = _persona.Pais==null?Guid.Empty.ToString(): _persona.Pais.ToString();
            cmb_EstadoCivil.SelectedValue = _persona.EstadoCivil == null? Guid.Empty.ToString():_persona.EstadoCivil.ToString();
            cmb_Genero.SelectedValue = _persona.Genero==null? Guid.Empty.ToString():_persona.Genero.ToString();
            txt_Codigo.Text = _persona.Codigo.ToString();
            txt_Identificacion.Text = _persona.Identificacion;
            txt_NombrePersona.Text = _persona.Nombre;
            txt_RepIdentificacion.Text = _persona.IdentificacionRepresentante;
            txt_RepNombre.Text = _persona.RepresentanteLegal;
            txt_NombreComercial.Text = _persona.NombreComercial;
            dtp_FechaNacimiento.SelectedDate = _persona.FechaNacimiento;
            txt_Email.Text = _persona.Email;
            txt_Telefono.Text = _persona.Telefono;
            txt_Celular.Text = _persona.Celular;
            txt_Cargo.Text = _persona.Cargo;
            dtp_FechaIngreso.SelectedDate = _persona.FechaIngreso;
            dtp_FechaExpiracion.SelectedDate = _persona.FechaExpiracion;
            txt_Observaciones.Text = _persona.Observacion;
            txt_Estado.Text = ObtenerNombreEstado(_persona.Estado);
        }
        private void Grabar()
        {
            string Valor = "";
            //if (cmb_TipoProcedimiento.SelectedValue == Guid.Empty.ToString())
            //{
            //    Utils.MessageBox2(this, "Debe seleccionar un Tipo de Procedimiento");
            //    return;
            //}

            SGF_Persona record = new SGF_Persona();
            record.PersonaID = String.IsNullOrEmpty(hdn_PersonaID.Value) ? Guid.NewGuid() : new Guid(hdn_PersonaID.Value);
            //if (cmb_TipoClasificador.SelectedValue == "1")
            //    Valor = cmb_ValorSeleccion.SelectedValue;
            //else if (cmb_TipoClasificador.SelectedValue == "2")
            //{
            //    if (txt_ValorNumerico.Value.HasValue)
            //        Valor = txt_ValorNumerico.Value.Value.ToString();
            //}
            //else if (cmb_TipoClasificador.SelectedValue == "3")
            //    Valor = txt_ValorTexto.Text;
            //else if (cmb_TipoClasificador.SelectedValue == "4")
            //    Valor = rbt_ValorOpcionesSI.Checked ? "true" : "false";
            //LogicaClient inslog = new LogicaClient();
            //inslog.Parametro_Actualizar(new Guid(hfCLASIFICADORID.Value), Valor, txt_Comentarios.Text);
            //PnlEditarClasificador.Visible = false;
            //PnlClasificador.Visible = true;
            //Grid_Clasificador.DataSource = inslog.Parametro_ObtenerTodos();
            //Grid_Clasificador.DataBind();
        }

        private void Cancelar()
        {
            LimpiarControles();
            pnl_Buscar.Visible = true;
            pnl_Datos.Visible = false;
        }

        protected void tool_principal_ButtonClick(object sender, RadToolBarEventArgs e)
        {
            RadToolBarButton btn = e.Item as RadToolBarButton;
            switch (btn.CommandName)
            {
                case "Grabar":
                    Grabar();
                    break;
                case "Cancelar":
                    Cancelar();
                    break;
            }
        }

        protected void cmb_TipoIdentificacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (cmb_TipoIdentificacion.SelectedValue.ToString() != "0")
            {
                switch (cmb_TipoIdentificacion.SelectedValue.ToString())
                {
                    case "0":
                        break;
                    case "1"://Cédula
                        txt_Identificacion.MaxLength = 10;
                        txt_Identificacion.InputType = ((Html5InputType)(int)Html5InputType.Number);
                        break;
                    case "2"://Ruc
                        txt_Identificacion.MaxLength = 13;
                        txt_Identificacion.InputType = ((Html5InputType)(int)Html5InputType.Number);
                        break;
                    case "3"://Pasaporte
                        break;
                }
            }
        }
    }
}