function solve(numberOfSteps, stepLengthInMeters, speedKM) {
    
    let speedInSeconds = ((speedKM * 1000) / 3600);

    let timeToUniversityInSeconds = 0;

    let metersToUniversity = numberOfSteps * stepLengthInMeters;
    timeToUniversityInSeconds += Math.floor(metersToUniversity / 500) * 60; // every 500 meters rest for 1 minute

    timeToUniversityInSeconds += metersToUniversity / speedInSeconds;

    let hours = String(Math.floor(timeToUniversityInSeconds / 3600));
    let minute = String(Math.floor((timeToUniversityInSeconds % 3600) / 60));
    let seconds = String(Math.ceil((timeToUniversityInSeconds % 3600) % 60));

    console.log(`${hours.padStart(2, '0')}:${minute.padStart(2, '0')}:${seconds.padStart(2, '0')}`);
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);