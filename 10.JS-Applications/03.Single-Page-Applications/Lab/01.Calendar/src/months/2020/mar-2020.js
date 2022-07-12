import { showView } from '../../utilities.js'
import { showYear2020 } from '../../years/year2020.js';

const mar2020 = document.querySelector('#month-2020-3');
mar2020.remove();

mar2020.querySelector('caption').addEventListener('click', showYear2020);

function showMar() {
    showView(mar2020);
}

export {
    showMar
}