function solve(elements) {

    elements
        .sort((a, b) => {

            if (a.toLowerCase().length != b.toLowerCase().length) {
                return a.length - b.length;
            }

            return a.localeCompare(b);
        })
        .forEach(x => console.log(x));
}



solve(['alpha', 'beta', 'gamma']);
solve(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);
solve(['test', 'Deny', 'omen', 'Default']);