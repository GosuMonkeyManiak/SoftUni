import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const apr2020 = document.querySelector('#month-2020-4');
apr2020.remove();

apr2020.querySelector('caption').addEventListener('click', showYear2020);

function showApr() {
    showView(apr2020);
}

export {
    showApr
}