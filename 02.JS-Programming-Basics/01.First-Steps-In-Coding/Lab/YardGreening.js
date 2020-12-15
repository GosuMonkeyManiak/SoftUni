function yardGreening(inPut){

    let meters = Number(inPut);

    let totalPrice = meters * 7.61;
    let discount = totalPrice * 0.18;
    totalPrice -= discount;

    console.log(`The final price is: ${totalPrice} lv.`)
    console.log(`The discount is: ${discount} lv.`)
}

yardGreening("550");
yardGreening("150");