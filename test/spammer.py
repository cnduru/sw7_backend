import socket
import time
import threading

mes = b"""<JoinGame><UserId>1</UserId><GameId>1</GameId></JoinGame><EOF>"""
#mes = """<Login><Username>name</Username><Password>qwerty</Password></Login><EOF>"""


def spam(index):
    while 1:
        try:
            s = socket.socket()
            s.connect(("192.168.43.3", 11000))
            s.send(mes)
            data = s.recv(1024)
            time.sleep(.5)
        except ConnectionResetError:
            continue

        if not data:
            print("error", index)
            break

for i in range(300):
    t = threading.Thread(target=spam, args=(i,))
    t.setDaemon(True)
    t.start()
    print(i)

while True:
    pass