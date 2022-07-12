import { showView } from '../../utilities.js'
import { showYear2022 } from '../../years/year2022.js';

const jan2022 = document.querySelector('#month-2022-1');
jan2022.remove();

jan2022.querySelector('caption').addEventListener('click', showYear2022);

function showJan() {
    showView(jan2022);
}

export {
    showJan
}