import { showView } from '../../utilities.js';
import { showYear2022 } from '../../years/year2022.js';

const jun2022 = document.querySelector('#month-2022-6');
jun2022.remove();

jun2022.querySelector('caption').addEventListener('click', showYear2022);

function showJun() {
    showView(jun2022);
}

export {
    showJun
}