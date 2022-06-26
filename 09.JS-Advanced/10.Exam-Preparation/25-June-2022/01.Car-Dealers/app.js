window.addEventListener('load', solve);

function solve() {
	
	const makeInput = document.getElementById('make');
	const modelInput = document.getElementById('model');
	const productionYearInput = document.getElementById('year');
	const fuelTypeInput = document.getElementById('fuel');
	const originalCostInput = document.getElementById('original-cost');
	const sellingPriceInput = document.getElementById('selling-price');

	const tableOfCars = document.getElementById('table-body');
	const carsList = document.getElementById('cars-list');
	const profit = document.getElementById('profit');

	document.getElementById('publish').addEventListener('click', e => {
		e.preventDefault();

		let makeValue = makeInput.value;
		let modelValue = modelInput.value;
		let productionYearValue = productionYearInput.value;
		let fuelTypeValue = fuelTypeInput.value;
		let originalCostValue = originalCostInput.value;
		let sellingPriceValue = sellingPriceInput.value;

		if (makeValue == '' ||
			modelValue == '' ||
			productionYearValue == '' ||
			fuelTypeValue == '' ||
			originalCostValue == '' ||
			sellingPriceValue == '' ||
			Number(originalCostValue) > Number(sellingPriceValue)) {
			return;
		}

		let tRow = document.createElement('tr');

		let tdMake = document.createElement('td');
		tdMake.textContent = makeValue;
		tRow.appendChild(tdMake);

		let tdModel = document.createElement('td');
		tdModel.textContent = modelValue;
		tRow.appendChild(tdModel);

		let tdYear = document.createElement('td');
		tdYear.textContent = productionYearValue;
		tRow.appendChild(tdYear);

		let tdFuel = document.createElement('td');
		tdFuel.textContent = fuelTypeValue;
		tRow.appendChild(tdFuel);

		let tdOriginalCost = document.createElement('td');
		tdOriginalCost.textContent = originalCostValue;
		tRow.appendChild(tdOriginalCost);

		let tdSellingPrice = document.createElement('td');
		tdSellingPrice.textContent = sellingPriceValue;
		tRow.appendChild(tdSellingPrice);

		let tdForActions = document.createElement('td');

		let editButton = document.createElement('button');
		editButton.textContent = 'Edit';
		editButton.classList.add('action-btn');
		editButton.classList.add('edit');
		editButton.addEventListener('click', e => {
			tRow.remove();

			makeInput.value = makeValue;
			modelInput.value = modelValue;
			productionYearInput.value = productionYearValue;
			fuelTypeInput.value = fuelTypeValue;
			originalCostInput.value = originalCostValue;
			sellingPriceInput.value = sellingPriceValue;
		});
		tdForActions.appendChild(editButton);

		let sellButton = document.createElement('button');
		sellButton.textContent = 'Sell';
		sellButton.classList.add('action-btn');
		sellButton.classList.add('sell');
		sellButton.addEventListener('click', sell.bind(null, tRow, makeValue, modelValue, productionYearValue, originalCostValue, sellingPriceValue));
		tdForActions.appendChild(sellButton);

		tRow.appendChild(tdForActions);

		tableOfCars.appendChild(tRow);

		makeInput.value = '';
		modelInput.value = '';
		productionYearInput.value = '';
		fuelTypeInput.value = '';
		originalCostInput.value = '';
		sellingPriceInput.value = '';
	});

	function sell(tRow, carMake, carModel, productionYear, originalCost, sellingprice) {

		tRow.remove();

		let carLi = document.createElement('li');
		carLi.className = 'each-list';

		let spanMakeAndModel = document.createElement('span');
		spanMakeAndModel.textContent = `${carMake} ${carModel}`;
		carLi.appendChild(spanMakeAndModel);

		let spanProductionYear = document.createElement('span');
		spanProductionYear.textContent = productionYear;
		carLi.appendChild(spanProductionYear);

		let currentProfit = sellingprice - originalCost;

		let spanDifference = document.createElement('span');
		spanDifference.textContent = currentProfit;
		carLi.appendChild(spanDifference);

		carsList.appendChild(carLi);

		profit.textContent = (Number(profit.textContent) + Number(currentProfit)).toFixed(2);
	}
}
