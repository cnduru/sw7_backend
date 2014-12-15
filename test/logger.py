import socket
import time
from progressTrack import Progress
from matplotlib import pyplot
from doablethings import Actions
from statistics import pstdev, mean


ip = "192.168.43.3"
port = 11000
ip_port = (ip, port)

def run_test(no_calls):
    global ip, port

    p = Progress(no_calls)
    do = Actions(ip, port)
    runtime = []
    for i in range(no_calls):
        runtime.append(do.login()[0])
        p.percent(i)
    return runtime

def log_tests():
    no_of_tests = 1000
    res = run_test(1000)
    res_mean = mean(res)
    res_pstdev = pstdev(res, res_mean)
    over_one_sec = 0

    with open("result.csv", "w+") as f:
        for r in res:
            f.write(r + "\n")
            if r > 1:
                over_one_sec += 1

        # Number of tests, mean, standard deviation
        #f.write(no_of_tests, res_mean, res_pstdev + "\n")
        #pyplot.plot(data, label="Without Load")

        #pyplot.legend(loc='best')
        #pyplot.ylabel('Latency/ms')
        #pyplot.xlabel("Time/seconds")
        #pyplot.savefig('latency_load.pdf', )
    print("# calls, Mean, Std. dev, # over 1000ms, Max")
    print(no_of_tests, res_mean, res_pstdev, over_one_sec, max(res))

#def run(duration):
#    global ip_port
#    res = []
#    end = time.time() + duration
#    errors = 0
#    p = Progress(duration)
#    while time.time() < end:
#        try:
#            s = socket.socket()
#            t = time.time()
#            s.connect(ip_port)
#            s.send(b"<Login><Username>name</Username><Password>qwerty</Password></Login><EOF>")
#            data = s.recv(1024)
#            res.append(time.time() - t)
#            time.sleep(1)
#            p.percent(int(duration - (end - time.time())))
#            if not data:
#                print("error")
#                break
#        except ConnectionResetError:
#            errors += 1

#    return res, errors


#def scale_test():
#    with open("data.txt", "w+") as f:
#        data, er = run(60)
#        print("Errors:", er)

#        f.write("errors: " + str(er) + " Res: " + ','.join(map(str, data)) + "\n")
#        pyplot.plot(data, label="Without Load")

#        input("Press enter to continue...")

#        data, er = run(60)
#        print("Errors:", er)
#        f.write("errors: " + str(er) + " Res: " + ','.join(map(str, data)) + "\n")
#        pyplot.plot(data, label="With Load", c="red")

#        pyplot.legend(loc='best')
#        # pyplot.yscale('log')
#        pyplot.ylabel('Latency/ms')
#        pyplot.xlabel("Time/seconds")
#        pyplot.savefig('latency_load.pdf', )


#def single(mes):
#    global ip_port
#    s = socket.socket()
#    s.connect(ip_port)
#    s.send(mes)
#    return s.recv(1024)

#mes = []
#mes.append(b"""<Login><Username>name</Username><Password>qwerty</Password></Login><EOF>""")
#mes.append(b"""<JoinGame><UserId>1</UserId><GameId>1</GameId></JoinGame><EOF>""")
#mes.append(b"""<CreateGame>
#   <Name>A new game</Name>
#   <Privacy>1</Privacy>
#   <NumberOfTeams>0</NumberOfTeams>

#   <GameStart>
#      <Year>2014</Year>
#      <Month>12</Month>
#      <Day>31</Day>
#      <Hour>23</Hour>
#      <Minute>59</Minute>
#   </GameStart>
#   <GameEnd>
#      <Year>2015</Year>
#      <Month>1</Month>
#      <Day>31</Day>
#      <Hour>23</Hour>
#      <Minute>59</Minute>
#   </GameEnd>
#   <SouthEastBoundary>
#      <Latitude>57.0046047</Latitude>
#      <Longitude>9.8616402</Longitude>
#   </SouthEastBoundary>
#   <NorthWestBoundary>
#      <Latitude>57.0786811</Latitude>
#      <Longitude>9.9666766</Longitude>
#   </NorthWestBoundary>
#   <HostId>1</HostId>
#</CreateGame>
#<EOF>""")

#print("hello");

#print(single(mes[2]))
