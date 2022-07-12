import { showView } from '../../utilities.js'
import { showYear2022 } from '../../years/year2022.js';

const feb2022 = document.querySelector('#month-2022-2');
feb2022.remove();

feb2022.querySelector('caption').addEventListener('click', showYear2022);

function showFeb() {
    showView(feb2022);
}

export {
    showFeb
}