function regExr(input) {

    let regexr = new RegExp('\\w+', 'g');
    let matches = [...input.matchAll(regexr)];

    let result = matches
        .map(arr => arr[0])
        .map(x => x.toUpperCase());

    console.log(result.join(', '));
}

regExr('Hi, how are you?')