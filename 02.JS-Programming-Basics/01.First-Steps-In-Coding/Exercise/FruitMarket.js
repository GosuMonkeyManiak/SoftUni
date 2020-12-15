function fruitMarket(strawberryPrice, kiloBananas, kiloOranges, kiloRaspBerry, kiloStrawBerry){

    let moneyForStrawBerries = Number(strawberryPrice) * Number(kiloStrawBerry);

    let raspBerriesPrice = Number(strawberryPrice) / 2;
    let moneyForRaspBerries = raspBerriesPrice * Number(kiloRaspBerry);
    
    let moneyForOranges = (raspBerriesPrice - (raspBerriesPrice * 0.4)) * kiloOranges;
    let moneyForBananas = (raspBerriesPrice - (raspBerriesPrice * 0.8)) * kiloBananas;

    let total = moneyForStrawBerries + moneyForRaspBerries + moneyForOranges + moneyForBananas;

    console.log(total);
}

fruitMarket("48","10","3.3","6.5","1.7");