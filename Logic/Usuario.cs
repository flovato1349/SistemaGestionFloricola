using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SGF.DataAccess;
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
        public SGF_Usuario Usuario_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_Usuario.First(x => x.UsuarioID == id);
        }
        [OperationContract]
        public SGF_Usuario Usuario_ObtenerPorUsername(string username)
        {
            DataModel model = new DataModel();
            return model.SGF_Usuario.First(x => x.UserName == username);
        }
        [OperationContract]
        public List<SGF_Usuario> Usuario_ObtenerTodo()
        {
            DataModel model = new DataModel();
            return model.SGF_Usuario.ToList();
        }
        [OperationContract]
        public List<SGF_Usuario> Usuario_ObtenerPorTipoUsuario(Guid TipoUsuario)
        {
            DataModel model = new DataModel();
            return model.SGF_Usuario.Where(x => x.TipoUsuarioID == TipoUsuario).ToList();
        }
        [OperationContract]
        public void Usuario_Grabar(SGF_Usuario usuario)
        {
            DataModel model = new DataModel();
            model.AddToSGF_Usuario(usuario);
            model.SaveChanges();
        }

        [OperationContract]
        public void Usuario_ActualizarPassword(string userName, string clvAnt, string clvAct, string ip, string mac, string nompc, string logueado)
        {
            DataModel model = new DataModel();
            SGF_Auditoria _auditoria = new SGF_Auditoria();
            SGF_Usuario _usuario = model.SGF_Usuario.First(x => x.UserName == userName && x.Estado == 1);
            _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Usuario", Tipo = "Update", Campo = "Password", ValorAnterior = clvAnt, ValorNuevo = clvAct, FechaRegistro = DateTime.Now, Usuario = logueado, RegistroID = _usuario.UsuarioID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Seguridad" }; Auditoria_Grabar(_auditoria);
            _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Usuario", Tipo = "Update", Campo = "NombrePC", ValorAnterior = _usuario.NombrePC, ValorNuevo = nompc, FechaRegistro = DateTime.Now, Usuario = logueado, RegistroID = _usuario.UsuarioID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Seguridad" }; Auditoria_Grabar(_auditoria);
            _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Usuario", Tipo = "Update", Campo = "IP", ValorAnterior = _usuario.IP, ValorNuevo = ip, FechaRegistro = DateTime.Now, Usuario = logueado, RegistroID = _usuario.UsuarioID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Seguridad" }; Auditoria_Grabar(_auditoria);
            _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Usuario", Tipo = "Update", Campo = "MAC", ValorAnterior = _usuario.MAC, ValorNuevo = mac, FechaRegistro = DateTime.Now, Usuario = logueado, RegistroID = _usuario.UsuarioID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Seguridad" }; Auditoria_Grabar(_auditoria);
            _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Usuario", Tipo = "Update", Campo = "UsuarioActualiza", ValorAnterior = _usuario.UsuarioActualiza, ValorNuevo = logueado, FechaRegistro = DateTime.Now, Usuario = logueado, RegistroID = _usuario.UsuarioID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Seguridad" }; Auditoria_Grabar(_auditoria);
            _auditoria = new SGF_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGF_Usuario", Tipo = "Update", Campo = "FechaActualiza", ValorAnterior = _usuario.FechaActualiza == null ? "" : _usuario.FechaActualiza.ToString(), ValorNuevo = DateTime.Now.ToString(), FechaRegistro = DateTime.Now, Usuario = logueado, RegistroID = _usuario.UsuarioID.ToString(), IPAddress = ip, namePC = nompc, ApplicationName = "Módulo Seguridad" }; Auditoria_Grabar(_auditoria);
            _usuario.Password = clvAct;
            _usuario.NombrePC = nompc;
            _usuario.IP = ip;
            _usuario.MAC = mac;
            _usuario.UsuarioActualiza = logueado;
            _usuario.FechaActualiza = DateTime.Now;
            model.SaveChanges();
        }

        [OperationContract]
        public List<SGF_Usuario_VTA> Usuario_BuscarUsuarioVTA(Guid TipoUsuario, string identificacion, string nombre)
        {
            DataModel model = new DataModel();
            if (identificacion == "" && TipoUsuario == Guid.Empty && nombre == "")
                return model.SGF_Usuario_VTA.Where(x => x.EstadoUsuario == 1).ToList();
            if (identificacion != "")
                return model.SGF_Usuario_VTA.Where(x => x.Identificacion == identificacion && x.EstadoUsuario == 1).ToList();
            if (TipoUsuario != Guid.Empty)
                return model.SGF_Usuario_VTA.Where(x => x.TipoPersonaID == TipoUsuario && x.EstadoUsuario == 1).ToList();
            if (nombre != "")
                return model.SGF_Usuario_VTA.Where(x => x.Nombre.ToUpper().Contains(nombre) && x.EstadoUsuario == 1).ToList();
            return null;
        }

        [OperationContract]
        public SGF_Usuario_VTA Usuario_BuscarUsuarioPorID_VTA(Guid usuarioID)
        {
            DataModel model = new DataModel();
            return model.SGF_Usuario_VTA.First(x => x.UsuarioID == usuarioID);
        }
    }
}
