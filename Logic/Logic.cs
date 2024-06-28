using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using SGF.DataAccess;
using SGF.BussinessLogic;

namespace SGF.BussinessLogic
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceContract]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class Logic
    {
        
        #region ServiceActivation

        [OperationContract]
        //[FaultContract(typeof(InfraestructureFault))]
        //[FaultContract(typeof(ValidationFault))]
        //[FaultContract(typeof(SecurityFault))]
        public void Activate()
        {
        }

        #endregion

        #region Funciones basicas

        #endregion

        #region Funciones complejas
        
        #endregion
    }
}
