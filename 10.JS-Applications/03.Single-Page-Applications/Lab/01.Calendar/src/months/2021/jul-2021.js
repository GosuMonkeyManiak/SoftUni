import { showView } from '../../utilities.js';
import { showYear2021 } from '../../years/year2021.js';

const jul2021 = document.querySelector('#month-2021-7');
jul2021.remove();

jul2021.querySelector('caption').addEventListener('click', showYear2021);

function showJul() {
    showView(jul2021);
}

export {
    showJul
}