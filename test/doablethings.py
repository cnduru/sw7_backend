import socket
import time
import xml.etree.ElementTree as ET
import random

class Actions():
    def __init__(self, ip, port):
        self.ip_port = (ip, port)


    def send_message(self, message):
        s = socket.socket()
        s.connect(self.ip_port)
        start_time = time.time()
        s.send(message)
        data = s.recv(1024)
        run_time = time.time() - start_time

        return run_time, data

    def login(self):
        login = b"<Login><Username>name</Username><Password>qwerty</Password></Login><EOF>"
        return self.send_message(login)

    def create_game(self):
        random.seed()
        creategame =b"""
        <CreateGame>
            <Name>""" + str.encode(str(random.randint(1,9999999999))) + b"""</Name>
            <Privacy>1</Privacy>
            <NumberOfTeams>0</NumberOfTeams>

            <GameStart>
                <Year>2014</Year>
                <Month>12</Month>
                <Day>31</Day>
                <Hour>23</Hour>
                <Minute>59</Minute>
            </GameStart>
            <GameEnd>
                <Year>2015</Year>
                <Month>1</Month>
                <Day>31</Day>
                <Hour>23</Hour>
                <Minute>59</Minute>
            </GameEnd>
            <SouthEastBoundary>
                <Latitude>57.0046047</Latitude>
                <Longitude>9.8616402</Longitude>
            </SouthEastBoundary>
            <NorthWestBoundary>
                <Latitude>57.0786811</Latitude>
                <Longitude>9.9666766</Longitude>
            </NorthWestBoundary>
            <HostId>1</HostId>
        </CreateGame>
        <EOF>"""

        t, data = self.send_message(creategame)
        try:
            root = ET.fromstring(data)  #remove eof tag
            self.game_id = str.encode(str(root.find(".//GameId").text))
        except:
            t = -1
        return t, data

    def delete_game(self):
        delete = b"<CloseGame><GameId>"+ self.game_id +b"</GameId></CloseGame><EOF>"
        return self.send_message(delete)

    def join_game(self):
        msg = b"<JoinGame><UserId>1</UserId><GameId>"+ self.game_id + b"</GameId></JoinGame><EOF>"
        return self.send_message(msg)

    def get_public_games(self):
        gpc = b"""
        <GetPublicGames>
        </GetPublicGames>
        <EOF>"""
        return self.send_message(gpc)

    def get_joined_games(self, user_id=1):
        gjg = b"""
        <GetMyGames>
            <UserId>""" + str.encode(str(user_id)) + b"""</UserId>
        </GetMyGames>
        <EOF>"""
        return self.send_message(gjg)

    def leave_game(self, userId = 1):
        msg = b"<LeaveGame><UserId>" + str.encode(str(userId)) + b"</UserId><GameId>2</GameId></LeaveGame><EOF>"
        return self.send_message(msg)

    def change_coordinates(self):
        random.seed()

        msg = b"<UpdatePlayerLocation><UserId>1</UserId><GameId>" + \
            self.game_id + b"</GameId><Latitude>" + str.encode(str(random.uniform(-90.0, 90.0))) + \
            b"</Latitude><Longitude>" + str.encode(str(random.uniform(-180.0, 180.0))) + b"</Longitude></UpdatePlayerLocation><EOF>"
        return self.send_message(msg)

    def shoot_somebody(self):
        msg = b"<ShootAction><GameId>"+ self.game_id + b"</GameId><UserId>1</UserId><Victim>2</Victim><ItemId>3</ItemId></ShootAction><EOF>"
        return self.send_message(msg)

    def invite_somebody(self):
        msg = b"<JoinGame><UserId>2</UserId><GameId>"+ self.game_id + b"</GameId></JoinGame><EOF>"
        return self.send_message(msg)

    def lobbyinfo(self):
        msg = b"<LobbyInfo><GameId>" + self.game_id + b"</GameId></LobbyInfo><EOF>"
        return self.send_message(msg)

    def all_the_things(self, duration):
        self.login()
        self.get_public_games()
        self.get_joined_games()
        if self.create_game()[0] == -1:
            print("Error creating game, aborting.")
            return

        self.join_game()
        self.lobbyinfo()
        self.invite_somebody()

        s_time = time.time()
        while s_time + duration > time.time():
            self.change_coordinates()
            self.shoot_somebody()
            time.sleep(1)

        self.leave_game()
        self.delete_game()



#do = Actions("192.168.43.3", 11000)

#do.login()