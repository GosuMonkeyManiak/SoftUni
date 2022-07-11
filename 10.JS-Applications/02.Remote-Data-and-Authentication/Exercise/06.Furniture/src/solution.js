window.addEventListener('load', onLoad);
document.querySelector('#logoutBtn').addEventListener('click', logout);

function onLoad() {
    let userSession = sessionStorage.getItem('authToken');

    let userButtons = document.querySelector('header nav #user');
    let guestButtons = document.querySelector('header nav #guest');

    userButtons.style.display = 'inline-block';
    guestButtons.style.display = 'inline-block';

    if (userSession == null) {
        userButtons.style.display = 'none';
    } else {
        guestButtons.style.display = 'none';
    }

    loadProducts();
}

async function logout() {
    let userSession = sessionStorage.getItem('authToken');

    if (userSession == null) {
        return;
    }

    await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: { 'X-Authorization': userSession.accessToken }
    });

    sessionStorage.clear();

    onLoad();
}

async function loadProducts() {
    let response = await fetch('http://localhost:3030/data/furniture');
    let furnitures = await response.json();

    let listOfFurnitures = document.querySelector('table tbody');

    furnitures.forEach(furniture => {
        listOfFurnitures.appendChild(createFurnitureLayout(furniture));
    });
}

function createFurnitureLayout(furniture) {
    let furnitureRow = document.createElement('tr');

    let imgTd = document.createElement('td');

    let image = document.createElement('img');
    image.src = furniture.img;
    imgTd.appendChild(image);
    
    furnitureRow.appendChild(imgTd);

    let nameTd = document.createElement('td');

    let furnitureName = document.createElement('p');
    furnitureName.textContent = furniture.name;
    nameTd.appendChild(furnitureName);

    furnitureRow.appendChild(nameTd);

    let priceTd = document.createElement('td');

    let price = document.createElement('p');
    price.textContent = furniture.price;
    priceTd.appendChild(price);

    furnitureRow.appendChild(priceTd);

    let decorationTd = document.createElement('td');

    let decoration = document.createElement('p');
    decoration.textContent = furniture.decFactor;
    decorationTd.appendChild(decoration);

    furnitureRow.appendChild(decorationTd);

    let inputTd = document.createElement('td');

    let checkBox = document.createElement('input');
    checkBox.type = 'checkbox';
    inputTd.appendChild(checkBox);

    if (sessionStorage.getItem('authToken') == null) {
        checkBox.disabled = true;
    }

    furnitureRow.appendChild(inputTd);

    return furnitureRow;
}