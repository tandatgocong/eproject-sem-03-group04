using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayers
{
    public class FeedbackBL : InterfaceDataLayers.IFeedback
    {
        #region IFeedback Members
        DataAccessLayers.FeedbackDAL feedback = new DataAccessLayers.FeedbackDAL();
        public List<DataModelLayers.FeedbackInfo> getListFeedback()
        {
            return feedback.getListFeedback();
        }

        public IList<DataModelLayers.FeedbackInfo> getFeedbackDetail(string _Id)
        {
            return feedback.getFeedbackDetail(_Id);
        }

        public IList<DataModelLayers.FeedbackInfo> searchFeedback(string _Subject)
        {
            return feedback.searchFeedback(_Subject);
        }

        public bool InsertFeedback(DataModelLayers.FeedbackInfo info)
        {
            return feedback.InsertFeedback(info);
        }

        public bool UpdateFeedback(DataModelLayers.FeedbackInfo info)
        {
            return feedback.UpdateFeedback(info);
        }

        public bool DeleteFeedback(string _Id)
        {
            return feedback.DeleteFeedback(_Id);
        }

        public DataModelLayers.FeedbackInfo getFeedbackInfo(string _Id)
        {
            return feedback.getFeedbackInfo(_Id);
        }

        #endregion
    }
}
