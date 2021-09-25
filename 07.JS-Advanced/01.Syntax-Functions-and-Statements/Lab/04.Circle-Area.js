function circleArea(inPut) {

    if (typeof(inPut) != 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeof(inPut)}.`);
        return;
    }

    let area = Math.PI * Math.pow(inPut, 2)

    console.log(area.toFixed(2));
}

circleArea(5);
circleArea('name');
