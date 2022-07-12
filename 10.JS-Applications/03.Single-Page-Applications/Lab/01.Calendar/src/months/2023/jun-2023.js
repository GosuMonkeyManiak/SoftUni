import { showView } from '../../utilities.js';
import { showYear2023 } from '../../years/year2023.js';

const jun2023 = document.querySelector('#month-2023-6');
jun2023.remove();

jun2023.querySelector('caption').addEventListener('click', showYear2023);

function showJun() {
    showView(jun2023);
}

export {
    showJun
}