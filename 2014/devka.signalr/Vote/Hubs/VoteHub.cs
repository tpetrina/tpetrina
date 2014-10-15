using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Vote.Hubs
{
    class VoteProfile
    {
        public string Area { get; set; }

        public HashSet<string> Languages { get; set; }
        public HashSet<string> Interests { get; set; }

        public VoteProfile()
        {
            Languages = new HashSet<string>();
            Interests = new HashSet<string>();
        }
    }

    [HubName("Vote")]
    public class VoteHub : Hub
    {
        private static object _syncLock = new object();
        private static Dictionary<string, VoteProfile> _votes;

        static VoteHub()
        {
            _votes = new Dictionary<string, VoteProfile>();
        }

        public void Area(string areaName)
        {
            lock (_syncLock)
            {
                if (!_votes.ContainsKey(Context.ConnectionId))
                    _votes.Add(Context.ConnectionId, new VoteProfile());

                _votes[Context.ConnectionId].Area = areaName;

                UpdateAreas();
            }
        }

        public void Lang(string lang, string isChecked)
        {
            lock (_syncLock)
            {
                if (!_votes.ContainsKey(Context.ConnectionId))
                    _votes.Add(Context.ConnectionId, new VoteProfile());

                if (isChecked.ToLowerInvariant() == "true")
                    _votes[Context.ConnectionId].Languages.Add(lang);
                else
                    _votes[Context.ConnectionId].Languages.Remove(lang);

                UpdateLanguages();
            }
        }

        public void Interest(string interest, string isChecked)
        {
            lock (_syncLock)
            {
                if (!_votes.ContainsKey(Context.ConnectionId))
                    _votes.Add(Context.ConnectionId, new VoteProfile());

                if (isChecked.ToLowerInvariant() == "true")
                    _votes[Context.ConnectionId].Interests.Add(interest);
                else
                    _votes[Context.ConnectionId].Interests.Remove(interest);

                UpdateInterests();
            }
        }

        private void UpdateInterests()
        {
            Clients.All.UpdateInterests(
                _votes
                    .SelectMany(i => i.Value.Interests)
                    .GroupBy(i => i)
                    .ToDictionary(i => i.Key, i => i.Count()));
        }

        private void UpdateLanguages()
        {
            Clients.All.UpdateLanguages(
                _votes
                    .SelectMany(i => i.Value.Languages)
                    .GroupBy(i => i)
                    .ToDictionary(i => i.Key, i => i.Count()));
        }

        private void UpdateAreas()
        {
            Clients.All.UpdateAreas(_votes.Count,
                new[]
                {
                    _votes.Values.Count(i => i.Area == "programiranje"),
                    _votes.Values.Count(i => i.Area == "administracija"),
                    _votes.Values.Count(i => i.Area == "obrazovanje"),
                    _votes.Values.Count(i => i.Area == "drugo")
                });
        }

        public override Task OnConnected()
        {
            lock (_syncLock)
            {
                UpdateAreas();
                UpdateLanguages();
                UpdateInterests();
            }
            return base.OnConnected();
        }
    }
}