function rotate(elements, rotationTimes) {

    for (let i = 1; i <= rotationTimes; i++) {
        elements.unshift(elements.pop());    
    }

    console.log(elements.join(' '));
}

rotate(['1', '2', '3', '4'], 2);
rotate(['Banana', 'Orange', 'Coconut', 'Apple'], 15)