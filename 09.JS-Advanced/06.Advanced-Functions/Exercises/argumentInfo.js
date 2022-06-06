function argumentsInfo(...parameters) {

    let types = [];

    for (let i = 0; i < parameters.length; i++) {

        let type = typeof parameters[i];
        let value = parameters[i];

        if (types.some(x => x.type == type)) {
            types.find(x => x.type == type).count += 1;
        } else {
            types.push({
                type,
                count: 1
            });
        }

        console.log(`${type}: ${value}`);
    }

    types.sort((a, b) => b.count - a.count);

    types.forEach(t => {
        console.log(`${t.type} = ${t.count}`);
    });
}

argumentsInfo('cat', 42, function () { console.log('Hello world!'); });