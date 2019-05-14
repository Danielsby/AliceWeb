// Request sender and request reponse recipient. 
// By successful login - redirect to frontpage. 

/* Test function. */
// window.alert("Utenfor submit funksjonen.");

/* Send a login request from the form.  */

var post = function() {

    /* Get username and password from the fields. */
    var credentials = {
        username: document.getElementById("username").value,
        password: document.getElementById("password").value
    }

    window.alert("username is: " + credentials.username +
        " your password is " + credentials.password);

    console.log("Før ajax.");

    // Ajax request. 
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5000/api/users',
        contentType: "application/json",
        dataType: "json", //Expected data format from server  
        data: { username: credentials.username, password: credentials.password },
        success: function (Data) {

            console.log("response succeed.");
            // Redirect to frontpage. 
            // window.location.href = "http://localhost:5000/FrontPage.html";

            // Store the token. 
            // window.localStorage.setItem('token', Data.token);

        },
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', window.localStorage.getItem('token'));
        },

        error: function () {
            alert('Error occured');
        }
    });
}


/*
$.ajax({
    type: 'GET',
    url: 'http://localhost:5000/api/owner/test',
    // data: { username: credentials.username, password: credentials.password },
    success: function (Data) {

        // Data.
        console.log("inside success");
        console.log(Data);

        // Redirect to frontpage.
        window.location.href = "http://localhost:5000/FrontPage.html";

        // TODO: Store the token.
        window.localStorage.setItem('token', Data.token);

    }/*,
    beforeSend: function (xhr) {
        // xhr.setRequestHeader('Authorization', window.localStorage.getItem('token'));
    },

    error: function () {
        alert('Error occured');
    }
});
*/