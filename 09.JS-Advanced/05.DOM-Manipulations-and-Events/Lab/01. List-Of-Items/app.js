function addItem() {
    let input = document.getElementById('newItemText');;
    let ulRef = document.getElementById('items');

    let newLi = document.createElement('li');
    newLi.textContent = input.value;

    ulRef.appendChild(newLi);
    input.value = '';
}