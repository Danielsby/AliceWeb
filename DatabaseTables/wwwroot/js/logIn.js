/**
 * JQUERY
 */

// const uri = "api/command";
// let todos = null;

// Boilerplate JQuery request. 
function LogIn() {
    $.ajax({
        type: "POST",
        // accepts: "application/json"
        url: "api/login",
        username: username,
        password: password,
        contentType: "application/json",
        data: JSON.stringify(item), // Send usernamea and password.
        error: function (jqXJR, txtStatus, errorThrown) {
            alert("Something went wrong!");
        },
        success: function (result) {
            getData();
        }
    })
}