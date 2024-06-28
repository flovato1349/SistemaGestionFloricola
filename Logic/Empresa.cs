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
        public SGF_Empresa  Empresa_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_Empresa.First(x => x.EmpresaID == id);
        }
        [OperationContract]
        public SGF_Empresa Empresa_ObtenerPorNombre(string nombre)
        {
            DataModel model = new DataModel();
            return model.SGF_Empresa.First(x => x.RazonSocial == nombre);
        }
        [OperationContract]
        public SGF_Empresa Empresa_ObtenerPorRUC(string ruc)
        {
            DataModel model = new DataModel();
            return model.SGF_Empresa.First(x => x.RUC == ruc);
        }
        [OperationContract]
        public List<SGF_Empresa> Empresa_ObtenerTodo()
        {
            DataModel model = new DataModel();
            return model.SGF_Empresa.ToList();
        }
        [OperationContract]
        public void Empresa_Grabar(SGF_Empresa empresa)
        {
            DataModel model = new DataModel();
            empresa.Direccion = "";
            model.AddToSGF_Empresa(empresa);
            model.SaveChanges();
        }
    }
}
