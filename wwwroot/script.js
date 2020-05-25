//fetch(URL, {
//    method: "POST",
//    body: document.getElementById("login_input")
//}).then(
//    response => response.text()
//).then(
//    html => console.log(html)
//).catch((error) => {
//    console.log(error.text())
//});


// do

//POST login   
const URL = "/Account/Login";
const email_input = document.getElementById("email");
const password_input = document.getElementById("password");


//



function doLogin() {
    var data = new FormData();
    data.append("email", email_input.value);
    data.append("password", password_input.value);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", URL);
    xhr.onload = function () {
        // this = xhr object

       

        // Code continues HERE
        // xhr -> /Schedule (do what we did today)

        if (this.status === 200) {
            console.log("OK");
        } else {
            console.log("Error");
        }



    };
    xhr.send(data);
}








