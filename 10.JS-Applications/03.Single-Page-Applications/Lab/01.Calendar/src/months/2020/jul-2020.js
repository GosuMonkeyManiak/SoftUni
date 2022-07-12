import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const jul2020 = document.querySelector('#month-2020-7');
jul2020.remove();

jul2020.querySelector('caption').addEventListener('click', showYear2020);

function showJul() {
    showView(jul2020);
}

export {
    showJul
}