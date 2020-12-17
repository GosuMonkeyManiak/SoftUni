function solve(firstSeconds, secondSeconds, thirdSeconds) {

    firstSeconds = parseInt(firstSeconds);
    secondSeconds = parseInt(secondSeconds);
    thirdSeconds = parseInt(thirdSeconds);

    let allSeconds = firstSeconds + secondSeconds + thirdSeconds;

    let minutes = parseInt(allSeconds / 60);
    let seconds = allSeconds % 60;

    if (seconds < 10) {
        
        console.log(`${minutes}:0${seconds}`);

    } else {

        console.log(`${minutes}:${seconds}`);
    }

}

solve("22", "7", "34");