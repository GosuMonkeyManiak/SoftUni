import { showView } from '../../utilities.js';
import { showYear2020 } from '../../years/year2020.js';

const aug2020 = document.querySelector('#month-2020-8');
aug2020.remove();

aug2020.querySelector('caption').addEventListener('click', showYear2020);

function showAug() {
    showView(aug2020);
}

export {
    showAug
}