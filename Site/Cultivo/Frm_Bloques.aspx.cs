using SGF.Site.SGF_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;


namespace SGF.Site.Cultivo
{
    public partial class Frm_Bloques : System.Web.UI.Page
    {
        protected List<SGF_Clasificador> ListClasificadorTemporal
        {
            get
            {
                if (ViewState["ListClasificadorTemporal"] == null)
                    ViewState["ListClasificadorTemporal"] = new List<SGF_Clasificador>();
                return (List<SGF_Clasificador>)ViewState["ListClasificadorTemporal"];
            }
            set
            {
                ViewState["ListClasificadorTemporal"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Me.ValidarSesion();
            if (!IsPostBack)
            {
                SGF_Site master = (SGF_Site)Page.Master;
                master.VisibilityMenuItem = (int)Enums.ModuloIndex.Cultivo;
                //var area = new Area
                //{
                //    Id = 1,
                //    Nombre = "Área Principal",
                //    Bloques = new List<Bloque>
                //{
                //    new Bloque
                //    {
                //        Id = 1,
                //        Nombre = "Bloque A",
                //        Estanterias = new List<Estanteria>
                //        {
                //            new Estanteria
                //            {
                //                Id = 1,
                //                Nombre = "Estantería 1",
                //                Secciones = new List<Seccion>
                //                {
                //                    new Seccion { Id = 1, Nombre = "Sección 1", Descripcion = "Sección para productos frágiles" },
                //                    new Seccion { Id = 2, Nombre = "Sección 2", Descripcion = "Sección para productos pesados" }
                //                }
                //            }
                //        }
                //    },
                //    new Bloque
                //    {
                //        Id = 2,
                //        Nombre = "Bloque B",
                //        Estanterias = new List<Estanteria>
                //        {
                //            new Estanteria
                //            {
                //                Id = 2,
                //                Nombre = "Estantería 2",
                //                Secciones = new List<Seccion>
                //                {
                //                    new Seccion { Id = 3, Nombre = "Sección 3", Descripcion = "Sección para productos electrónicos" }
                //                }
                //            }
                //        }
                //    }
                //}
                //};

                //// Vincular datos al DataList
                //dlArea.DataSource = new List<Area> { area };
                //dlArea.DataBind();

                CargarParametros();
            }
        }

        private void CargarParametros()
        {
            LogicClient client = new LogicClient();
            ListClasificadorTemporal = client.Clasificador_ObtenerTodo();
            hdn_CultivoArea.Value = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == (Guid)TipoClasificador.CultivoAreas).Max(x => int.Parse(x.Valor.ToString())).ToString();
            lbl_TextAreasValor.Text = hdn_CultivoArea.Value;
            txt_NroAreas.MaxValue = int.Parse(hdn_CultivoArea.Value);

            hdn_CultivoBloque.Value = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == (Guid)TipoClasificador.CultivoBloques).Max(x => int.Parse(x.Valor.ToString())).ToString();
            lbl_TextBloquesValor.Text = hdn_CultivoBloque.Value;
            txt_NroBloques.MaxValue = int.Parse(hdn_CultivoBloque.Value);

            hdn_CultivoLado.Value = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == (Guid)TipoClasificador.CultivoLados).Max(x => int.Parse(x.Valor.ToString())).ToString();
            lbl_TextLadosValor.Text = hdn_CultivoLado.Value;
            txt_NroLados.MaxValue = int.Parse(hdn_CultivoLado.Value);

            hdn_CultivoNave.Value = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == (Guid)TipoClasificador.CultivoNaves).Max(x => int.Parse(x.Valor.ToString())).ToString();
            lbl_TextNavesValor.Text = hdn_CultivoNave.Value;
            txt_NroNaves.MaxValue = int.Parse(hdn_CultivoNave.Value);

