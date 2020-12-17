function solve(startScore) {

    startScore = Number(startScore);

    let bonus = 0;

    if (startScore <= 100) {
        bonus += 5;
    } else if (startScore <= 1000) {
        let currentBonus = startScore * 0.2;
        bonus += currentBonus;
    } else {
        let currentBonus = startScore * 0.1;
        bonus += currentBonus;
    }

    if (startScore % 2 == 0) {
        bonus += 1
    }

    if (startScore % 10 == 5) {
        bonus += 2;
    }

    startScore += bonus;

    console.log(bonus);
    console.log(startScore);
}

solve("15875");