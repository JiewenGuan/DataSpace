import requests

# get request can be performed with url in chrome, install json extension for better view
# 'https://<IP>/api/<ControllerName>' for getAll 
# and 'https://<IP>/api/<ControllerName>/<id>' for getID
# use the get result json as template to replace $data to make other request
# !!!!!!do not make delete request to existing objects, try them on the object you created.
# as the server is hosted on my desktop, ip will be proveded upon request
#post request
data = {'name':'Olivia','isComplete':True}
r = requests.post('https://<IP>/api/<ControllerName>',json = data, verify=False)
print(r.text)
#put request 
data = {'id':11,'name':'again','isComplete':True}
r = requests.put('https://<IP>/api/<ControllerName>/<id>',json = data, verify=False)
print(r.text)
#delete request
print(requests.delete('https://<IP>/api/<ControllerName>/<id>',verify = False)).text

