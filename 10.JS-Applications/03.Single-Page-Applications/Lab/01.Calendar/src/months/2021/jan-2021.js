import { showView } from '../../utilities.js'
import { showYear2021 } from '../../years/year2021.js';

const jan2021 = document.querySelector('#month-2021-1');
jan2021.remove();

jan2021.querySelector('caption').addEventListener('click', showYear2021);

function showJan() {
    showView(jan2021);
}

export {
    showJan
}