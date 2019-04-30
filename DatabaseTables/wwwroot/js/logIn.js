/**
 * Put username and password,
 * inside the user table with Ajax. 
 */
function testFunction() {
    var xhttp = new XMLHttpRequest();
    // console.log("User: "); <-- Test-function. 
    console.log(username_id);
    console.log("tries to log in");
    
    // Receive and treat the response from the backend. 
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log(this.responseText);
        }
    };

    // Send request. 
    // xhttp.open("GET", "http://localhost:5000/api/commands/1", true);

    // Redirect to the front-page. <-- Happens in the backend?
    xhttp.send();
}