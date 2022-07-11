function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', loadPhoneNumbers);
    document.getElementById('btnCreate').addEventListener('click', createNewPhoneNumber);
}

async function loadPhoneNumbers(event) {
    let response = await fetch('http://localhost:3030/jsonstore/phonebook');
    let phoneNumbers = Object.values(await response.json());

    let listOfAllPhoneNumbers = document.getElementById('phonebook');

    listOfAllPhoneNumbers.innerHTML = '';

    phoneNumbers.forEach(phoneNumber => {
        let phoneLi = document.createElement('li');
        phoneLi.textContent = `${phoneNumber.person}:${phoneNumber.phone}`;

        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.dataset.id = phoneNumber._id;
        deleteButton.addEventListener('click', deletePhoneNumber)
        phoneLi.appendChild(deleteButton);

        listOfAllPhoneNumbers.appendChild(phoneLi);
    });
}

async function deletePhoneNumber(event) {
    let phoneNumberId = this.dataset.id;
    
    await fetch(`http://localhost:3030/jsonstore/phonebook/${phoneNumberId}`, {
        method: 'delete'
    });

    this.parentElement.remove();
}

async function createNewPhoneNumber(event) {
    let personNameInput = document.getElementById('person');
    let phoneNumberInput = document.getElementById('phone');

    if (personNameInput.value == '' || phoneNumberInput.value == '') {
        alert('Person and Phone are required!');
        return;
    }

    let newPhoneNumber = {
        person: personNameInput.value,
        phone: phoneNumberInput.value
    };

    await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newPhoneNumber)
    });

    await loadPhoneNumbers();

    personNameInput.value = '';
    phoneNumberInput.value = '';
}

attachEvents();