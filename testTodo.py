import requests
#11 is id
#post reqest
data = {'name':'Olivia','isComplete':True}
r = requests.post('https://localhost:44309/api/TodoItems',json = data, verify=False)
print(r.text)
#put request 
data = {'id':11,'name':'again','isComplete':True}
r = requests.put('https://localhost:44309/api/TodoItems/11',json = data, verify=False)
print(r.text)
#delete request
print(requests.delete('https://localhost:44309/api/TodoItems/11',verify = False)).text

