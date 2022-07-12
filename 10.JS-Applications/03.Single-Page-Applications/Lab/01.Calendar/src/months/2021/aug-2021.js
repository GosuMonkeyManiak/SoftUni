import { showView } from "../../utilities.js";
import { showYear2021 } from "../../years/year2021.js";

const aug2021 = document.querySelector('#month-2021-8');
aug2021.remove();

aug2021.querySelector('caption').addEventListener('click', showYear2021);

function showAug() {
    showView(aug2021);
}

export {
    showAug
}