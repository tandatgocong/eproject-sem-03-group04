using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface BrancheInterface
    {
        IList<BrancheInfo> getListBranches();
        IList<BrancheInfo> getBranchesDetail(string _branchePin);
        IList<BrancheInfo> searchBranches(string _brancheName);
        bool InsertBranche(BrancheInfo info);
        bool UpdateBranche(BrancheInfo info);
        bool DeleteBranche(string _branchePin);
        BrancheInfo getBrancheInfo(string _branchePin);
    }
}
