using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
    public class BranchInfo
    {
        private string branchPin;
        public string BranchPin
        {
            get { return branchPin; }
            set { branchPin = value; }
        }
        private string branchName;
        public string BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }
        private string branchAddress;
        public string BranchAddress
        {
            get { return branchAddress; }
            set { branchAddress = value; }
        }
        private string branchPhone;
        public string BranchPhone
        {
            get { return branchPhone; }
            set { branchPhone = value; }
        }
        public BranchInfo()
        {
            BranchPin = null;
            BranchName = null;
            BranchAddress = null;
            BranchPhone = null;
        }
        public BranchInfo(string _branchPin, string _branchName, string _branchAddress, string _branchPhone)
        {
            BranchPin = _branchPin;
            BranchName = _branchName;
            BranchAddress = _branchAddress;
            BranchPhone = _branchPhone;
        }

    }
}
