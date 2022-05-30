function neighnorPairs(matrix) {

    function isIndexValid(currentRow, currentCol, rowLength, colLength) {
        return currentRow >= 0 && currentRow < rowLength && currentCol >= 0 && currentCol < colLength;
    }

    let pairs = 0;

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length; col++) {

            // if (isIndexValid(row - 1, col, matrix.length, matrix[row].length) && matrix[row][col] == matrix[row - 1][col]) { //up
            //     pairs++;
            // }

            if (isIndexValid(row + 1, col,  matrix.length, matrix[row].length) && matrix[row][col] == matrix[row + 1][col])  { //down
                pairs++;
            }

            if (isIndexValid(row, col + 1, matrix.length, matrix[row].length) && matrix[row][col] == matrix[row][col + 1]) { //right
                pairs++;
            }

            // if (isIndexValid(row , col - 1, matrix.length, matrix[row].length) && matrix[row][col] == matrix[row][col - 1]) { //left
            //     pairs++;
            // }
        }
    }

    return pairs;
}

console.log(equalNeighbors(
    [['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
));

console.log(equalNeighbors(
    [['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
));