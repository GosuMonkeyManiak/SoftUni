function solve(size = 5) {
    if (size == 1) {
        console.log('*');
        return;
    }

    let result = '';

    for (let row = 0; row < size; row++) {
        for (let row = 0; row < size; row++) {
            result += '* ';
        }
        result += '\n';
    }

    console.log(result.trim());
}

solve(1);
console.log('--');

solve(2);
console.log('--');

solve(5);
console.log('--');

solve(7);
console.log('--');
