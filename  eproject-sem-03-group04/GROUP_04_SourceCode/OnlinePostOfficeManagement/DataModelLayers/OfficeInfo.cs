using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModelLayers
{
   public class OfficeInfo
    {
        private string offficeId;

        public string OffficeId
        {
            get { return offficeId; }
            set { offficeId = value; }
        }
        private string officeName;

        public string OfficeName
        {
            get { return officeName; }
            set { officeName = value; }
        }
        private string officePhone;
        private string officeAddress;

        public string OfficeAddress
        {
            get { return officeAddress; }
            set { officeAddress = value; }
        }
        public string OfficePhone
        {
            get { return officePhone; }
            set { officePhone = value; }
        }
        private string officeMail;

        public string OfficeMail
        {
            get { return officeMail; }
            set { officeMail = value; }
        }
        private string branchPin;

        public string BranchPin
        {
            get { return branchPin; }
            set { branchPin = value; }
        }
        public OfficeInfo()
        {
            this.OffficeId = null;
            this.OfficeName = null;
            this.OfficeAddress = null;
            this.OfficePhone = null;
            this.OfficeMail = null;
            this.BranchPin = null;
        }
        public OfficeInfo(string _OffficeId, string _OfficeName, string _OfficeAddress, string _OfficePhone, string _OfficeMail, string _BranchPin)
        {
            this.OffficeId = _OffficeId;
            this.OfficeName = _OfficeName;
            this.OfficeAddress = _OfficeAddress;
            this.OfficePhone = _OfficePhone;
            this.OfficeMail = _OfficeMail;
            this.BranchPin = _BranchPin;
        }
    }
}
