using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class SystemsBL : InterfaceDataLayers.ISystems
    {
        #region ISystems Members
        DataAccessLayers.SystemsDAL system = new DataAccessLayers.SystemsDAL();
        public List<DataModelLayers.SystemsInfo> getListRole()
        {
            return system.getListRole();
        }

        public IList<DataModelLayers.SystemsInfo> getRoleDetail(string _Id)
        {
            return system.getRoleDetail(_Id);
        }

        public IList<DataModelLayers.SystemsInfo> searchRole(string _roleName)
        {
            return system.searchRole(_roleName);
        }

        public bool InsertRole(DataModelLayers.SystemsInfo info)
        {
            return system.InsertRole(info);
        }

        public bool UpdateRole(DataModelLayers.SystemsInfo info)
        {
            return system.UpdateRole(info);
        }

        public bool DeleteRole(string _Id)
        {
            return system.DeleteRole(_Id);
        }

        public DataModelLayers.SystemsInfo getRoleInfo(string _Id)
        {
            return system.getRoleInfo(_Id);
        }

        public void CountNumberVisits()
        {
            system.CountNumberVisits();
        }

        #endregion



        #region ISystems Members


        public string WebLogin(string username, string password)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
