import { showView } from '../../utilities.js';
import { showYear2023 } from '../../years/year2023.js';

const may2023 = document.querySelector('#month-2023-5');
may2023.remove();

may2023.querySelector('caption').addEventListener('click', showYear2023);

function showMay() {
    showView(may2023);
}

export {
    showMay
}