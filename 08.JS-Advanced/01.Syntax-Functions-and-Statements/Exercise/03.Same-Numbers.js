function sameNumbers(number) {

    let numberAsString = String(number);

    let flag = true;
    let sum = 0;

    for (let index = 0; index < numberAsString.length - 1; index++) {

        if (numberAsString[index] != numberAsString[index + 1]) {
            
            flag = false;
            break;
        }
    }

    for (let index = 0; index < numberAsString.length; index++) {

        sum += parseInt(numberAsString[index]);
    }

    console.log(flag);
    console.log(sum);
}

sameNumbers(2222222);