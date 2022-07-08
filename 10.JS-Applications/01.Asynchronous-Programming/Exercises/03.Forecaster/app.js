function attachEvents() {
    let wholeForecastDiv = document.getElementById('forecast');
    let currentForecastDiv = document.getElementById('current');
    let upcomingForecastDiv = document.getElementById('upcoming');

    document.getElementById('submit')
        .addEventListener('click', async e => {
            let location = document.getElementById('location').value;

            let locationCode = await getLocationCode(location);

            if (locationCode == undefined) {
                return;
            }

            let todayForecast = await getTodayForecast(locationCode);
            let upcomingForecast = await getUpcomingForecast(locationCode);

            createAndAppendTodayForecast(todayForecast);
            createAndAppendUpcomingForecast(upcomingForecast);

            wholeForecastDiv.style.display = 'block';
        });

    async function getLocationCode(location) {
        let url = `http://localhost:3030/jsonstore/forecaster/locations`;

        let response = await fetch(url);
        let data = await response.json();

        let locationObject = data.find(x => x.name == location);

        if (locationObject == undefined) {
            currentForecastDiv.firstElementChild.textContent = 'Error';
            upcomingForecastDiv.firstElementChild.textContent = '';
            wholeForecastDiv.style.display = 'block';

            if (currentForecastDiv.childElementCount == 2) {
                currentForecastDiv.lastElementChild.remove();
            }

            if (upcomingForecastDiv.childElementCount == 2) {
                upcomingForecastDiv.lastElementChild.remove();
            }
            return;
        }

        return locationObject.code;
    }

    async function getTodayForecast(locationCode) {
        let url = `http://localhost:3030/jsonstore/forecaster/today/${locationCode}`;

        let response = await fetch(url);
        let data = await response.json();

        return data;
    }

    async function getUpcomingForecast(locationCode) {
        let url = `http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`;

        let response = await fetch(url);
        let data = await response.json();

        return data;
    }

    function createAndAppendTodayForecast(todayForecast) {

        if (currentForecastDiv.childElementCount == 2) {
            currentForecastDiv.lastElementChild.remove();
        }

        setDefaultValueForCurrentAndUpcomingLables();

        let todayForeCastDiv = document.createElement('div');
        todayForeCastDiv.className = 'forecasts';

        let conditionSymbolSpan = document.createElement('span');
        conditionSymbolSpan.className = 'condition symbol';
        conditionSymbolSpan.innerHTML = getConditionSymbol(todayForecast.forecast.condition);
        todayForeCastDiv.appendChild(conditionSymbolSpan);

        let conditionSpan = document.createElement('span');
        conditionSpan.className = 'condition';

        let locationSpan = document.createElement('span');
        locationSpan.className = 'forecast-data';
        locationSpan.textContent = todayForecast.name;
        conditionSpan.appendChild(locationSpan);

        let locationDegreesSpan = document.createElement('span');
        locationDegreesSpan.className = 'forecast-data';
        locationDegreesSpan.innerHTML = `${todayForecast.forecast.low}&#176/${todayForecast.forecast.high}&#176`;
        conditionSpan.appendChild(locationDegreesSpan);

        let locationConditionTextSpan = document.createElement('span');
        locationConditionTextSpan.className = 'forecast-data';
        locationConditionTextSpan.textContent = todayForecast.forecast.condition;
        conditionSpan.appendChild(locationConditionTextSpan);

        todayForeCastDiv.appendChild(conditionSpan);

        currentForecastDiv.appendChild(todayForeCastDiv);
    }

    function createAndAppendUpcomingForecast(upcomingForecast) {

        if (upcomingForecastDiv.childElementCount == 2) {
            upcomingForecastDiv.lastElementChild.remove();
        }

        setDefaultValueForCurrentAndUpcomingLables();

        let upcomingForecastInfoDiv = document.createElement('div');
        upcomingForecastInfoDiv.className = 'forecast-info';

        for (const currentForecast of upcomingForecast.forecast) {
            
            let upcomingSpan = document.createElement('span');
            upcomingSpan.className = 'upcoming';

            let upcomingSymbolSpan = document.createElement('span');
            upcomingSymbolSpan.className = 'symbol';
            upcomingSymbolSpan.innerHTML = getConditionSymbol(currentForecast.condition);
            upcomingSpan.appendChild(upcomingSymbolSpan);

            let upcomingDegreesSpan = document.createElement('span');
            upcomingDegreesSpan.className = 'forecast-data';
            upcomingDegreesSpan.innerHTML = `${currentForecast.low}&#176/${currentForecast.high}&#176`;
            upcomingSpan.appendChild(upcomingDegreesSpan);

            let upcomingConditionTextSpan = document.createElement('span');
            upcomingConditionTextSpan.className = 'forecast-data';
            upcomingConditionTextSpan.textContent = currentForecast.condition;
            upcomingSpan.appendChild(upcomingConditionTextSpan);

            upcomingForecastInfoDiv.appendChild(upcomingSpan);
        }

        upcomingForecastDiv.appendChild(upcomingForecastInfoDiv);
    }

    function getConditionSymbol(condition) {

        switch (condition) {
            case 'Sunny':
                return '&#x2600;';

            case 'Partly sunny':
                return '&#x26C5;';

            case 'Overcast':
                return '&#x2601;';

            case 'Rain':
                return '&#x2614;';
        }
    }

    function setDefaultValueForCurrentAndUpcomingLables() {
        currentForecastDiv.firstElementChild.textContent = 'Current conditions';
        upcomingForecastDiv.firstElementChild.textContent = 'Three-day forecast';
    }
}

attachEvents();