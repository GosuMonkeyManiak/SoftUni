function toyShop(moneyForTrip, countPuzzles, countDoll, countBears, countMinions, countTruck) {

    moneyForTrip = Number(moneyForTrip);
    countPuzzles = parseInt(countPuzzles);
    countDoll = parseInt(countDoll);
    countBears = parseInt(countBears);
    countMinions = parseInt(countMinions);
    countTruck = parseInt(countTruck);

    let allToys = countPuzzles + countDoll + countBears + countMinions + countTruck;

    let income = countPuzzles * 2.60;
    income += countDoll * 3;
    income += countBears * 4.1;
    income += countMinions * 8.2;
    income += countTruck * 2;

    if (allToys >= 50) {
        
        let discount = income * 0.25;
        income -= discount;
    }

    let taxForRent = income * 0.1;
    income -= taxForRent;

    if (income >= moneyForTrip) {
        
        console.log(`Yes! ${(income - moneyForTrip).toFixed(2)} lv left.`);
    } else {
        
        console.log(`Not enough money! ${(moneyForTrip - income).toFixed(2)} lv needed.`);
    }
}

toyShop("320", "8", "2", "5", "5", "1");