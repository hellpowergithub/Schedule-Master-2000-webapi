


function reqListener() {
    console.log('Kesobb');
    console.log(this.responseText);
}

var request = new XMLHttpRequest();
request.addEventListener("load", reqListener) //nem hivom meg a fuggvenyt, REFERALOK a fuggvenyre (ha vege van a 'load'-nak)
request.open('GET', '/WeatherForecast')
request.send();
console.log('rogton');





