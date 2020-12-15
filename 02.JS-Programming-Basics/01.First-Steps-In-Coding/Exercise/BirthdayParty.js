function birthDayParty(rent){

    let moneyForCake = parseInt(rent) * 0.2;
    let moneyForDrinks = moneyForCake - (moneyForCake * 0.45);
    let animator = parseInt(rent) / 3;

    let buget = moneyForCake + moneyForDrinks + animator + parseInt(rent);
    console.log(buget)
}

birthDayParty("2250");