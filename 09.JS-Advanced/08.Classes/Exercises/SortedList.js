class List {
    _numbers

    constructor() {
        this._numbers = [];
        this.size = this._numbers.length;
    }

    _sort() {
        this._numbers.sort((a, b) => a - b);
    }

    _isValidIndex(index) {
        return index >= 0 && index <= this._numbers.length - 1;
    }

    add(element) {
        this._numbers.push(element);
        this._sort();
        this.size = this._numbers.length;
    }

    remove(index) {

        if (this._isValidIndex(index)) {
            this._numbers.splice(index, 1);
            this._sort();
            this.size = this._numbers.length;
        }
    }

    get(index) {

        if (this._isValidIndex(index)) {
            return this._numbers[index];
        }
    }
}

let list = new List();

list.add(5);
list.add(3);
list.remove(0);

console.log(list._numbers);
console.log(list.get(0));
