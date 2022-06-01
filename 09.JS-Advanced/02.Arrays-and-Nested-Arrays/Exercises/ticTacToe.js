function ticTacToe(turns) {

    let dashboard = 
    [
        ['', '', ''],
        ['', '', ''],
        ['', '', '']
    ];

    let playerFlag = true;

    for (let i = 0; i < turns.length; i++) {
        
        let cordinates = turns[i].split(' ').map(Number);
        let characterToPlace = '';

        if (playerFlag) {
            characterToPlace = 'X';
        } else {
            characterToPlace = 'O';
        }

        if (!checkIsPositionIsFree(dashboard, cordinates[0], cordinates[1])) {
            console.log('This place is already taken. Please choose another!');
            continue;
        } else {
            dashboard[cordinates[0]][cordinates[1]] = characterToPlace;

            if (checkIsSomeOneWins(dashboard)) {

                console.log(`Player ${playerFlag ? 'X' : 'O'} wins!`);
                printDashboard(dashboard)
                return;
            }
        }

        playerFlag = !playerFlag;
    }

    console.log('The game ended! Nobody wins :(')
    printDashboard(dashboard);
}

function checkIsPositionIsFree(dashboard, row, col) {
    return dashboard[row][col] == '';
}

function checkIsSomeOneWins(dashboard) {

    let valuesOfCheck = [];

    //check rows
    for (let row = 0; row < dashboard.length; row++) {
        
        let isHaveRow = true;

        for (let col = 0; col < dashboard[row].length - 1; col++) {
            
            if (dashboard[row][col] != '' && dashboard[row][col + 1] != '') {

                if (dashboard[row][col]) {
                    
                }

                isHaveRow = false;
            }
        }

    }
}
    

function printDashboard(dashboard) {

    for (let row = 0; row < dashboard.length; row++) {
        
        for (let col = 0; col < dashboard.length; col++) {

            if (dashboard[row][col] == '') {

                dashboard[row][col] = false;
            }
        }
    }

    dashboard.forEach(element => {
        console.log(element.join(' '));
    });
}

// ticTacToe(
//     ["0 1",
//     "0 0",
//     "0 2", 
//     "2 0",
//     "1 0",
//     "1 1",
//     "1 2",
//     "2 2",
//     "2 1",
//     "0 0"]);

ticTacToe(
    ["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]);