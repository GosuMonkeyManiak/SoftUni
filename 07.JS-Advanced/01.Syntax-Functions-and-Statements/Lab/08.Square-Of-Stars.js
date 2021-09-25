function squareOfStarts(size = 5) {

    if (size == 1) {
        console.log('*');
        return;
    }

    let result = '';

    for (let row = 0; row < size; row++) {

        for (let row = 0; row < size; row++) {
            
            result += '* '
        }
        result += '\n';
    }

    console.log(result.trim());
}

squareOfStarts(2);