function addAndRemoveElements(commands) {

    let result = [];
    let number = 1;

    for (let i = 0; i < commands.length; i++) {
        
        if (commands[i] == 'add') {
            
            result.push(number);
        } else if (commands[i] == 'remove' && result.length != 0) {

            result.pop();
        }

        number++;
    }

    if (result.length == 0) {
        console.log('Empty')
    } else {
        console.log(result.join('\n'));
    }
}

addAndRemoveElements(['add', 'add', 'add', 'add',]);
addAndRemoveElements(['add', 'add', 'remove', 'add', 'add']);
addAndRemoveElements(['remove', 'remove', 'remove']);