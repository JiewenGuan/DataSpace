data = {'name':'Olivia','isComplete':True}
r = requests.post('https://localhost:44342/api/Roles',json = data, verify=False)
print(r.text)