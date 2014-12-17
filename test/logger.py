import socket
import time
from progressTrack import Progress
from matplotlib import pyplot
from doablethings import Actions
from statistics import pstdev, mean


ip = "192.168.43.56"
port = 11000
ip_port = (ip, port)

apicall = {0: "Login",
           1: "Public games",
           2: "Joined games",
           3: "Create game",
           4: "Join game",
           5: "Lobbyinfo",
           6: "Invite",
           7: "Position",
           8: "Shoot",
           9: "Leave game",
           10: "Delete game",
    }

def run_test(no_calls):
    global ip, port

    p = Progress(no_calls, "Done")
    do = Actions(ip, port)

    runtime = []
    for i in range(11):
        runtime.append([])

    p.percent(0)
    for i in range(no_calls):
        

        #Login
        runtime[0].append(do.login()[0])
        time.sleep(0.50)

        #Public games
        runtime[1].append(do.get_public_games()[0])
        time.sleep(0.50)

        #Joined games
        runtime[2].append(do.get_joined_games()[0])
        time.sleep(0.50)

        #Create game
        runtime[3].append(do.create_game()[0])
        time.sleep(0.50)

        #Join game
        runtime[4].append(do.join_game()[0])
        time.sleep(0.50)

        #Lobbyinfo
        runtime[5].append(do.lobbyinfo()[0])
        time.sleep(0.50)

        #Invite player
        runtime[6].append(do.invite_somebody()[0])
        time.sleep(0.50)

        #Change position
        runtime[7].append(do.change_coordinates()[0])
        time.sleep(0.50)

        #Shoot
        runtime[8].append(do.shoot_somebody()[0])
        time.sleep(0.50)

        #Leave Game
        runtime[9].append(do.leave_game()[0])
        time.sleep(0.50)

        #Delete game
        runtime[10].append(do.delete_game()[0])
        time.sleep(0.50)

        p.percent(i+1)

    return runtime

def oops_reload_files():
    global apicall

    results = []

    for i in range(11):
        results.append([])

        fname = "test1/result" + str(i) + ".csv"
        with open(fname, "r") as f:
            for l in f.readlines():
                results[i].append(float(l[:-1]))

    return results

def log_tests(no_of_tests):
    global apicall

    print("Tests will finish around:", time.strftime('%Y-%m-%d %H:%M:%S', time.localtime(time.time() + no_of_tests*6)))

    results = run_test(no_of_tests)

    for i, res in enumerate(results):
        res_mean = mean(res)
        res_pstdev = pstdev(res, res_mean)
        over_one_sec = 0
        timeout = 0


        fname = "result" + str(i) + ".csv"
        with open(fname, "w+") as f:
            for r in res:
                print(i, r)
                f.write(str(r) + "\n")
                if r > 0.5:
                    over_one_sec += 1
                if r == -1.0:
                    timeout += 1
                    
        #Remove all timeouts/errors (-1.0)
        res = list(filter(lambda x: x >= 0, res))
        
        fname2 = "result-summary.csv"
        with open(fname2, "a") as f2:
            f2.write(apicall[i] + "; " + str(len(res)) + "; " + str(res_mean) + "; " + str(res_pstdev) + "; " + str(over_one_sec) + "; " + str(max(res)) + "; " + str(timeout) + "\n")

log_tests(1000)






            # Number of tests, mean, standard deviation
            #f.write(no_of_tests, res_mean, res_pstdev + "\n")
            #pyplot.plot(data, label="Without Load")

            #pyplot.legend(loc='best')
            #pyplot.ylabel('Latency/ms')
            #pyplot.xlabel("Time/seconds")
            #pyplot.savefig('latency_load.pdf', )
        #print("# calls, Mean, Std. dev, # over 1000ms, Max")
        #print(i, no_of_tests, res_mean, res_pstdev, over_one_sec, max(res))

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
