let renderHeight = document.documentElement.clientHeight;
let renderWidth = document.documentElement.clientWidth;
console.log(renderWidth, renderHeight);
const body = document.querySelector('body');
//body.style.height = renderHeight + 'px';
body.style.width = renderWidth + 'px';
const day1 = document.querySelector('.day1');
const hourDivEl = document.querySelector('.hour');
const schedLinkEl = document.querySelector('#link-schedules');
const tasksLinkEl = document.querySelector('#link-tasks');
const loginLinkEl = document.querySelector('#link-login');
const userNameEl = document.querySelector('#user-name');
const middlePanelEl = document.querySelector('.middle-panel');
const loginPanelEl = document.querySelector('.login');
const schedulesPanelEl = document.querySelector('.schedules');
const tasksPanelEl = document.querySelector('.tasks');
const slotsPanelEl = document.querySelector('.slots');
const closerButtonsEl = document.querySelectorAll('.closer-button');

// creating 1 title + 24 slot in a day
// creating a title for the day
function createHourElement() {
    const hourEl = document.createElement("div");
    hourEl.className = 'hourSlot';

    const hourText = document.createElement("p");
    hourText.innerText = 'Time';

    hourEl.appendChild(hourText);
    hourDivEl.appendChild(hourEl);
    for (i = 0; i < 24; i++) {
        //creating a slot
        const slotEl = document.createElement("div");
        slotEl.className = 'hourSlot';
        slotEl.id = i;
        const slotText = document.createElement("p");
        slotText.innerText = i + ':00';
        slotEl.appendChild(slotText);

        hourDivEl.appendChild(slotEl);
    }
}

function openSchedPanel() {
    tasksPanelEl.style.display = 'none';
    loginPanelEl.style.display = 'none';
    slotsPanelEl.style.display = 'none';
    schedulesPanelEl.style.display = 'grid';
    middlePanelEl.style.height = 'auto';
}

function openTasksPanel() {
    schedulesPanelEl.style.display = 'none';
    loginPanelEl.style.display = 'none';
    slotsPanelEl.style.display = 'none';
    tasksPanelEl.style.display = 'grid';
    middlePanelEl.style.height = 'auto';
}

function openLoginPanel() {
    schedulesPanelEl.style.display = 'none';
    tasksPanelEl.style.display = 'none';
    slotsPanelEl.style.display = 'none';
    loginPanelEl.style.display = 'grid';
    middlePanelEl.style.height = 'auto';
}

function openSlotsPanel() {
    schedulesPanelEl.style.display = 'none';
    tasksPanelEl.style.display = 'none';
    loginPanelEl.style.display = 'none';
    slotsPanelEl.style.display = 'grid';
    middlePanelEl.style.height = 'auto';
}

function hideMiddlePanel() {
    schedulesPanelEl.style.display = 'none';
    tasksPanelEl.style.display = 'none';
    loginPanelEl.style.display = 'none';
    slotsPanelEl.style.display = 'none';

}

function navBarLinks() {
    schedLinkEl.addEventListener('mouseover', openSchedPanel);
    tasksLinkEl.addEventListener('mouseover', openTasksPanel);
    loginLinkEl.addEventListener('mouseover', openLoginPanel);
    for (i = 0; i < closerButtonsEl.length; i++) {
        closerButtonsEl[i].addEventListener('click', hideMiddlePanel);
    }
}


createHourElement();
navBarLinks();
