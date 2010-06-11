using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
   public class BranchBL : InterfaceDataLayers.IBranch
    {
        DataAccessLayers.BranchDAL dataAccess = new DataAccessLayers.BranchDAL();
       #region IBranch Members

        public IList<DataModelLayers.BranchInfo> getListBranches()
        {
            return dataAccess.getListBranches();
        }

        public IList<DataModelLayers.BranchInfo> getBranchesDetail(string _branchePin)
        {
            return dataAccess.getBranchesDetail(_branchePin);
        }

        public IList<DataModelLayers.BranchInfo> searchBranches(string _brancheName)
        {
            return dataAccess.searchBranches(_brancheName);
        }

        public bool InsertBranche(DataModelLayers.BranchInfo info)
        {
            return dataAccess.InsertBranche(info);
        }

        public bool UpdateBranche(DataModelLayers.BranchInfo info)
        {
            return dataAccess.UpdateBranche(info);
        }

        public bool DeleteBranche(string _branchePin)
        {
            return dataAccess.DeleteBranche(_branchePin);
        }

        public DataModelLayers.BranchInfo getBrancheInfo(string _branchePin)
        {
            return dataAccess.getBrancheInfo(_branchePin);
        }

        #endregion

        #region IBranch Members


        public IList<DataModelLayers.BranchInfo> AdvancedSearch(string _brancheName, string _brancheAddress, string _branchePhone)
        {
            return dataAccess.AdvancedSearch(_brancheName, _brancheAddress, _branchePhone);
        }

        #endregion
    }
}