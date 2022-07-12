import { showView } from '../../utilities.js'
import { showYear2021 } from '../../years/year2021.js';

const feb2021 = document.querySelector('#month-2021-2');
feb2021.remove();

feb2021.querySelector('caption').addEventListener('click', showYear2021);

function showFeb() {
    showView(feb2021);
}

export {
    showFeb
}