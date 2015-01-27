import socket
import time

ip = "192.168.43.56"
port = 11000
ip_port = (ip, port)

def single(mes):
   global ip_port
   s = socket.socket()
   s.connect(ip_port)
   s.send(mes)
   return s.recv(1024)


a = b"<UpdatePlayerLocation><UserId>1</UserId><GameId>1</GameId>" \
    b"<Latitude>57.017638</Latitude><Longitude>9.975122</Longitude></UpdatePlayerLocation><EOF>"
b = b"<UpdatePlayerLocation><UserId>1</UserId><GameId>1</GameId>" \
    b"<Latitude>57.0144801</Latitude><Longitude>9.9821516</Longitude></UpdatePlayerLocation><EOF>"
c = b"<UpdatePlayerLocation><UserId>1</UserId><GameId>1</GameId>" \
    b"<Latitude>57.0114801</Latitude><Longitude>9.9921516</Longitude></UpdatePlayerLocation><EOF>"

print(single(a))
time.sleep(5)
print(single(b))
time.sleep(5)
print(single(c))
