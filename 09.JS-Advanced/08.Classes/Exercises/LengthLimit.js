class Stringer {
 
    constructor(string, length) {
        this.innerString = string;
        this.innerLength = Number(length);
    }

    increase(length) {
        this.innerLength += Number(length);
    }

    decrease(length) {
        this.innerLength -= Number(length);

        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        if (this.innerLength == 0) {
            return '...';
        }

        if (this.innerLength >= this.innerString.length - 1) {
            return this.innerString;
        }

        let stringCopy = Array.from(this.innerString.slice(0));
        let stringCopyLength = stringCopy.length - 1;

        for (let i = stringCopyLength; i > this.innerLength - 1; i--) {
            stringCopy[i] = '.';
        }

        return stringCopy.join('');
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4);
console.log(test.toString()); // Test
