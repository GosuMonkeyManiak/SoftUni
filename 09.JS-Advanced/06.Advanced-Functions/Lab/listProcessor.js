function listProcessor(commands) {

    commands = commands.map(wholeCommand => {
        let commandParts = wholeCommand.split(' ');
        let command = commandParts[0];
        let parameter = commandParts[1];

        return {
            command,
            parameter
        }
    });

    let allStrings = [];

    function processor() {

        commands.forEach(wholeCommand => {

            if (wholeCommand.command == 'add') {
                allStrings.push(wholeCommand.parameter);
            } else if (wholeCommand.command == 'remove') {
                
                let index = allStrings.indexOf(wholeCommand.parameter);

                while (index != -1) {
                   allStrings.splice(index, 1);

                   index = allStrings.indexOf(wholeCommand.parameter);
                }

            } else if (wholeCommand.command == 'print') {
                console.log(allStrings.join(','));
            }
        });
    }

    processor();
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);
listProcessor(['add pesho', 'add george', 'add peter', 'remove peter','print']);