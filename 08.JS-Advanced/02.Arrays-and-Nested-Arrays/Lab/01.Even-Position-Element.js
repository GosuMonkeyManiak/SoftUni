function evenNumbers(numbers) {

    let evenNumbers = [];
    
    for (let i = 0; i < numbers.length; i += 2) {

        evenNumbers.push(numbers[i]);
    }

    console.log(evenNumbers.join(' '));
}

evenNumbers(['20', '30', '40', '50', '60']);