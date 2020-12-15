function radiansToDegrees(inPut){

    let radians = Number(inPut);
    let degrees = Math.round(radians * 180 / Math.PI);

    console.log(degrees.toFixed(0))
}

radiansToDegrees("6.2832");