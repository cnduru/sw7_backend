import socket
import time
import threading
from doablethings import Actions

mes = b"""<JoinGame><UserId>1</UserId><GameId>1</GameId></JoinGame><EOF>"""


def spam(index):
    while 1:
        try:
            s = socket.socket()
            s.connect(("192.168.43.3", 11000))
            s.send(mes)
            time.sleep(.5)
            data = s.recv(1024)
        except ConnectionResetError:
            continue

        if not data:
            print("error", index)
            break


gametime = 10

def spam2(index, sec_per_game):
    do = Actions("192.168.43.56", 11000)
    do.all_the_things(sec_per_game)
    #try:
    #    do.all_the_things(sec_per_game)
    #except:
    #    print("Something bad happened in game", index)

start_time = time.time()
for i in range(500):
    t = threading.Thread(target=spam2, args=(i, gametime,))
    t.setDaemon(True)
    t.start()

while start_time + gametime > time.time():
    pass

print("Spam finished.")