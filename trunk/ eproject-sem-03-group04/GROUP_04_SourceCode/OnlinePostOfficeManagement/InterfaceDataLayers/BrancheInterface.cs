using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface BrancheInterface
    {
        IList<BranchInfo> getListBranches();
        IList<BranchInfo> getBranchesDetail(string _branchePin);
        IList<BranchInfo> searchBranches(string _brancheName);
        bool InsertBranche(BranchInfo info);
        bool UpdateBranche(BranchInfo info);
        bool DeleteBranche(string _branchePin);
        BranchInfo getBrancheInfo(string _branchePin);
    }
}
