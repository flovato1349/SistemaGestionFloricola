using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SGF.DataAccess;

namespace SGF.BussinessLogic
{
    public partial class Logic
    {
        [OperationContract]
        public SGF_Persona Persona_ObtenerPorID(Guid id)
        {
            try
            {
                DataModel model = new DataModel();
                return model.SGF_Persona.First(x => x.PersonaID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SGF_Persona Persona_ObtenerPorIdentificacion(string identificacion)
        {
            DataModel model = new DataModel();
            return model.SGF_Persona.First(x => x.Identificacion == identificacion);
        }
        [OperationContract]
        public List<SGF_Persona> Persona_ObtenerTodo()
        {
            DataModel model = new DataModel();
            var _res = model.SGF_Persona.ToList();
            return model.SGF_Persona.ToList();
        }
        public List<SGF_Persona> Persona_ObtenerTipoPersona(Guid TipoPersona)
        {
            DataModel model = new DataModel();
            return model.SGF_Persona.Where(x => x.TipoPersonaID == TipoPersona).ToList();
        }
        [OperationContract]
        public void Person_Grabar(SGF_Persona newPersona)
        {
            DataModel model = new DataModel();
            if (model.SGF_Persona.Count(x => x.PersonaID == newPersona.PersonaID) > 0)
            {
                SGF_Persona _persona = model.SGF_Persona.First(x => x.PersonaID == newPersona.PersonaID);
                //if=_persona.TipoPersonaID != newPersona.TipoPersonaID) { model.AddToSGF_Auditoria(new SGF_Auditoria() { }) ; }
                //SGT_OCUPACIONDESUELO ocupacion = model.SGT_OCUPACIONDESUELO.First(s => s.OCUPACIONDESUELOID == suelo.OCUPACIONDESUELOID);
                //if (ocupacion.NOMBRE != suelo.NOMBRE) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "NOMBRE", ValorAnterior = ocupacion.NOMBRE.ToString(), ValorNuevo = suelo.NOMBRE.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.NOMBRE = suelo.NOMBRE;
                //if (ocupacion.FORMADEOCUPACIONID != suelo.FORMADEOCUPACIONID) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "FORMADEOCUPACIONID", ValorAnterior = ocupacion.FORMADEOCUPACIONID.ToString(), ValorNuevo = suelo.FORMADEOCUPACIONID.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.FORMADEOCUPACIONID = suelo.FORMADEOCUPACIONID;
                //if (ocupacion.LOTEMINIMOID != suelo.LOTEMINIMOID) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "LOTEMINIMOID", ValorAnterior = ocupacion.LOTEMINIMOID.ToString(), ValorNuevo = suelo.LOTEMINIMOID.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.LOTEMINIMOID = suelo.LOTEMINIMOID;
                //if (ocupacion.ALTURAMAXIMAPISOSID != suelo.ALTURAMAXIMAPISOSID) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "ALTURAMAXIMAPISOSID", ValorAnterior = ocupacion.ALTURAMAXIMAPISOSID.ToString(), ValorNuevo = suelo.ALTURAMAXIMAPISOSID.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.ALTURAMAXIMAPISOSID = suelo.ALTURAMAXIMAPISOSID;
                //if (ocupacion.ALTURAMAXIMA != suelo.ALTURAMAXIMA) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "ALTURAMAXIMA", ValorAnterior = ocupacion.ALTURAMAXIMA.ToString(), ValorNuevo = suelo.ALTURAMAXIMA.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.ALTURAMAXIMA = suelo.ALTURAMAXIMA;
                //if (ocupacion.FRENTEMINIMO != suelo.FRENTEMINIMO) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "FRENTEMINIMO", ValorAnterior = ocupacion.FRENTEMINIMO.ToString(), ValorNuevo = suelo.FRENTEMINIMO.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.FRENTEMINIMO = suelo.FRENTEMINIMO;
                //if (ocupacion.FRENTEFONDO != suelo.FRENTEFONDO) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "FRENTEFONDO", ValorAnterior = ocupacion.FRENTEFONDO.ToString(), ValorNuevo = suelo.FRENTEFONDO.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.FRENTEFONDO = suelo.FRENTEFONDO;
                //if (ocupacion.COS != suelo.COS) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "COS", ValorAnterior = ocupacion.COS.ToString(), ValorNuevo = suelo.COS.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.COS = suelo.COS;
                //if (ocupacion.CUS != suelo.CUS) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "CUS", ValorAnterior = ocupacion.CUS.ToString(), ValorNuevo = suelo.CUS.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.CUS = suelo.CUS;
                //if (ocupacion.RETIROFRONTAL != suelo.RETIROFRONTAL) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "RETIROFRONTAL", ValorAnterior = ocupacion.RETIROFRONTAL.ToString(), ValorNuevo = suelo.RETIROFRONTAL.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.RETIROFRONTAL = suelo.RETIROFRONTAL;
                //if (ocupacion.RETIROLATERAL1 != suelo.RETIROLATERAL1) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "RETIROLATERAL1", ValorAnterior = ocupacion.RETIROLATERAL1.ToString(), ValorNuevo = suelo.RETIROLATERAL1.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.RETIROLATERAL1 = suelo.RETIROLATERAL1;
                //if (ocupacion.RETIROLATERAL2 != suelo.RETIROLATERAL2) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "RETIROLATERAL2", ValorAnterior = ocupacion.RETIROLATERAL2.ToString(), ValorNuevo = suelo.RETIROLATERAL2.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.RETIROLATERAL2 = suelo.RETIROLATERAL2;
                //if (ocupacion.RETIROPOSTERIOR != suelo.RETIROPOSTERIOR) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "RETIROPOSTERIOR", ValorAnterior = ocupacion.RETIROPOSTERIOR.ToString(), ValorNuevo = suelo.RETIROPOSTERIOR.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.RETIROPOSTERIOR = suelo.RETIROPOSTERIOR;
                //if (ocupacion.DENSIDADNETA != suelo.DENSIDADNETA) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "DENSIDADNETA", ValorAnterior = ocupacion.DENSIDADNETA.ToString(), ValorNuevo = suelo.DENSIDADNETA.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.DENSIDADNETA = suelo.DENSIDADNETA;
                //if (ocupacion.DENSIDADBRUTA != suelo.DENSIDADBRUTA) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "DENSIDADBRUTA", ValorAnterior = ocupacion.DENSIDADBRUTA.ToString(), ValorNuevo = suelo.DENSIDADBRUTA.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.DENSIDADBRUTA = suelo.DENSIDADBRUTA;
                //if (ocupacion.OBSERVACIONES != suelo.OBSERVACIONES) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "OBSERVACIONES", ValorAnterior = ocupacion.OBSERVACIONES.ToString(), ValorNuevo = suelo.OBSERVACIONES.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.OBSERVACIONES = suelo.OBSERVACIONES;
                //if (ocupacion.RETIROENTREBLOQUES != suelo.RETIROENTREBLOQUES) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "RETIROENTREBLOQUES", ValorAnterior = ocupacion.RETIROENTREBLOQUES.ToString(), ValorNuevo = suelo.RETIROENTREBLOQUES.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.RETIROENTREBLOQUES = suelo.RETIROENTREBLOQUES;
                //if (ocupacion.SECTORID != suelo.SECTORID) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "SECTORID", ValorAnterior = ocupacion.SECTORID.ToString(), ValorNuevo = suelo.SECTORID.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.SECTORID = suelo.SECTORID;
                //if (ocupacion.USODESUELOID != suelo.USODESUELOID) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "USODESUELOID", ValorAnterior = ocupacion.USODESUELOID.ToString(), ValorNuevo = suelo.USODESUELOID.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.USODESUELOID = suelo.USODESUELOID;

                //if (ocupacion.LADOPARIAMIENTO != suelo.LADOPARIAMIENTO) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "LADOPARIAMIENTO", ValorAnterior = ocupacion.LADOPARIAMIENTO.ToString(), ValorNuevo = suelo.LADOPARIAMIENTO.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.LADOPARIAMIENTO = suelo.LADOPARIAMIENTO;
                //if (ocupacion.NUMEROPISOS != suelo.NUMEROPISOS) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "NUMEROPISOS", ValorAnterior = ocupacion.NUMEROPISOS.ToString(), ValorNuevo = suelo.NUMEROPISOS.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.NUMEROPISOS = suelo.NUMEROPISOS;
                //if (ocupacion.NUMEROVIVIENDAS != suelo.NUMEROVIVIENDAS) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "NUMEROVIVIENDAS", ValorAnterior = ocupacion.NUMEROVIVIENDAS.ToString(), ValorNuevo = suelo.NUMEROVIVIENDAS.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.NUMEROVIVIENDAS = suelo.NUMEROVIVIENDAS;
                //if (ocupacion.NUMEROESTACIONAMIENTOS != suelo.NUMEROESTACIONAMIENTOS) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "NUMEROESTACIONAMIENTOS", ValorAnterior = ocupacion.NUMEROESTACIONAMIENTOS.ToString(), ValorNuevo = suelo.NUMEROESTACIONAMIENTOS.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); }
                //ocupacion.NUMEROESTACIONAMIENTOS = suelo.NUMEROESTACIONAMIENTOS;

                ////if (ocupacion.ESTADO != suelo.ESTADO) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "ESTADO", ValorAnterior = ocupacion.ESTADO.ToString(), ValorNuevo = suelo.ESTADO.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); } ocupacion.ESTADO = suelo.ESTADO;
                ////if (ocupacion.USUARIOACTUALIZACION != suelo.USUARIOACTUALIZACION) { model.AddToSGT_Auditoria(new SGT_Auditoria() { AuditoriaID = Guid.NewGuid(), Tabla = "SGT_OCUPACIONDESUELO", Campo = "USUARIOACTUALIZACION", ValorAnterior = ocupacion.USUARIOACTUALIZACION.ToString(), ValorNuevo = suelo.USUARIOACTUALIZACION.ToString(), FechaRegistro = DateTime.Now, RegistroID = suelo.OCUPACIONDESUELOID, Usuario = suelo.USUARIOACTUALIZACION }); } ocupacion.USUARIOACTUALIZACION = suelo.USUARIOACTUALIZACION;
                //ocupacion.USUARIOACTUALIZACION = suelo.USUARIOACTUALIZACION;
                //ocupacion.FECHAACTUALIZACION = DateTime.Now;
            }
            else
            {
                newPersona.FechaCreacion= DateTime.Now;
                newPersona.FechaActualiza = DateTime.Now;
                newPersona.Estado = 1;
                model.AddToSGF_Persona(newPersona);
            }
            model.SaveChanges();
        }

        [OperationContract]
        public List<SGF_Persona_VTA> Persona_BuscarPersonaVTA(Guid TipoPersona, string identificacion, string nombre)
        {
            DataModel model = new DataModel();
            if (identificacion == "" && TipoPersona == Guid.Empty && nombre == "")
                return model.SGF_Persona_VTA.Where(x => x.EstadoPersona == 1).ToList();
            if (identificacion != "")
                return model.SGF_Persona_VTA.Where(x => x.Identificacion == identificacion && x.EstadoPersona == 1).ToList();
            if (TipoPersona != Guid.Empty)
                return model.SGF_Persona_VTA.Where(x => x.TipoPersonaID == TipoPersona && x.EstadoPersona == 1).ToList();
            if (nombre != "")
                return model.SGF_Persona_VTA.Where(x => x.NombrePersona.ToUpper().Contains(nombre) && x.EstadoPersona == 1).ToList();
            return null;
        }

    }
}
