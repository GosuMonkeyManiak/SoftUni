function solve() {

    let firstInput = document.getElementById('text');
    let secondInput = document.getElementById('naming-convention');
    let result = document.getElementById('result');

    let word = firstInput.value;
    let words = word
        .split(' ')
        .map(x => x.toLowerCase())
        .map(x => x[0].toUpperCase() + x.substr(1));

    if (secondInput.value == 'Camel Case') {
        words[0] = words[0][0].toLowerCase() + words[0].substr(1);

        result.textContent = words.join('');

    } else if (secondInput.value == 'Pascal Case') {

        result.textContent = words.join('');

    } else {
        result.textContent = 'Error!';
    }
}