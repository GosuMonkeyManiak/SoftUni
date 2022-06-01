function calorieObject(elements) {

    let result = {};
    
    for (let i = 0; i < elements.length - 1; i += 2) {
        
        result[elements[i]] = Number(elements[i + 1]);
    }

    console.log(result);
}

calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);