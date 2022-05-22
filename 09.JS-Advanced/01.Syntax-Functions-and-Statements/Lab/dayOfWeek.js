function solve(dayOfWeek) {
    let dayAsString = String(dayOfWeek);

    switch (dayAsString.toLowerCase()) {
        case 'monday':
            return 1;

        case 'tuesday':
            return 2;

        case 'wednesday':
            return 3;

        case 'thursday':
            return 4;

        case 'friday':
            return 5;

        case 'saturday':
            return 6;

        case 'sunday':
            return 7;

        default:
            return 'error';
    }
}

console.log(solve('Monday'));
console.log(solve('Friday'));
console.log(solve('Invalid'));
