using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class SystemsInfo
    {
        private string roleId;
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public string RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        private string roleName;

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
        private string roleDecriptions;

        public string RoleDecriptions
        {
            get { return roleDecriptions; }
            set { roleDecriptions = value; }
        }
        public SystemsInfo()
        {
            this.RoleId = null;
            this.RoleName = null;
            this.RoleDecriptions = null;

        }
        public SystemsInfo(string _roleId, string _roleName, string _roleDecriptions)
        {
            this.RoleId = _roleId;
            this.RoleName = _roleName;
            this.RoleDecriptions = _roleDecriptions;
        }
        
    }
}
