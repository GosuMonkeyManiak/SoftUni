import { showView } from '../../utilities.js';
import { showYear2021 } from '../../years/year2021.js';

const may2021 = document.querySelector('#month-2021-5');
may2021.remove();

may2021.querySelector('caption').addEventListener('click', showYear2021);

function showMay() {
    showView(may2021);
}

export {
    showMay
}