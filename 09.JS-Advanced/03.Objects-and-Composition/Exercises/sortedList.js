function createSortedList() {

    let storage = [];

    let sortFunction = (a, b) => a - b;

    let list = {
        size: storage.length,
        add(element) {
            storage.push(element);
            storage.sort(sortFunction);
            this.size = storage.length;
        },
        remove(index) {
            if (index >= 0 && index <= storage.length - 1) {
                storage.splice(index, 1);
                storage.sort(sortFunction);
                this.size = storage.length;
            }
        },
        get(index) {
            if (index >= 0 && index <= storage.length - 1) {
                return storage[index];
            }
        }
    }

    return list;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
console.log(list.size)