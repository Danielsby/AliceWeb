/**
 * Put username and password,
 * inside the user table with Ajax. 
 */

function requestToBackend() {
    var xhttp = new XMLHttpRequest();

    /* Receive and treat the response. */ 
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status = 200) {
            document.getElementById("result").innerHTML = this.responseText;
        }
    };

    /* Send request. */ 
    xhttp.open("GET", "api/commands/{$id}", true);
    xhttp.send();
}