function colorize() {
    let evenRows = document.querySelectorAll('table tr:nth-child(even)');

    for (const trElement of evenRows) {
        trElement.style.backgroundColor = 'Teal';
    }
}