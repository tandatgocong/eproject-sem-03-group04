using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelLayers;

namespace InterfaceDataLayers
{
    public interface IFeedback
    {
        List<FeedbackInfo> getListFeedback();
        IList<FeedbackInfo> getFeedbackDetail(string _Id);
        IList<FeedbackInfo> searchFeedback(string _Subject);
        bool InsertFeedback(FeedbackInfo info);
        bool UpdateFeedback(FeedbackInfo info);
        bool DeleteFeedback(string _Id);
        FeedbackInfo getFeedbackInfo(string _Id);
    }
}
