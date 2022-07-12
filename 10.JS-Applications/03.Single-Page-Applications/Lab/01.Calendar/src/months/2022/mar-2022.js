import { showView } from '../../utilities.js';
import { showYear2022 } from '../../years/year2022.js';

const mar2022 = document.querySelector('#month-2022-3');
mar2022.remove();

mar2022.querySelector('caption').addEventListener('click', showYear2022);

function showMar() {
    showView(mar2022);
}

export {
    showMar
}