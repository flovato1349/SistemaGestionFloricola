using SGF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;

namespace SGF.BussinessLogic
{
    public partial class Logic
    {
        [OperationContract]
        [WebMethod]
        [FaultContract(typeof(Common.InfraestructureException))]
        [FaultContract(typeof(Common.LogicException))]
        [FaultContract(typeof(Common.SecurityException))]
        public SGF_Variedad Variedad_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_Variedad.First(x => x.VariedadID == id);
        }
        [OperationContract]
        public List<SGF_Variedad> Variedad_ObtenerPorCodName(string name, string code)
        {
            DataModel model = new DataModel();
            if (code == "" && name == "")
                return model.SGF_Variedad.ToList();
            if (code == "")
                return model.SGF_Variedad.Where(x => x.Nombre.ToUpper().Contains(name.ToUpper())).ToList();
            else
                return model.SGF_Variedad.Where(x => x.Codigo.ToUpper().Contains(name.ToUpper())).ToList();
        }
        [OperationContract]
        public List<SGF_Variedad_VTA> Variedad_ObtenerPorCodNameVTA(string name, string code)
        {
            DataModel model = new DataModel();
            if (code == "" && name == "")
                return model.SGF_Variedad_VTA.ToList();
            if (code == "")
                return model.SGF_Variedad_VTA.Where(x => x.Nombre.ToUpper().Contains(name.ToUpper())).ToList();
            else
                return model.SGF_Variedad_VTA.Where(x => x.Codigo.ToUpper().Contains(name.ToUpper())).ToList();
        }
        [OperationContract]
        public List<SGF_Variedad> Variedad_ObtenerTodo()
        {
            DataModel model = new DataModel();
            return model.SGF_Variedad.ToList();
        }
        [OperationContract]
        public List<SGF_Variedad_VTA> Variedad_ObtenerTodoVTA()
        {
            DataModel model = new DataModel();
            return model.SGF_Variedad_VTA.ToList();
        }
        [OperationContract]
        public void Variedad_Grabar(SGF_Variedad variedad, string ip, string nompc)
        {
            DataModel model = new DataModel();
            if (model.SGF_Variedad.Count(x => x.VariedadID == variedad.VariedadID) == 0)
            {
                model.AddToSGF_Variedad(variedad);
            }
            else
            {
                SGF_Variedad _newvariedad = new SGF_Variedad();
                SGF_Auditoria _auditoria = new SGF_Auditoria();
                _newvariedad = model.SGF_Variedad.First(x => x.VariedadID == variedad.VariedadID);
                if (_newvariedad != null)
                {
                    if (_newvariedad.TipoFlorID != variedad.TipoFlorID)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "TipoFlorID", ValorAnterior = _newvariedad.TipoFlorID.ToString(), ValorNuevo = variedad.TipoFlorID.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.TipoFlorID = variedad.TipoFlorID; }
                    if (_newvariedad.ColorID != variedad.ColorID)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "ColorID", ValorAnterior = _newvariedad.ColorID.ToString(), ValorNuevo = variedad.ColorID.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.ColorID = variedad.ColorID; }
                    if (_newvariedad.CalidadID != variedad.CalidadID)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "CalidadID", ValorAnterior = _newvariedad.CalidadID.ToString(), ValorNuevo = variedad.CalidadID.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.CalidadID = variedad.CalidadID; }
                    if (_newvariedad.Codigo != variedad.Codigo)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "Codigo", ValorAnterior = _newvariedad.Codigo.ToString(), ValorNuevo = variedad.Codigo.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.Codigo = variedad.Codigo; }
                    if (_newvariedad.Nombre != variedad.Nombre)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "Nombre", ValorAnterior = _newvariedad.Nombre.ToString(), ValorNuevo = variedad.Nombre.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.Nombre = variedad.Nombre; }
                    if (_newvariedad.ObtentorID != variedad.ObtentorID)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "ObtentorID", ValorAnterior = _newvariedad.ObtentorID.ToString(), ValorNuevo = variedad.ObtentorID.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.ObtentorID = variedad.ObtentorID; }
                    if (_newvariedad.ObtentorNombre != variedad.ObtentorNombre)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "ObtentorNombre", ValorAnterior = _newvariedad.ObtentorNombre.ToString(), ValorNuevo = variedad.ObtentorNombre.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.ObtentorNombre = variedad.ObtentorNombre; }
                    if (_newvariedad.Rotacion != variedad.Rotacion)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "Rotacion", ValorAnterior = _newvariedad.Rotacion.ToString(), ValorNuevo = variedad.Rotacion.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.Rotacion = variedad.Rotacion; }
                    if (_newvariedad.IndProdMensual != variedad.IndProdMensual)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "IndProdMensual", ValorAnterior = _newvariedad.IndProdMensual.ToString(), ValorNuevo = variedad.IndProdMensual.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.IndProdMensual = variedad.IndProdMensual; }
                    if (_newvariedad.LongitudIDMin != variedad.LongitudIDMin)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "LongitudIDMin", ValorAnterior = _newvariedad.LongitudIDMin.ToString(), ValorNuevo = variedad.LongitudIDMin.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.LongitudIDMin = variedad.LongitudIDMin; }
                    if (_newvariedad.LongitudIDMax != variedad.LongitudIDMax)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "LongitudIDMax", ValorAnterior = _newvariedad.LongitudIDMax.ToString(), ValorNuevo = variedad.LongitudIDMax.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.LongitudIDMax = variedad.LongitudIDMax; }
                    if (_newvariedad.TamanoBoton != variedad.TamanoBoton)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "TamanoBoton", ValorAnterior = _newvariedad.TamanoBoton.ToString(), ValorNuevo = variedad.TamanoBoton.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.TamanoBoton = variedad.TamanoBoton; }
                    if (_newvariedad.NumeroPetalos != variedad.NumeroPetalos)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "NumeroPetalos", ValorAnterior = _newvariedad.NumeroPetalos.ToString(), ValorNuevo = variedad.NumeroPetalos.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.NumeroPetalos = variedad.NumeroPetalos; }
                    if (_newvariedad.Ciclo != variedad.Ciclo)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "Ciclo", ValorAnterior = _newvariedad.Ciclo.ToString(), ValorNuevo = variedad.Ciclo.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.Ciclo = variedad.Ciclo; }
                    if (_newvariedad.DiasFlorero != variedad.DiasFlorero)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "DiasFlorero", ValorAnterior = _newvariedad.DiasFlorero.ToString(), ValorNuevo = variedad.DiasFlorero.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.DiasFlorero = variedad.DiasFlorero; }
                    if (_newvariedad.Observaciones != variedad.Observaciones)
                    { _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Variedad", Tipo = "Update", Campo = "Observaciones", ValorAnterior = _newvariedad.Observaciones.ToString(), ValorNuevo = variedad.Observaciones.ToString(), FechaRegistro = DateTime.Now, Usuario = variedad.Usuario, RegistroID = variedad.VariedadID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Cultivo" }; Auditoria_Grabar(_auditoria); _newvariedad.Observaciones = variedad.Observaciones; }
                }
            }
            model.SaveChanges();
        }
    }
}
