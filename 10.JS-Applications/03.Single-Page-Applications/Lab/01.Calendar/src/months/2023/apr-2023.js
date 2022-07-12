import { showView } from '../../utilities.js';
import { showYear2023 } from '../../years/year2023.js';

const apr2023 = document.querySelector('#month-2023-4');
apr2023.remove();

apr2023.querySelector('caption').addEventListener('click', showYear2023);

function showApr() {
    showView(apr2023);
}

export {
    showApr
}