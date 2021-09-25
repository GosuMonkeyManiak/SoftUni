function timeToWalk(stepsToUni, footPrint, walkingSpeed) {

    let time = 0;

    let metersWalkForSecond = walkingSpeed / 3.6;
    let metersToUni = stepsToUni * footPrint;

    //rest
    time += Math.trunc(metersToUni / 500) * 60;

    //time to Uni
    time += metersToUni / metersWalkForSecond;

    let hours = Math.trunc(time / 3600);
    let minutes = Math.trunc(time / 60);
    let seconds = Math.round(time % 60);

    console.log(`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`);
}

timeToWalk(4000, 0.60, 5);