function max(matrix) {

    return Math.max.apply(null, matrix.reduce((a, b) => a.concat(b)));
}

console.log(max([
                    [3, 5, 7, 12],
                    [-1, 4, 33, 2],
                    [8, 3, 0, 4]
                ]));

console.log(max([[20, 50, 10],
    [8, 33, 145]]
   ));