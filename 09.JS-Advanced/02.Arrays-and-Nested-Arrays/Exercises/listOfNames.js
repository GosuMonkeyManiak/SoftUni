function listOfNames(names) {

    names = names.sort((a, b) => a.localeCompare(b));

    let number = 1;

    for (const name of names) {
        console.log(`${number}.${name}`);
        number++;
    }
}

listOfNames(["John", "Bob", "Christina", "Ema"]);