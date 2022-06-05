function addItem() {
    let textRef = document.getElementById('newItemText');
    let valueRef = document.getElementById('newItemValue');

    let option = document.createElement('option');
    option.textContent = textRef.value;
    option.value = valueRef.value;

    let selectRef = document.getElementById('menu');
    selectRef.appendChild(option);

    textRef.value = '';
    valueRef.value = '';
}