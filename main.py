import requests

data = {'VtuberID':12345,'Name':"test name"}
r = requests.post('https://localhost:44350/api/Vtubers',json = data, verify=False)
print(r.text)

data = {'TipID':1588415265112100005,'VtuberID':12345,'WatcherID':43215,'WatcherName':"test watcher name",'Timestamp':1532423,'Price':200}
r = requests.post('https://localhost:44350/api/Tips',json = data, verify=False)
print(r.text)
data = {'name':"newPerson"}
r = requests.post('https://127.0.0.1:5000/person',json = data, verify=False)
print(r.text)