            hdn_CultivoCama.Value = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == (Guid)TipoClasificador.CultivoCamas).Max(x => int.Parse(x.Valor.ToString())).ToString();
            lbl_TextCamasValor.Text = hdn_CultivoCama.Value;
            txt_NroCamas.MaxValue = int.Parse(hdn_CultivoCama.Value);

            hdn_CultivoCuadro.Value = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == (Guid)TipoClasificador.CultivoCuadros).Max(x => int.Parse(x.Valor.ToString())).ToString();
            lbl_TextCuadrosValor.Text = hdn_CultivoCuadro.Value;
            txt_NroCuadros.MaxValue = int.Parse(hdn_CultivoCuadro.Value);
        }

        protected void btn_GenerarCampo_Click(object sender, EventArgs e)
        {
            List<SGF_CultivoArea> _areaCultivo = new List<SGF_CultivoArea>();
            List<SGF_CultivoBloque> _bloqueCultivo = new List<SGF_CultivoBloque>();
            List<SGF_CultivoLado> _ladoCultivo = new List<SGF_CultivoLado>();
            List<SGF_CultivoNave> _naveCultivo = new List<SGF_CultivoNave>();
            List<SGF_CultivoCama> _camaCultivo = new List<SGF_CultivoCama>();
            List<SGF_CultivoCuadro> _cuadroCultivo = new List<SGF_CultivoCuadro>();
            SGF_Clasificador _tmpClasificador = new SGF_Clasificador();
            LogicClient client = new LogicClient();

            for (int i = 1; i <= txt_NroAreas.Value; i++)
            {
                _tmpClasificador = new SGF_Clasificador();
                _tmpClasificador = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == TipoClasificador.CultivoAreas).First(x => x.Valor == i.ToString());
                SGF_CultivoArea _area = new SGF_CultivoArea();
                _area.CampoCultivoID = Guid.NewGuid();
                _area.CultivoAreaID = Guid.NewGuid();
                _area.AreaID = _tmpClasificador.ClasificadorID;
                _area.Nombre = _tmpClasificador.Nombre;// "AREA " + i.ToString();
                _area.Orden = i;
                _bloqueCultivo = new List<SGF_CultivoBloque>();
                int contBloques = 0;
                for (int j = 1; j <= txt_NroBloques.Value; j++)
                {
                    contBloques = contBloques + 1;
                    _tmpClasificador = new SGF_Clasificador();
                    _tmpClasificador = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == TipoClasificador.CultivoBloques).First(x => x.Valor == contBloques.ToString());
                    SGF_CultivoBloque _bloque = new SGF_CultivoBloque();
                    _bloque.CultivoBloqueID = Guid.NewGuid();
                    _bloque.CultivoAreaID = _area.CultivoAreaID;
                    _bloque.BloqueID = _tmpClasificador.ClasificadorID;
                    _bloque.Nombre = _tmpClasificador.Nombre;// "BLOQUE " + j.ToString();
                    _bloque.Orden = j;
                    _ladoCultivo = new List<SGF_CultivoLado>();
                    int contLados = 0;
                    int contCama = 0;
                    int contNaves = 0;
                    for (int k = 1; k <= txt_NroLados.Value; k++)
                    {
                        contLados = contLados + 1;
                        _tmpClasificador = new SGF_Clasificador();
                        _tmpClasificador = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == TipoClasificador.CultivoLados).First(x => x.Valor == contLados.ToString());
                        SGF_CultivoLado _lado = new SGF_CultivoLado();
                        _lado.CultivoLadoID = Guid.NewGuid();
                        _lado.CultivoBloqueID = _bloque.CultivoBloqueID;
                        _lado.Orden = k;
                        _lado.LadoID = _tmpClasificador.ClasificadorID;
                        _lado.Nombre = _tmpClasificador.Nombre;// "LADO " + k.ToString();
                        _naveCultivo = new List<SGF_CultivoNave>();
                        for (int m = 1; m <= txt_NroNaves.Value; m++)
                        {
                            contNaves = contNaves + 1;
                            _tmpClasificador = new SGF_Clasificador();
                            _tmpClasificador = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == TipoClasificador.CultivoNaves).First(x => x.Valor == contNaves.ToString());
                            SGF_CultivoNave _nave = new SGF_CultivoNave();
                            _nave.CultivoNaveID = Guid.NewGuid();
                            _nave.CultivoLadoID = _lado.CultivoLadoID;
                            _nave.Orden = m;
                            _nave.NaveID = _tmpClasificador.ClasificadorID;
                            _nave.Nombre = _tmpClasificador.Nombre;// "NAVE " + m.ToString();
                            _camaCultivo = new List<SGF_CultivoCama>();
                            for (int n = 1; n <= txt_NroCamas.Value; n++)
                            {
                                contCama = contCama + 1;
                                _tmpClasificador = new SGF_Clasificador();
                                _tmpClasificador = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == TipoClasificador.CultivoCamas).First(x => x.Valor == contCama.ToString());
                                SGF_CultivoCama _cama = new SGF_CultivoCama();
                                _cama.CamaID = Guid.NewGuid();
                                _cama.CultivoNaveID = _nave.CultivoNaveID;
                                _cama.Orden = n;
                                _cama.CamaID = _tmpClasificador.ClasificadorID;
                                _cama.Nombre = _tmpClasificador.Nombre;// "CAMA " + n.ToString();
                                _cuadroCultivo = new List<SGF_CultivoCuadro>();
                                for (int p = 1; p <= txt_NroCuadros.Value; p++)
                                {
                                    _tmpClasificador = new SGF_Clasificador();
                                    _tmpClasificador = ListClasificadorTemporal.Where(x => x.TipoClasificadorID == TipoClasificador.CultivoCuadros).First(x => x.Valor == p.ToString());
                                    SGF_CultivoCuadro _cuadro = new SGF_CultivoCuadro();
                                    _cuadro.CultivoCamaID = Guid.NewGuid();
                                    _cuadro.CultivoCamaID = _nave.CultivoNaveID;
                                    _cuadro.CuadroID = _tmpClasificador.ClasificadorID;
                                    _cuadro.Orden = p;
                                    _cuadro.Nombre = _tmpClasificador.Nombre;// "Cuadro " + p.ToString();
                                    _cuadroCultivo.Add(_cuadro);

                                }
                                _cama.SGF_CultivoCuadro = _cuadroCultivo;
                                _camaCultivo.Add(_cama);

                            }
                            _nave.SGF_CultivoCama = _camaCultivo;
                            _naveCultivo.Add(_nave);

                        }
                        _lado.SGF_CultivoNave = _naveCultivo;
                        _ladoCultivo.Add(_lado);
                    }
                    _bloque.SGF_CultivoLado = _ladoCultivo;
                    _bloqueCultivo.Add(_bloque);
                }
                _area.SGF_CultivoBloque = _bloqueCultivo;
                _areaCultivo.Add(_area);
            }

            dlAreas.DataSource = _areaCultivo;
            dlAreas.DataBind();
            //_area.SGF_CultivoBloque = new List<SGF_CultivoBloque>
            //{
            //   new SGF_CultivoBloque()
            //   {

            //   }
            //};

            //SGF_CampoCultivo _campo = new SGF_CampoCultivo();
            // _campo.SGF_CultivoArea =
        }
    }

    public class Seccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class Estanteria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Seccion> Secciones { get; set; } = new List<Seccion>();
    }

    public class Bloque
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Estanteria> Estanterias { get; set; } = new List<Estanteria>();
    }

    public class Area
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Bloque> Bloques { get; set; } = new List<Bloque>();
    }

}