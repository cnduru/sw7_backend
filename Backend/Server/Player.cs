using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    class Player {

        string Username;
        int ActiveGame = 0;
        Coordinate Position = null;
        bool Connected = false;
        List<int> Lobbies = new List<int>();

        public Player(string username) {
            Username = username;
        }

        public void JoinGame(int game) {
            ActiveGame = game;
        }

        public void LeaveGame() {
            ActiveGame = 0;
        }

        public void UpdatePosition(Coordinate position) {
            Position = position;
        }

        public void Connect() {
            Connected = true;
        }

        public void Disconnect() {
            Connected = false;
            Position = null;
        }

        public void AddLobby(int preferenceId) {
            Lobbies.Add(preferenceId);
        }

        public void RemoveLobby(int preferenceId) {
            Lobbies.Remove(preferenceId);
        }

        public string GetUsername() {
            return Username;
        }

        public int GetActiveGame() {
            return ActiveGame;
        }

        public Coordinate GetPosition() {
            if (Connected) {
                return Position;
            } else {
                return null;
            }
        }

        public bool GetConnectionStatus() {
            return Connected;
        }
    }
}
