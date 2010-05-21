using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
   public class BrancheBL : InterfaceDataLayers.BrancheInterface
    {
        DataAccessLayers.BrancheDAL dataAccess = new DataAccessLayers.BrancheDAL();
        #region BrancheInterface Members

        public IList<DataModelLayers.BrancheInfo> getListBranches()
        {
            return dataAccess.getListBranches();
        }

        public IList<DataModelLayers.BrancheInfo> getBranchesDetail(string _branchePin)
        {
            return dataAccess.getBranchesDetail(_branchePin);
        }

        public IList<DataModelLayers.BrancheInfo> searchBranches(string _brancheName)
        {
            return dataAccess.searchBranches(_brancheName);
        }

        public bool InsertBranche(DataModelLayers.BrancheInfo info)
        {
            return dataAccess.InsertBranche(info);
        }

        public bool UpdateBranche(DataModelLayers.BrancheInfo info)
        {
            return dataAccess.UpdateBranche(info);
        }

        public bool DeleteBranche(string _branchePin)
        {
            return dataAccess.DeleteBranche(_branchePin);
        }

        public DataModelLayers.BrancheInfo getBrancheInfo(string _branchePin)
        {
            return dataAccess.getBrancheInfo(_branchePin);
        }

        #endregion
    }
}