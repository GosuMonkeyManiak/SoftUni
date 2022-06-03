function solve() {
    let number = Number(document.getElementById('input').value);

    let selectRef = document.getElementById('selectMenuTo');
    let destination = selectRef.value;

    let resultRef = document.getElementById('result');

    if (destination == 'binary') {
        resultRef.value = number.toString(2);
    } else if (destination == 'hexadecimal') {
        resultRef.value = number.toString(16).toUpperCase();
    }
}