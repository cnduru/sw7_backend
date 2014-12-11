import socket
import time
import threading

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

for i in range(100):
    t = threading.Thread(target=spam, args=(i,))
    t.setDaemon(True)
    t.start()

while True:
    pass