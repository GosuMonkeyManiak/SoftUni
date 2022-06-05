function solve() {
    
    document.querySelectorAll('#exercise button')[0]
        .addEventListener('click', e => {
            let input = JSON.parse(document.querySelectorAll('#exercise textarea')[0].value);
            let tbodyRef = document.querySelector('tbody');

            for (let i = 0; i < input.length; i++) {

                let tr = document.createElement('tr');

                let tdImage = document.createElement('td');
                createElementAndAppend('img', tdImage).src = input[i].img;
                tr.appendChild(tdImage);

                let tdName = document.createElement('td');
                createElementAndAppend('p', tdName).textContent = input[i].name;
                tr.appendChild(tdName);

                let tdPrice = document.createElement('td');
                createElementAndAppend('p', tdPrice).textContent = input[i].price;
                tr.appendChild(tdPrice)

                let tdDecorationFactor = document.createElement('td');
                createElementAndAppend('p', tdDecorationFactor).textContent = input[i].decFactor;
                tr.appendChild(tdDecorationFactor);

                let tdMark = document.createElement('td');
                let inputElement = createElementAndAppend('input', tdMark);
                inputElement.type = 'checkbox';
                tr.appendChild(tdMark);
                
                tbodyRef.appendChild(tr);
            }
        });

    document.querySelectorAll('#exercise button')[1]
        .addEventListener('click', e => {
            let allCheckedRows = Array.from(document.querySelectorAll('td input[type="checkbox"]'))
                .filter(e => e.checked)
                .map(e => e.parentElement.parentElement);

            let allFirnitures = [];
            let totalCost = 0;
            let averageDecorationFactor = 0;

            for (let i = 0; i < allCheckedRows.length; i++) {
                let firnitureName = allCheckedRows[i].children[1].children[0].textContent;

                if (!allFirnitures.some(x => x == firnitureName)) {
                    allFirnitures.push(firnitureName);
                }
                
                totalCost += Number(allCheckedRows[i].children[2].children[0].textContent);
                averageDecorationFactor += Number(allCheckedRows[i].children[3].children[0].textContent);
            }

            averageDecorationFactor /= allFirnitures.length;

            let textAreaOutPut = document.querySelectorAll('#exercise textarea')[1];

            textAreaOutPut.value += `Bought furniture: ${allFirnitures.join(', ')}\n`;
            textAreaOutPut.value += `Total price: ${totalCost.toFixed(2)}\n`;
            textAreaOutPut.value +=  `Average decoration factor: ${averageDecorationFactor}`;
        });

    function createElementAndAppend(elementName, parentElement) {
        let element = document.createElement(elementName);
        parentElement.appendChild(element);
        return element;
    }
}