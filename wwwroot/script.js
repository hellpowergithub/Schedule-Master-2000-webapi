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
const schedule_div = document.querySelector(".schedule");
const login_div = document.querySelector(".login")

function doLogin() {
    var data = new FormData();
    data.append("email", email_input.value);
    data.append("password", password_input.value);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", URL);
    xhr.onload = function () {

        if (this.status === 200) {
            console.log("OK");
            schedule_div.classList.remove("hidden");
            login_div.classList.add("hidden");

        } else {
            console.log("Error");
        }
    };
    xhr.send(data);
}








