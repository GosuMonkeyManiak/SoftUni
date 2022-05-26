function solve(message) {

    message = String(message);

    let regex = /\w+/g;

    let elements = [...message.matchAll(regex)];

    let result = [];

    for (let i = 0; i < elements.length; i++) {

        for (let j = 0; j < elements[i].length; j++) {
            result.push(String(elements[i][j]).toUpperCase());
        }
    }

    console.log(result.join(', '));
}

solve('Hi, how are you?');
solve('hello');