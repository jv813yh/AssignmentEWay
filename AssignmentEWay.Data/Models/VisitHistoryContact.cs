namespace AssignmentEWay.Data.Models
{
    public class VisitHistoryContact
    {
        public string ItemGuid { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastVisitDate { get; set; } 
        public int Count { get; set; }
    }
}
