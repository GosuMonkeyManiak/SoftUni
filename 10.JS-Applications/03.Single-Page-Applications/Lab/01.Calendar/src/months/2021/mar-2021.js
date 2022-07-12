import { showView } from '../../utilities.js';
import { showYear2021 } from '../../years/year2021.js';

const mar2021 = document.querySelector('#month-2021-3');
mar2021.remove();

mar2021.querySelector('caption').addEventListener('click', showYear2021);

function showMar() {
    showView(mar2021);
}

export {
    showMar
}