function diagonalSum(matrix) {

    let primaryDiagonal = 0;
    let secondaryDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {

        primaryDiagonal += matrix[row][row];
    }

    for (let row = 0; row < matrix.length; row++) {

        secondaryDiagonal += matrix[row][matrix[row].length - row - 1]
    }

    console.log(`${primaryDiagonal} ${secondaryDiagonal}`);
}

diagonalSum([[20, 40],
    [10, 60]]
   )
