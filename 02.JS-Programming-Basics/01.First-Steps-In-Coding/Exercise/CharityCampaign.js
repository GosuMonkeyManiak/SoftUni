function charityCampaign(charityDays, countConfectioner, countCake, countGofer, countPancakes){

    let allCakes = (parseInt(countConfectioner) * parseInt(countCake)) * parseInt(charityDays);
    let allGofer = (parseInt(countConfectioner) * parseInt(countGofer)) * parseInt(charityDays);
    let allPancakes = (parseInt(countConfectioner) * parseInt(countPancakes)) * parseInt(charityDays);
    
    let allMoney = allCakes * 45 + allGofer * 5.80 + allPancakes * 3.20;
    let expenses = allMoney / 8;
    allMoney -= expenses;

    console.log(allMoney);
}

charityCampaign("23", "8", "14", "30", "16");