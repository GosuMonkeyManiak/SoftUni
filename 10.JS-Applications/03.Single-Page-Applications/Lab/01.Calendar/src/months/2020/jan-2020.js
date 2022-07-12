import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const jan2020 = document.querySelector('#month-2020-1');
jan2020.remove();

jan2020.querySelector('caption').addEventListener('click', showYear2020);

function showJan() {
    showView(jan2020);
}

export {
    showJan
}