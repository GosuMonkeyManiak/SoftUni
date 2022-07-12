import { showView } from '../../utilities.js';
import { showYear2023 } from '../../years/year2023.js';

const jul2023 = document.querySelector('#month-2023-7');
jul2023.remove();

jul2023.querySelector('caption').addEventListener('click', showYear2023);

function showJul() {
    showView(jul2023);
}

export {
    showJul
}