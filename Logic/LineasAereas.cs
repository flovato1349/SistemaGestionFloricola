using SGF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SGF.BussinessLogic
{
    public partial class Logic
    {
        [OperationContract]
        public SGF_LineaAerea LineaAerea_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_LineaAerea.First(x => x.LineaAereaID == id);
        }
    }

    //Línea de código para probar
}
