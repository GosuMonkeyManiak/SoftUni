import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const oct2020 = document.querySelector('#month-2020-10');
oct2020.remove();

oct2020.querySelector('caption').addEventListener('click', showYear2020);

function showOct() {
    showView(oct2020);
}

export {
    showOct
}