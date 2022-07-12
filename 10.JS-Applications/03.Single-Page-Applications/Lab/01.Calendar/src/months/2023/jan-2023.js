import { showView } from '../../utilities.js'
import { showYear2023 } from '../../years/year2023.js';

const jan2023 = document.querySelector('#month-2023-1');
jan2023.remove();

jan2023.querySelector('caption').addEventListener('click', showYear2023);

function showJan() {
    showView(jan2023);
}

export {
    showJan
}