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
        public SGF_Sucursal Sucursal_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_Sucursal.First(x => x.SucursalID == id);
        }
        [OperationContract]
        public SGF_Sucursal Sucursal_ObtenerPorNombre(string nombre)
        {
            DataModel model = new DataModel();
            return model.SGF_Sucursal.First(x => x.Nombre == nombre);
        }
        [OperationContract]
        public List<SGF_Sucursal> Sucursal_ObtenerPorEmpresa(Guid empresa)
        {
            DataModel model = new DataModel();
            return model.SGF_Sucursal.Where(x => x.EmpresaID == empresa).ToList();
        }
        [OperationContract]
        public List<SGF_Sucursal> Sucursal_ObtenerTodo()
        {
            DataModel model = new DataModel();
            return model.SGF_Sucursal.ToList();
        }
        [OperationContract]
        public void Sucursal_Grabar(SGF_Sucursal empresa)
        {
            DataModel model = new DataModel();
            model.AddToSGF_Sucursal(empresa);
            model.SaveChanges();
        }
    }
}
