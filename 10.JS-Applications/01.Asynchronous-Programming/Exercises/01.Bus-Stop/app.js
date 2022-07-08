async function getInfo() {
    let stopNameElement = document.getElementById('stopName');
    let listOfBuses = document.getElementById('buses');

    let stopId = document.getElementById('stopId').value;
    let url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`

    let respnse = await fetch(url);

    if (respnse.status != 200) {
        stopNameElement.textContent = 'Error';
        listOfBuses.innerHTML = '';
        return;
    }

    let data = await respnse.json();

    stopNameElement.textContent = data.name;

    for (const busKey of Object.keys(data.buses)) {
        
        let currentBusLi = document.createElement('li');
        currentBusLi.textContent = `Bus ${busKey} arrives in ${data.buses[busKey]} minutes`;
        listOfBuses.appendChild(currentBusLi);
    }
}