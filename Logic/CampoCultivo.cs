﻿using SGF.DataAccess;
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
        #region Campo Cultivo
        [OperationContract]
        public void CampoCultivo_Grabar(SGF_CampoCultivo newCampoCultivo, string user, string ip)
        {
            DataModel model = new DataModel();
            model.SGF_CampoCultivo.AddObject(newCampoCultivo);
            model.SaveChanges();
        }
        [OperationContract]
        public SGF_CampoCultivo CampoCultivo_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_CampoCultivo.First(x=>x.CampoCultivoID== id);
        }
        #endregion
        #region Cultivo Areas
        [OperationContract]
        public void CultivoArea_Grabar(SGF_CultivoArea newCampoCultivo, string user, string ip)
        {
            DataModel model = new DataModel();
            model.SGF_CultivoArea.AddObject(newCampoCultivo);
            model.SaveChanges();
        }
        [OperationContract]
        public SGF_CultivoArea CultivoArea_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_CultivoArea.First(x => x.CultivoAreaID == id);
        }

        #endregion
        #region Cultivo Bloques
        [OperationContract]
        public void CultivoBloque_Grabar(SGF_CultivoBloque newCampoCultivo, string user, string ip)
        {
            DataModel model = new DataModel();
            model.SGF_CultivoBloque.AddObject(newCampoCultivo);
            model.SaveChanges();
        }
        [OperationContract]
        public SGF_CultivoBloque CultivoBloque_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_CultivoBloque.First(x => x.CultivoBloqueID == id);
        }

        #endregion
        #region Cultivo Lados
        [OperationContract]
        public void CultivoLado_Grabar(SGF_CultivoLado newCampoCultivo, string user, string ip)
        {
            DataModel model = new DataModel();
            model.SGF_CultivoLado.AddObject(newCampoCultivo);
            model.SaveChanges();
        }
        [OperationContract]
        public SGF_CultivoLado CultivoLado_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_CultivoLado.First(x => x.CultivoLadoID == id);
        }

        #endregion
        #region Cultivo Naves
        [OperationContract]
        public void CultivoNave_Grabar(SGF_CultivoNave newCampoCultivo, string user, string ip)
        {
            DataModel model = new DataModel();
            model.SGF_CultivoNave.AddObject(newCampoCultivo);
        }
        [OperationContract]
        public SGF_CultivoNave CultivoNave_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_CultivoNave.First(x => x.CultivoNaveID == id);
        }
        #endregion
        #region Cultivo Camas
        [OperationContract]
        public void CultivoCama_Grabar(SGF_CultivoCama newCampoCultivo, string user, string ip)
        {
            DataModel model = new DataModel();
            model.SGF_CultivoCama.AddObject(newCampoCultivo);
        }
        [OperationContract]
        public SGF_CultivoCama CultivoCama_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_CultivoCama.First(x => x.CultivoCamaID == id);
        }
        #endregion
        #region Cultivo Cuadros
        [OperationContract]
        public void CultivoCuadro_Grabar(SGF_CultivoCuadro newCampoCultivo, string user, string ip)
        {
            DataModel model = new DataModel();
            model.SGF_CultivoCuadro.AddObject(newCampoCultivo);
        }
        [OperationContract]
        public SGF_CultivoCuadro CultivoCuadro_ObtenerPorID(Guid id)
        {
            DataModel model = new DataModel();
            return model.SGF_CultivoCuadro.First(x => x.CultivoCuadroID == id);
        }
        #endregion
    }
}
