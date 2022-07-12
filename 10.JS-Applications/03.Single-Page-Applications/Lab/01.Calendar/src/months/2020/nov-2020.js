import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const nov2020 = document.querySelector('#month-2020-11');
nov2020.remove();

nov2020.querySelector('caption').addEventListener('click', showYear2020);

function showNov() {
    showView(nov2020);
}

export {
    showNov
}