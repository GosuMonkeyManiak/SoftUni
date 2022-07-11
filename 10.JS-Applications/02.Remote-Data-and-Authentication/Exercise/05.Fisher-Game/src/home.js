import { showView, clearAllInputs, disableInputs, disableButtons } from './utility.js';

const homeView = document.querySelector('#home-view');
homeView.remove();

function showHome() {
    homeSetting();
    showView(homeView);

    document.querySelector('main aside button').addEventListener('click', loadAllCatches);
    document.querySelector('#home-view #addForm').addEventListener('submit', addNewCatch);
}

function homeSetting() {
    homeView.querySelector('#main').style.display = 'none';

    if (sessionStorage.getItem('authToken') != null) {
        homeView.querySelector('aside > #addForm > fieldset > button').disabled = false;
    }
}

async function loadAllCatches() {
    let response = await fetch('http://localhost:3030/data/catches');
    let allCatches = await response.json();

    let listOfCatches = document.querySelector('#catches');
    listOfCatches.innerHTML = '';

    allCatches.forEach(currentCatch => {
        listOfCatches.appendChild(createCatchLayout(currentCatch));
    });

    document.querySelector('#home-view #main').style.display = 'inline-block';
}

function createCatchLayout(currentCatch) {
    let divCatch = document.createElement('div');
    divCatch.className = 'catch';

    let anglerLabel = document.createElement('label');
    anglerLabel.textContent = 'Angler';
    divCatch.appendChild(anglerLabel);

    let anglerInput = document.createElement('input');
    anglerInput.type = 'text';
    anglerInput.className = 'angler';
    anglerInput.value = currentCatch.angler;
    divCatch.appendChild(anglerInput);

    let weightLabel = document.createElement('label');
    weightLabel.textContent = 'Weight';
    divCatch.appendChild(weightLabel);

    let weightInput = document.createElement('input');
    weightInput.type = 'text';
    weightInput.className = 'weight';
    weightInput.value = currentCatch.weight;
    divCatch.appendChild(weightInput);

    let speciesLabel = document.createElement('label');
    speciesLabel.textContent = 'Species';
    divCatch.appendChild(speciesLabel);

    let speciesInput = document.createElement('input');
    speciesInput.type = 'text';
    speciesInput.className = 'species';
    speciesInput.value = currentCatch.species;
    divCatch.appendChild(speciesInput);

    let locationLabel = document.createElement('label');
    locationLabel.textContent = 'Location';
    divCatch.appendChild(locationLabel);

    let locationInput = document.createElement('input');
    locationInput.type = 'text';
    locationInput.className = 'location';
    locationInput.value = currentCatch.location;
    divCatch.appendChild(locationInput);

    let baitLabel = document.createElement('label');
    baitLabel.textContent = 'Bait';
    divCatch.appendChild(baitLabel);

    let baitInput = document.createElement('input');
    baitInput.type = 'text';
    baitInput.className = 'bait';
    baitInput.value = currentCatch.bait;
    divCatch.appendChild(baitInput);

    let captureTimeLabel = document.createElement('label');
    captureTimeLabel.textContent = 'Capture Time';
    divCatch.appendChild(captureTimeLabel);

    let captureTimeInput = document.createElement('input');
    captureTimeInput.type = 'number';
    captureTimeInput.className = 'captureTime';
    captureTimeInput.value = currentCatch.captureTime;
    divCatch.appendChild(captureTimeInput);

    let updateButton = document.createElement('button');
    updateButton.textContent = 'Update';
    updateButton.className = 'update';
    updateButton.dataset.id = currentCatch._id;
    updateButton.addEventListener('click', updateCatch)
    divCatch.appendChild(updateButton);

    let deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.className = 'delete';
    deleteButton.dataset.id = currentCatch._id;
    deleteButton.addEventListener('click', deleteCatch);
    divCatch.appendChild(deleteButton);

    let session = JSON.parse(sessionStorage.getItem('authToken'));

    if (session == null || session.id != currentCatch._ownerId) {
        disableInputs(divCatch);
        disableButtons(divCatch);
    }

    return divCatch;
}

async function addNewCatch(event) {
    event.preventDefault();

    let formData = new FormData(this);

    let angler = formData.get('angler');
    let weight = formData.get('weight');
    let species = formData.get('species');
    let location = formData.get('location');
    let bait = formData.get('bait');
    let captureTime = formData.get('captureTime');

    if (angler == '' || species == '' || 
        location == '' || bait == '') {
        alert('All field are required!');
        return;
    }

    if (Number(weight) == NaN || Number(captureTime) == NaN) {
        alert('Weight and Capture Time must be numbers!');
        return;
    }

    let newCatch = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    };

    let session = JSON.parse(sessionStorage.getItem('authToken'));

    let response = await fetch('http://localhost:3030/data/catches', {
        method: 'post',
        headers: { 
            'Content-Type': 'application/json',
            'X-Authorization': session == null ? '' : session.accessToken
        },
        body: JSON.stringify(newCatch)
    });

    if (!response.ok) {
        let error = await response.json();
        alert(error.message);
        return;
    }

    loadAllCatches();
    clearAllInputs();
}

async function deleteCatch() {
    let response = await fetch(`http://localhost:3030/data/catches/${this.dataset.id}`);

    if (!response.ok) {
        let error = await response.json();
        alert(error.message);
        loadAllCatches();
        return;
    }

    let catchDetails = await response.json();

    let session = JSON.parse(sessionStorage.getItem('authToken'));

    if (session == null) {
        loadAllCatches();
        return;
    }

    if (catchDetails._ownerId != session.id) {
        loadAllCatches();
        return;
    }

    await fetch(`http://localhost:3030/data/catches/${this.dataset.id}`, {
        method: 'delete',
        headers: { 'X-Authorization': session.accessToken }
    });

    loadAllCatches();
}

async function updateCatch() {
    let response = await fetch(`http://localhost:3030/data/catches/${this.dataset.id}`);

    if (!response.ok) {
        let error = await response.json();
        alert(error.message);
        loadAllCatches();
        return;
    }

    let catchDetails = await response.json();

    let session = JSON.parse(sessionStorage.getItem('authToken'));

    if (session == null) {
        loadAllCatches();
        return;
    }

    if (catchDetails._ownerId != session.id) {
        loadAllCatches();
        return;
    }

    let currentCatchDiv = this.parentElement;

    let angler = currentCatchDiv.querySelector('input.angler').value;
    let weight = currentCatchDiv.querySelector('input.weight').value;
    let species = currentCatchDiv.querySelector('input.species').value;
    let location = currentCatchDiv.querySelector('input.location').value;
    let bait = currentCatchDiv.querySelector('input.bait').value;
    let captureTime = currentCatchDiv.querySelector('input.captureTime').value;

    let updatedCatch = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime
    }

    await fetch(`http://localhost:3030/data/catches/${this.dataset.id}`, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': session.accessToken
        },
        body: JSON.stringify(updatedCatch)
    });

    loadAllCatches();
}

export {
    showHome
}