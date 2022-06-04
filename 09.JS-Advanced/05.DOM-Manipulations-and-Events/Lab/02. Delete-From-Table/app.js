function deleteByEmail() {
    let inputRef = document.querySelector('input[name="email"]');

    let matchTd = Array.from(document.querySelectorAll('td'))
        .find(x => x.textContent == inputRef.value);

    let resultRef = document.getElementById('result');

    if (matchTd == undefined) {
        resultRef.textContent = 'Not found.';
    } else {
        matchTd.parentElement.remove();
        resultRef.textContent = 'Deleted.'
    }
}