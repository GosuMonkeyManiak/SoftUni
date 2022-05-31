function sortByTwoCriterias(array) {

    function sortFunction(a, b) {

    if (a.length != b.length) {
        return a.length - b.length;
    } else {
        return a.localeCompare(b);
    }
}

    array.sort(sortFunction);

    array.forEach(x => console.log(x));
}

sortByTwoCriterias(['alpha', 'beta', 'gamma']);
sortByTwoCriterias(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);