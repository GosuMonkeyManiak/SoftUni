function dayOfWeek(weekDay) {

    let result;
    
    switch (weekDay.toLowerCase()) {
        
        case 'monday': result = 1; 
            break;
    
        case 'tuesday': result = 2; 
            break;

        case 'wednesday': result = 3;
            break;

        case 'thursday': result = 4;
            break;

        case 'friday': result = 5;
            break;

        case 'saturday': result = 6;
            break;

        case 'sunday': result = 7;
            break;

        default: return 'error';
    }

    return result;
}

console.log(dayOfWeek('Monday'));