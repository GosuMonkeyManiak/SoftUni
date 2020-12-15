function fishTank(length, width, height, percentage){

    let cubicMeters = parseInt(length) * parseInt(width) * parseInt(height);
    cubicMeters *= 0.001;

    let takenPercantage = cubicMeters * (Number(percentage) / 100);
    cubicMeters -= takenPercantage;

    console.log(cubicMeters);
}

fishTank("85","75","47","17");