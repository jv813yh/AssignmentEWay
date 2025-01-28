using AssignmentEWay.Data.Models;

namespace AssignmentEWay.Data.Interfaces
{
    public interface IDataHistoryService
    {
        void SaveHistory(IEnumerable<VisitHistoryContact> history);
        List<VisitHistoryContact>? LoadHistory();
    }
}
