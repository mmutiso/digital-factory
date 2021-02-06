using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IOUTracker.Models
{
    public class UserSummaryModel
    {

        public UserSummaryModel(string name, ICollection<IOU> lenders, ICollection<IOU> borrowers)
        {
            Name = name;
            var lendersDict = new Dictionary<string, double>();
            lenders.ToList().ForEach(x =>
            {
                lendersDict.Add(x.LenderId, x.Amount);
            });
            Owes = lendersDict;
            var borrowersDict = new Dictionary<string, double>();

            borrowers.ToList().ForEach(x =>
            {
                borrowersDict.Add(x.BorrowerId, x.Amount);
            });

            OwedBy = borrowersDict;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        public IDictionary<string, double> Owes { get; set; }
        [JsonPropertyName("owed_by")]
        public IDictionary<string, double> OwedBy { get; set; }
        [JsonPropertyName("balance")]
        public double Balance => OwedBy.Values.Sum() - Owes.Values.Sum();
    }
}
