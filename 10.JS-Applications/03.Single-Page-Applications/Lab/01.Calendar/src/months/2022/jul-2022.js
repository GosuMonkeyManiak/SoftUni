import { showView } from '../../utilities.js';
import { showYear2022 } from '../../years/year2022.js';

const jul2022 = document.querySelector('#month-2022-7');
jul2022.remove();

jul2022.querySelector('caption').addEventListener('click', showYear2022);

function showJul() {
    showView(jul2022);
}

export {
    showJul
}