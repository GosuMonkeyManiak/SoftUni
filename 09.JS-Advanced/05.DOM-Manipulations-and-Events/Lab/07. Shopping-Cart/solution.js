function solve() {
   let allButtonsRef = document.querySelectorAll('button.add-product');

   let allButtons = Array.from(allButtonsRef)
      .forEach(x => {
         x.addEventListener('click', addProduct);
      });;

   document.querySelector('.checkout').addEventListener('click', checkoutProducts);

   let textAreaRef = document.querySelector('textarea');
   
   let allProductsName = [];
   let sumOfPrices = 0;

   function addProduct(event){
      let productDiv = this.parentElement.parentElement;

      let productName = productDiv.children[1].children[0].textContent;
      let productPrice = productDiv.children[3].textContent;
      
      if (!allProductsName.some(x => x == productName)) {
         allProductsName.push(productName);
      }

      sumOfPrices += Number(productPrice);

      textAreaRef.textContent += `Added ${productName} for ${productPrice} to the cart.\n`
   }

   function checkoutProducts(event) {
      this.disabled = true;

      Array.from(allButtonsRef).forEach(x => {
         x.disabled = true;
      });

      textAreaRef.textContent += `You bought ${allProductsName.join(', ')} for ${sumOfPrices.toFixed(2)}.`;
   }
}