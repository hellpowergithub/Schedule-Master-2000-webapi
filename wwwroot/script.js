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
const create_schedule_div = document.querySelector(".create_schedule");

function doLogin() {
    var data = new FormData();
    data.append("email", email_input.value);
    data.append("password", password_input.value);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", URL);
    xhr.onload = function () {

        if (this.status === 200) {
            console.log("OK");
            console.log(this.responseText);
            schedule_div.classList.remove("hidden");
            login_div.classList.add("hidden");
            create_schedule_div.classList.remove("hidden");
            scheduleXHR();

        } else {
            console.log("Error");
            // alert Error
        }
    };
    xhr.send(data);
}

function createSchedule() {
    const title_input = document.getElementById("title");
    var data = new FormData();
    data.append("name", title_input.value);


    var xhr = new XMLHttpRequest();
    // send POST to URL, which will add new Schedule
    // to DataBase
    xhr.open("POST", "/Schedule/CreateSchedule");
    xhr.send(data);
}



function scheduleXHR() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/Schedule/UserSchedules");
    xhr.onload = function () {
        // parse it to JSON
        var schedules = JSON.parse(this.responseText);

        ScheduleToList(schedules);
    }
    xhr.send();
}


function ScheduleToList(schedules) {

    const schedule_ul = document.getElementById("schedule_list");



    for (var i = 0; i < schedules.length; i++) {
        var schedule = schedules[i];
        console.log(schedule.id);
        console.log(schedule.name);
        console.log(schedule.userEmail);

        const li = document.createElement('li');

        const p = document.createElement('p');


        var id = schedule.id;
        var name = schedule.name;
        var userEmail = schedule.userEmail;


        p.appendChild(document.createTextNode(`Id: ${id}, Name: ${name}, Email: ${userEmail} \n`));
        li.appendChild(p);
        schedule_ul.appendChild(li);

    }
    return schedule_ul;

}




