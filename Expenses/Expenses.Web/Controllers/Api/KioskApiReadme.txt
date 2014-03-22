KIOSK API SAMPLES

== Get list of expenses

 Gets expense state.

 Specs: JSON result, HTTP GET
 Url: http://{url}/api/kioskexpenses


 Samples:
  curl http://{url}/api/kioskexpenses

== Get expense state

 Gets expense state.

 Specs: JSON result, HTTP GET
 Url: http://{url}/api/kiosk/{expenseId}


 Samples:
  curl http://{url}/api/kiosk/1

== Insert expense item row

 Inserts new expense item row.

 Specs: no result, HTTP POST
 Url: http://{url}/api/kioskaddrow + JSON data

 Samples:
  
  Insert expense row in behalf of existing user:
   curl -X POST -d "{"ExpenseId":1,"Quantity":0.5,"UserId":1}" http://{url}/api/kioskaddrow -H "Content-Type:application/json"
  
  Insert expense row as new user:
   curl -X POST -d "{"ExpenseId":1,"Quantity":0.5,"UserFullName":'JohnSmith'}" http://{url}/api/kioskaddrow -H "Content-Type:application/json"

== Image URLs

  Get expense image by IconId.
  Specs: PNG content result, HTTP GET
  Url: http://{url}/ExpenseIcon/GetFile/{iconId}
