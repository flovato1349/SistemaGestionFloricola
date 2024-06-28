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
        public SGF_Grupo Grupo_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_Grupo.First(x => x.GrupoID == id);
        }
        [OperationContract]
        public SGF_Grupo Grupo_ObtenerPorNombre(string nombre)
        {
            DataModel model = new DataModel();
            return model.SGF_Grupo.First(x => x.Nombre== nombre);
        }
        [OperationContract]
        public List<SGF_Grupo> Grupo_ObtenerTodo()
        {
            DataModel model = new DataModel();
            return model.SGF_Grupo.ToList();
        }
        [OperationContract]
        public void Grupo_Grabar(SGF_Grupo Grupo)
        {
            DataModel model = new DataModel();
            model.AddToSGF_Grupo(Grupo);
            model.SaveChanges();
        }
    }
}
