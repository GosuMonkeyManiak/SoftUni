function diagonalSums(matrix) {

    let mainDiagonal = 0;
    let secondDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {

        mainDiagonal += matrix[row][row];
    }

    for (let row = 0; row < matrix.length; row++) {
        
        let col = matrix[row].length - 1 - row;

        secondDiagonal += matrix[row][col];
    }

    console.log(mainDiagonal, secondDiagonal);
}

diagonalSums(
    [[20, 40],
    [10, 60]]
);

diagonalSums(
    [[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
)