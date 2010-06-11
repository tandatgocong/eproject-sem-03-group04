using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface ISystems
    {
        List<SystemsInfo> getListRole();
        IList<SystemsInfo> getRoleDetail(string _Id);
        IList<SystemsInfo> searchRole(string _roleName);
        bool InsertRole(SystemsInfo info);
        bool UpdateRole(SystemsInfo info);
        bool DeleteRole(string _Id);
        SystemsInfo getRoleInfo(string _Id);
        void CountNumberVisits();
        string WebLogin(string username, string password);
        bool CheckAvailabilityEmail(string email);
    }
}
