function juiceFlavors(arrayOfFlavors) {

    let allFlavors = new Map();

    for (const flavour of arrayOfFlavors) {

        let flavourParts = flavour.split(' => ');
        let key = flavourParts[0];
        let value = Number(flavourParts[1]);

        if (allFlavors.has(key)) {
            let currentValue = allFlavors.get(key) + value;
            allFlavors.delete(key);

            allFlavors.set(key, currentValue);
        } else {
            allFlavors.set(key, value);
        }
    }

    let allbottles = new Map();

    for (const [key, value] of allFlavors) {
        
        if (value >= 1000) {
            
            let bottlesOfFlavors = Math.trunc(value / 1000);
            allbottles.set(key, bottlesOfFlavors);
        }
    }

    console.log(Array.from(allbottles.entries()).map(x => x.join(' => ')).join('\n'));
}

juiceFlavors(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']);