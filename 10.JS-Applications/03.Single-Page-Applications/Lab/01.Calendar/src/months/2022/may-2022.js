import { showView } from '../../utilities.js';
import { showYear2022 } from '../../years/year2022.js';

const may2022 = document.querySelector('#month-2022-5');
may2022.remove();

may2022.querySelector('caption').addEventListener('click', showYear2022);

function showMay() {
    showView(may2022);
}

export {
    showMay
}