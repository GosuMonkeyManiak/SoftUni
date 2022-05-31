function rotateArray(array, numberOfRotaions) {

    for (let i = 0; i < numberOfRotaions; i++) {
        
        array.unshift(array.pop());
    }

    console.log(array.join(' '));
}

rotateArray(['1', '2', '3', '4'], 2);
rotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 15);