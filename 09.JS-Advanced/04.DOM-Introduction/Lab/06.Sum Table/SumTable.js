function sumTable() {
    let tds = document.querySelectorAll('tr td:last-child');
    let tdSum;
    
    let sum = 0;

    for (const td of tds) {

        if (td.id == 'sum') {
            tdSum = td;
            continue;
        } else {
            sum += Number(td.textContent);
        }
    }

    tdSum.textContent = sum;
}