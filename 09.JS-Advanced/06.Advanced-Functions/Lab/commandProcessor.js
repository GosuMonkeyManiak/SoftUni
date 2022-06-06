function solution() {

    let stringToBeManipulated = '';

    return {
        append(stringToAppend) {
            stringToBeManipulated = stringToBeManipulated.concat(stringToAppend);
        },
        removeStart(numberOfCharacterToRemove) {
            stringToBeManipulated = stringToBeManipulated.slice(numberOfCharacterToRemove);
        },
        removeEnd(numberOfCharacterToRemove) {
            stringToBeManipulated = stringToBeManipulated.slice(0, stringToBeManipulated.length - numberOfCharacterToRemove);
        },
        print() {
            console.log(stringToBeManipulated);
        }
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
