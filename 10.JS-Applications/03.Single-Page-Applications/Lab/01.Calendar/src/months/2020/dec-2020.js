import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const dec2020 = document.querySelector('#month-2020-12');
dec2020.remove();

dec2020.querySelector('caption').addEventListener('click', showYear2020);

function showDec() {
    showView(dec2020);
}

export {
    showDec
}