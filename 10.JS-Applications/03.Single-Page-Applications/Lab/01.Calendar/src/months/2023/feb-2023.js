import { showView } from '../../utilities.js'
import { showYear2023 } from '../../years/year2023.js';

const feb2023 = document.querySelector('#month-2023-2');
feb2023.remove();

feb2023.querySelector('caption').addEventListener('click', showYear2023);

function showFeb() {
    showView(feb2023);
}

export {
    showFeb
}