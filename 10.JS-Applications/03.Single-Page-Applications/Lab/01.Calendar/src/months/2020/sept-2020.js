import { showView } from '../../utilities.js'
import { showYear2020 } from '../../years/year2020.js';

const sept2020 = document.querySelector('#month-2020-9');
sept2020.remove();

sept2020.querySelector('caption').addEventListener('click', showYear2020);

function showSept() {
    showView(sept2020);
}

export {
    showSept
}