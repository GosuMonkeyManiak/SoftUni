function addAndRemove(arrayOfOperations) {

    let result = [];
    let initial = 1;

    for (let index = 0; index < arrayOfOperations.length; index++) {

        switch (arrayOfOperations[index]) {
            
            case 'add':
                result.push(initial);
                initial++;
                break;
        
            case 'remove':
                if (result.length > 0) {
                    result.pop();
                }
                initial++;
                break;
        }
    }

    if (result.length > 0) {
        result.forEach(x => console.log(x));
    } else {
        console.log('Empty');
    }
}

//addAndRemove(['add', 'add', 'add', 'add']);
addAndRemove(['add', 'add', 'remove', 'add', 'add']);
//addAndRemove(['remove', 'remove', 'remove']);