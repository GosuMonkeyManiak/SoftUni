function addItem() {
    let input = document.getElementById('newItemText');;
    let ulRef = document.getElementById('items');

    let newAnchor = document.createElement('a');
    newAnchor.href = '#';
    newAnchor.textContent = '[Delete]';

    let newLi = document.createElement('li');
    newLi.textContent = input.value;
    newLi.appendChild(newAnchor);

    ulRef.appendChild(newLi);
    input.value = '';

    ulRef.addEventListener('click', (e) => {

        if (e.target.tagName == 'A') {
            e.target.parentElement.remove();
        }
    });
}