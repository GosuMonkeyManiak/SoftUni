import { showYear2020 } from './years/year2020.js';
import { showYear2021 } from './years/year2021.js';
import { showYear2022 } from './years/year2022.js';
import { showYear2023 } from './years/year2023.js';
import { showHome } from './home.js';

showHome();

document.querySelector('#years .calendar').addEventListener('click', onNavigate);

const views = {
    '2020': showYear2020,
    '2021': showYear2021,
    '2022': showYear2022,
    '2023': showYear2023
}

function onNavigate(event) {
    let view;

    if (event.target.tagName == 'DIV') {
        view = views[event.target.textContent];
    } else if (event.target.tagName == 'TD') {
        let div = event.target.firstElementChild;
        view = views[div.textContent];
    }

    if (typeof view == 'function') {
        view();
    }
}