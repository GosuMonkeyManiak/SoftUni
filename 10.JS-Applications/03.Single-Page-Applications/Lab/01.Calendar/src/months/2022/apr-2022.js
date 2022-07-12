import { showView } from '../../utilities.js';
import { showYear2022 } from '../../years/year2022.js';

const apr2022 = document.querySelector('#month-2022-4');
apr2022.remove();

apr2022.querySelector('caption').addEventListener('click', showYear2022);

function showApr() {
    showView(apr2022);
}

export {
    showApr
}