#https://pypi.org/project/websocket_client/
import websocket
from os import system
import json
from threading import Thread

tickers = {}
positions = {}

def main():
    print("Main")
    temp = open('config.txt').read().splitlines()
    for line in temp:
        tickers[line] = int(0)
        print(line)

def on_message(ws, message):
    out = json.loads(message)
    if "data" in out:
        #_ = system('clear')
        changed = bool(False)
        for i in out["data"]:
            if i["s"] in tickers:
                if tickers[i["s"]] != i["p"]:
                    changed = bool(True)
                    tickers[i["s"]] = i["p"]
        if bool(changed):
            output = "-------------------------\n"
            for j in tickers:
                 output = output + "|  {ticker} : {tickerName}  |\n".format(ticker = j, tickerName = tickers[j])
            print(output + "-------------------------")

def on_error(ws, error):
    print(error)

def on_close(ws):
    print("### closed ###")

def on_open(ws):
    print("Open")
    for symbol in tickers:
        req = '{"type":"subscribe","symbol":"' + symbol + '"}'
        print(req)
        ws.send(req)
        #print(req)

if __name__ == "__main__":
    main()
    websocket.enableTrace(True)
    ws = websocket.WebSocketApp("wss://ws.finnhub.io?token=bqcbvffrh5rafsamfti0",
                              on_message = on_message,
                              on_error = on_error,
                              on_close = on_close)
    ws.on_open = on_open

    thread = Thread(target=ws.run_forever, args=(None, None, 60, 30))
    thread.start()

def buy(price, ticker):
    positions['ticker'] = price

#def sell(price, ticker):


