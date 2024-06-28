using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using SGF.DataAccess;

namespace SGF.BussinessLogic
{
    public partial class Logic
    {
        [OperationContract]
        public SGF_TipoPersona TipoPersona_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_TipoPersona.First(x => x.TipoPersonaID == id);
        }
        [OperationContract]
        public SGF_TipoPersona TipoPersona_ObtenerPorUsername(string nombre)
        {
            DataModel model = new DataModel();
            return model.SGF_TipoPersona.First(x => x.Nombre == nombre);
        }
        [OperationContract]
        public List<SGF_TipoPersona> TipoPersona_ObtenerTodo()
        {
            DataModel model = new DataModel();
            return model.SGF_TipoPersona.Where(x => x.Estado == true).ToList();
        }
        [OperationContract]
        public void TipoPersona_Grabar(SGF_TipoPersona TipoPersona)
        {
            DataModel model = new DataModel();
            model.AddToSGF_TipoPersona(TipoPersona);
            model.SaveChanges();
        }
    }
}
