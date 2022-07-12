import { showView } from '../../utilities.js';
import { showYear2021 } from '../../years/year2021.js';

const apr2021 = document.querySelector('#month-2021-4');
apr2021.remove();

apr2021.querySelector('caption').addEventListener('click', showYear2021);

function showApr() {
    showView(apr2021);
}

export {
    showApr
}