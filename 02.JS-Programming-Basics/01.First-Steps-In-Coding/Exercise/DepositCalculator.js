function depositCalcualtor(depositMoney, periodOfDeposit, yearInterest){

    let percentage = Number(yearInterest) / 100;
    let moneyToGet = Number(depositMoney) + parseInt(periodOfDeposit) * ((Number(depositMoney) * percentage) / 12);

    console.log(moneyToGet);
}

depositCalcualtor("200","3","5.7");