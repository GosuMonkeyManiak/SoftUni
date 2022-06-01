function townsToJSON(input) {

    let keys = input[0]
        .substr(input[0].indexOf(' ') + 1, input[0].lastIndexOf(' ') - 1)
        .split(' | ')
        .map(x => x.trim());

    let first = keys[0];
    let second = keys[1];
    let third = keys[2];

    let reuslt = [];

    for (let i = 1; i < input.length; i++) {
        
        let values = input[i]
        .substr(input[i].indexOf(' ') + 1, input[i].lastIndexOf(' ') - 1)
        .split(' | ')
        .map(x => x.trim());

        let currentTown = {
            [first]: values[0],
            [second]: Number(Number(values[1]).toFixed(2)),
            [third]: Number(Number(values[2]).toFixed(2))
        };

        reuslt.push(currentTown);
    }

    console.log(JSON.stringify(reuslt));
}

townsToJSON([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);