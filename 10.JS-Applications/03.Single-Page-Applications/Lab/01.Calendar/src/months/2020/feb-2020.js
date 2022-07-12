import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const feb2020 = document.querySelector('#month-2020-2');
feb2020.remove();

feb2020.querySelector('caption').addEventListener('click', showYear2020);

function showFeb() {
    showView(feb2020);
}

export {
    showFeb
}