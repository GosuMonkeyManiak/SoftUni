import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const jun2020 = document.querySelector('#month-2020-6');
jun2020.remove();

jun2020.querySelector('caption').addEventListener('click', showYear2020);

function showJun() {
    showView(jun2020);
}

export {
    showJun
}