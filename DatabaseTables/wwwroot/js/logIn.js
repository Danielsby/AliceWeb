/**
 * JQUERY
 */

$("test").click(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "http://localhost:5000/api/users/authenticate",
        data: { username: "admin", password: "admin" },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) 
            console.log(data);
    });
});
