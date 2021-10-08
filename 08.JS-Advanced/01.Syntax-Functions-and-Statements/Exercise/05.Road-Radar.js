function roadRadar(speed, area) {

    function resultString(inLimitOrNot, speed, speedLimit) {

        if (inLimitOrNot == 'in') {
    
            return `Driving ${speed} km/h in a ${speedLimit} zone`;
        } else if (inLimitOrNot == 'out') {
    
            let diff = speed - speedLimit;
            let status = '';
    
            if (diff <= 20) {
                
                status = 'speeding';
            } else if (diff <= 40) {
                
                status = 'excessive speeding';
            } else {
                status = 'reckless driving';
            }
    
            return `The speed is ${diff} km/h faster than the allowed speed of ${speedLimit} - ${status}`;
        }
    }

    let result = '';

    switch (area) {
        case 'motorway':
            if (speed > 130) {
                result = resultString('out', speed, 130);
            } else {
                result = resultString('in', speed, 130);
            }
            break;

        case 'interstate':
            if (speed > 90) {
                result = resultString('out', speed, 90);
            } else {
                result = resultString('in', speed, 90);
            }
            break;
        
        case 'city':
            if (speed > 50) {
                result = resultString('out', speed, 50);
            } else {
                result = resultString('in', speed, 50);
            }
            break;
        
        case 'residential':
            if (speed > 20) {
                result = resultString('out', speed, 20);
            } else {
                result = resultString('in', speed, 20);
            }
            break;
    }

    console.log(result);
}



roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, 'motorway');