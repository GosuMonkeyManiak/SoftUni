function solve(month, year) {
    let dates = new Date(year, month, 0).getDate();

    return dates;
}

console.log(solve(1, 2012));
console.log(solve(2, 2021));
