function petShop(dogCount, anotherAnimals){

    let totalSum = 0;
    totalSum += Number(dogCount) * 2.50;
    totalSum += Number(anotherAnimals) * 4;

    console.log(`${totalSum} lv.`)
}

petShop("5","4");
petShop("13","9");