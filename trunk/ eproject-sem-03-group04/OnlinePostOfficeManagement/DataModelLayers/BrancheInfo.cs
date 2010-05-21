using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class BrancheInfo
    {
        private string branchePin;
        public string BranchePin
        {
            get { return branchePin; }
            set { branchePin = value; }
        }
        private string brancheName;
        public string BrancheName
        {
            get { return brancheName; }
            set { brancheName = value; }
        }
        private string brancheAddress;
        public string BrancheAddress
        {
            get { return brancheAddress; }
            set { brancheAddress = value; }
        }
        private string branchePhone;
        public string BranchePhone
        {
            get { return branchePhone; }
            set { branchePhone = value; }
        }
        public BrancheInfo()
        {
            BranchePin = null;
            BrancheName = null;
            BrancheAddress = null;
            BranchePhone = null;
        }
        public BrancheInfo(string _branchePin, string _brancheName, string _brancheAddress, string _branchePhone)
        {
            BranchePin = _branchePin;
            BrancheName = _brancheName;
            BrancheAddress = _brancheAddress;
            BranchePhone = _branchePhone;
        }

    }
}
