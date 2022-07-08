function solve() {
    let infoRef = document.querySelector('#info span');
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');

    let nextStopId = 'depot';
    let stopName = '';

    async function depart() {
        let url = `http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`;

        let response = await fetch(url);
        let data = await response.json();

        stopName = data.name;
        infoRef.textContent = `Next stop ${stopName}`;

        departButton.disabled = true;
        arriveButton.disabled = false;

        nextStopId = data.next;
    }

    function arrive() {
        infoRef.textContent = `Arriving at ${stopName}`;

        arriveButton.disabled = true;
        departButton.disabled = false;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();