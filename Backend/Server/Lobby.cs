using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Server {
    class Lobby {
        bool HasTimeLimit;
        TimeSpan TimeLimit;
        bool IsPrivateGame;
        BoundingBox GameBoundries;
        int NumberOfTeams;

        List<Player> TeamA = new List<Player>();
        List<Player> TeamB = new List<Player>();
        List<Player> TeamC = new List<Player>();
        List<Player> TeamD = new List<Player>();
        List<Player> NoTeamChosen = new List<Player>();

        public Lobby(TimeSpan timeLimit, bool isPrivateGame, BoundingBox gameBoundries, int numberOfTeams) {
            HasTimeLimit = true;
            TimeLimit = timeLimit;
            IsPrivateGame = isPrivateGame;
            GameBoundries = gameBoundries;
            NumberOfTeams = numberOfTeams;
        }

        public Lobby(bool isPrivateGame, BoundingBox gameBoundries, int numberOfTeams) {
            HasTimeLimit = false;
            IsPrivateGame = isPrivateGame;
            GameBoundries = gameBoundries;
            NumberOfTeams = numberOfTeams;
        }

        public void AcceptInvitation(string team, Player player) {
            switch (team) {
                case "A":
                    TeamA.Add(player);
                    break;
                case "B":
                    TeamB.Add(player);
                    break;
                case "C":
                    TeamC.Add(player);
                    break;
                case "D":
                    TeamD.Add(player);
                    break;
            }

            NoTeamChosen.Remove(player);
        }

        public void UninvitePlayer(Player player) {
            NoTeamChosen.Remove(player);
        }

        public void InvitePlayer(Player player) {
            //TODO: Notify player that he has been invited
            NoTeamChosen.Add(player);
        }
        public void SetNoTimeLimit() {
            HasTimeLimit = false;
            TimeLimit = new TimeSpan();
        }

        public void SetTimeLimit(TimeSpan timeLimit) {
            HasTimeLimit = true;
            TimeLimit = timeLimit;
        }

        public void SetPublic(bool privacy) {
            IsPrivateGame = privacy;
        }

        public void SetGameBoundries(BoundingBox boundries) {
            GameBoundries = boundries;
        }

        public void SetNumberOfTeams(int numberOfTeams) {
            NumberOfTeams = numberOfTeams;

            //TODO: Notify people who are about to get kicked from all teams
            NoTeamChosen.AddRange(TeamA);
            NoTeamChosen.AddRange(TeamB);
            NoTeamChosen.AddRange(TeamC);
            NoTeamChosen.AddRange(TeamD);
            TeamA.Clear();
            TeamB.Clear();
            TeamC.Clear();
            TeamD.Clear();
        }

        public bool GetHasTimeLimit() {
            return HasTimeLimit;
        }

        public TimeSpan GetTimeLimit() {
            return TimeLimit;
        }

        public bool GetIsPrivateGame() {
            return IsPrivateGame;
        }

        public BoundingBox GetGameBoundries() {
            return GameBoundries;
        }

        public int GetNumberOfTeams() {
            return NumberOfTeams;
        }
    }
}
