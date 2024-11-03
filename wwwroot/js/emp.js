/*$("#test1").click(function () {
    var id = $(this).attr("data-value");
    Edit(id);
});

*//*$("#test").click(function () {
        var id = $(this).attr("data-value");*//*
function Edit(id){ 
        $.ajax({
            url: '/EmployeeModels/Edit?id=' + id,
            type: 'get',
            contentType: 'application/json;charset=utf-8',
            datatype: 'json',
            success: function (response) {
                console.log(response);
               
                if (response == null || response == undefined) {
                    alert('data null');

                }
                else if (response.length == 0) {
                    alert('data not available with the id' + id);

                }
                else {
                    $('EmployeeModel').modal('show');
                    $('#mypop').text('updated');
                    $('#save').css('display', 'none');
                    $('#Id').val(response.id);
                    $('#FirstName').val(response.FirstName);
                    $('#LastName').val(response.LastName);
                    $('#Email').val(response.Email);
                    $('#Mobile').val(response.Mobile);
                    $('#Role').val(response.Role);
                    $('#joining_date').val(response.joining_date);
                    $('#Salary').val(response.Salary);
                    $('#Project_id').val(response.Project_id);
                    $('#Address').val(response.Address);
                    alert("updated");

                }
                $("#test").append(response);
            *//*   alert($("#test").append(response));*//*
            },
            error: function () {
                alert('unable to read the data');
            }
        });


}*/


function openForm() {
    document.getElementById("myForm").style.display = "block";
}



/*ajax({
    var username = window.location.hash.split('*')[1] || $('a[asp-action="Profile"]').data('username') || $("#usernameInput").val();

    console.log("username before AJAX:", username);

    type: "GET",
    url: "/Controller/Profile?username=" + username,
    success: function (data) {
        console.log(data);
        $("#profileContainer").html(data);
    },
    error: function (xhr, status, error) {
        console.log(error);
    }
});
*/
/*function getUsername() {
   
    var username = $('a[asp-action="Profile"]').data('username') || $("#usernameInput").val();
    getProfile(username);
}*/
/*$(document).ready(function () {
    var profileLink = $('.nav-link[asp-action="Profile"]');
    console.log("username before AJAX:", profileLink);
    if (profileLink.length > 0) {
        var profileUrl = profileLink.attr('href');
        // Assuming the image element exists with ID "profileImage"
        $('#profileImage').attr('src', profileUrl);
    }
    
});


$(document).ready(function () {
    console.log("heloo");
    var username = $('#username').val();
    var t = $('#isAuthenticated').val() === 'true';
    var profileLink = $('.nav-link[asp-action="Profile"]');

    if (profileLink && t ) {
        window.location.href = "/login/profile?username=" + username; // Less secure approach
    }
});
*/
/*$(document).ready(function () {
    console.log("heloo");
    var username = $('#username').text();
    var t = $('#isAuthenticated').text();
    var profileLink = $('.nav-link[asp-action="Profile"]');

    if (profileLink && t) {
        window.location.href = "/login/profile?username=" + username; // Less secure approach
    }
});*/

/*$(document).ready(function () {
    console.log("heloo");
    var username = $('#username').text();
    var profileLink = $('.nav-link[asp-action="Profile"]');
    if (username != '') {
        ajax({
            url: "/login/profile?username=" + username, // Adjust URL based on your controller and action
            type: "GET",
            dataType: "html", // Specify HTML content expected
            success: function (data) {
                // Update a container element in the home page with the received data
                $("#content-container").html(data); // Replace with your container ID
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Handle AJAX request error
                console.error("Error:", textStatus, errorThrown);
            }
        });
    }
});*/


$(document).ready(function () {
    console.log("hello");

    var username = $('#username').text();
    var profileLink = $('a.nav-link[asp-action="Profile"]');
    if (username !== '') {
        $.ajax({
            url: "/login/profile?username=" + encodeURIComponent(username), // Adjust URL based on your controller and action
            type: "GET",
            dataType: "html", // Specify HTML content expected
            success: function (data){
                // Update a container element in the home page with the received data
                $("#content-container").append(data); // Replace with your container ID
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // Handle AJAX request error
                console.error("Error:", textStatus, errorThrown);
            }
        });
    }
});