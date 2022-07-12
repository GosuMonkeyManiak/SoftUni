import { showView } from '../../utilities.js';
import { showYear2021 } from '../../years/year2021.js';

const jun2021 = document.querySelector('#month-2021-6');
jun2021.remove();

jun2021.querySelector('caption').addEventListener('click', showYear2021);

function showJun() {
    showView(jun2021);
}

export {
    showJun
}