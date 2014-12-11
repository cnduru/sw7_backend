import socket
import time
from progressTrack import Progress
from matplotlib import pyplot


def run(duration):
    res = []
    end = time.time() + duration
    p = Progress(duration)
    while time.time() < end:
        try:
            s = socket.socket()
            t = time.time()
            s.connect(("192.168.43.3", 11000))
            s.send(b"<Login><Username>name</Username><Password>qwerty</Password></Login><EOF>")
            data = s.recv(1024)
            res.append(time.time() - t)
            time.sleep(1)
            p.percent(int(duration - (end - time.time())))
        except ConnectionResetError:
            continue
        if not data:
            print("error")
            break
    return res


data = run(60*10)
pyplot.plot(data, label="Without Load")
input("Press any key to continue...")
data = run(60*10)
pyplot.plot(data, label="With Load")
pyplot.ylabel('Latency ms')
pyplot.savefig('latency_load.pdf')


#s.connect(("192.168.43.49", 11000))
#while 1:

# mes = """<JoinGame><UserId>1</UserId><GameId>1</GameId></JoinGame><EOF>"""
# #mes = """<Login><Username>name</Username><Password>qwerty</Password></Login><EOF>"""
#
# s.send(bytes(mes, 'UTF-8'))
# while 1:
#     data = s.recv(1024)
#     if not data:
#         break
#     print(str(data))
#
#
# def foo(index, td):
#     i = 0
#     while 1:
#         s = socket.socket()
#         t = time.time()
#         s.connect(("192.168.43.56", 11000))
#         s.send(b"<Login><Username>name</Username><Password>qwerty</Password></Login>" + b"<EOF>")
#         data = s.recv(1024)
#         td.append(time.time() - t)
#         time.sleep(.5)
#         i += 1
#
#         if not data:
#             print("error", index)
#             break
# i = 1
# stats = {}
# highest = 0
# #while True:
# stats[i] = []
# t = threading.Thread(target=foo, args=(i, stats[i],))
# t.setDaemon(True)
# t.start()
# print(i)
#
#     #  i += 1
#
# while True:
#     time.sleep(1)
#     print("")
#     print(sum(stats[1])/len(stats[1]))
#     print(max(stats[1]))
#     #print(highest)
#     #if highest < max(stats[1]):
#     #    highest = max(stats[1])
#     #print(stats[1])