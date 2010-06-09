using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface IOffices
    {
        IList<OfficeInfo> getListOffice();
        IList<OfficeInfo> getOfficeDetail(string _officeId);
        IList<OfficeInfo> searchOffice(string _officeName);
        bool InsertOffice(OfficeInfo info);
        bool UpdateOffice(OfficeInfo info);
        bool DeleteOffice(string _OfficeId);
        OfficeInfo getOfficeInfo(string _OfficeId);
    }
}
