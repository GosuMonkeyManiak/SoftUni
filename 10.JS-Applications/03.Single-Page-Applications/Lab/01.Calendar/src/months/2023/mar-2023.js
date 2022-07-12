import { showView } from '../../utilities.js';
import { showYear2023 } from '../../years/year2023.js';

const mar2023 = document.querySelector('#month-2023-3');
mar2023.remove();

mar2023.querySelector('caption').addEventListener('click', showYear2023);

function showMar() {
    showView(mar2023);
}

export {
    showMar
}