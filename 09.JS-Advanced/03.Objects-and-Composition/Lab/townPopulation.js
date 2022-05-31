function townPopulation(input) {

    let towns = input.map(e => e.split(' <-> '));

    let reuslt = {};

    for (let row = 0; row < towns.length; row++) {

        let key = towns[row][0];
        let value = Number(towns[row][1]);

        if (reuslt.hasOwnProperty(key)) {
            reuslt[key] += value;
        } else {
            reuslt[key] = value;
        }
    }

    for (const key in reuslt) {
        console.log(`${key} : ${reuslt[key]}`);
    }
}

townPopulation(['Sofia <-> 1200000','Montana <-> 20000','New York <-> 10000000','Washington <-> 2345000','Las Vegas <-> 1000000']);
townPopulation(['Istanbul <-> 100000','Honk Kong <-> 2100004','Jerusalem <-> 2352344','Mexico City <-> 23401925','Istanbul <-> 1000']);