using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayers;
namespace BusinessLayers
{
    public class OfficeBL : InterfaceDataLayers.IOffices
    {
        OfficeDAL office = new OfficeDAL();
        #region IOffices Members

        public IList<DataModelLayers.OfficeInfo> getListOffice()
        {
            return office.getListOffice();
        }

        public IList<DataModelLayers.OfficeInfo> getOfficeDetail(string _officeId)
        {
            return office.getOfficeDetail(_officeId);
        }

        public IList<DataModelLayers.OfficeInfo> searchOffice(string _officeName)
        {
            return office.searchOffice(_officeName);
        }

        public bool InsertOffice(DataModelLayers.OfficeInfo info)
        {
            return office.InsertOffice(info);
        }

        public bool UpdateOffice(DataModelLayers.OfficeInfo info)
        {
            return office.UpdateOffice(info);
        }

        public bool DeleteOffice(string _OfficeId)
        {
            return office.DeleteOffice(_OfficeId);
        }

        public DataModelLayers.OfficeInfo getOfficeInfo(string _OfficeId)
        {
            return office.getOfficeInfo(_OfficeId);
        }

        #endregion
    }

}
