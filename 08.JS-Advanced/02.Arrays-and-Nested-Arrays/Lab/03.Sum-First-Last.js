function sumFirstAndLast(array) {

    array = array.map(x => Number(x));

    return array[0] + array[array.length - 1]; 
}

console.log(sumFirstAndLast(['20', '30', '40']));