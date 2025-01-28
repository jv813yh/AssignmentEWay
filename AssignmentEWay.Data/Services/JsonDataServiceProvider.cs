using AssignmentEWay.Data.Interfaces;
using AssignmentEWay.Data.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AssignmentEWay.Data.Services
{
    public class JsonDataServiceProvider : IDataHistoryService
    {
        // 
        private string _fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "visit_history.json");

        /// <summary>
        /// Load history from file
        /// </summary>
        /// <returns></returns>
        public List<VisitHistoryContact>? LoadHistory()
        {
            try
            {
                if (File.Exists(_fullPath))
                {
                    var json = File.ReadAllText(_fullPath);
                    return JsonConvert.DeserializeObject<List<VisitHistoryContact>>(json);
                }

                return new List<VisitHistoryContact>();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving history");
                throw;
            }
        }

        /// <summary>
        /// Save history to file
        /// </summary>
        /// <param name="history"></param>
        public void SaveHistory(IEnumerable<VisitHistoryContact> history)
        {
            try
            {
                var json = JsonConvert.SerializeObject(history);
                File.WriteAllText(_fullPath, json);

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving history");
                throw;
            }
        }
    }
}
