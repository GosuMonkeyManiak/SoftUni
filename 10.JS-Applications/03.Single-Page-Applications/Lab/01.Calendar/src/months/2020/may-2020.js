import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const may2020 = document.querySelector('#month-2020-5');
may2020.remove();

may2020.querySelector('caption').addEventListener('click', showYear2020);

function showMay() {
    showView(may2020);
}

export {
    showMay
}