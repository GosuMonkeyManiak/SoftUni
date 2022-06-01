function carFactory(requirements) {

    const smallEngine = { power: 90, volume: 1800 };
    const normalEngine = { power:120, volume: 2400 };
    const monsterEngine = { power: 200, volume: 3500 };

    const hatchBack = { type: 'hatchback' };
    const coupe = { type: 'coupe' };

    let model = requirements.model;
    let newCar = { model: model };
    
    if (requirements.power <= 90) {
        newCar.engine = smallEngine;
    } else if (requirements.power <= 120) {
        newCar.engine = normalEngine;
    } else {
        newCar.engine = monsterEngine;
    }

    if (requirements.carriage == 'hatchback') {
        hatchBack.color = requirements.color;
        newCar.carriage = hatchBack;
    } else {
        coupe.color = requirements.color;
        newCar.carriage = coupe;
    }

    let wheelSize = requirements.wheelsize;

    if (wheelSize % 2 == 0) {
        wheelSize--;
    }

    newCar.wheels = Array(4).fill(wheelSize);

    return newCar;
}

console.log(carFactory({ 
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 }));