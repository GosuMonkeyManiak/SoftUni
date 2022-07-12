import { showView } from "../../utilities.js";
import { showYear2022 } from "../../years/year2022.js";

const aug2022 = document.querySelector('#month-2022-8');
aug2022.remove();

aug2022.querySelector('caption').addEventListener('click', showYear2022);

function showAug() {
    showView(aug2022);
}

export {
    showAug
}