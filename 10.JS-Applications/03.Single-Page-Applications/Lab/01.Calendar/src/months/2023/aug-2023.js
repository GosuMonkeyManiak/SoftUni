import { showView } from "../../utilities.js";
import { showYear2023 } from "../../years/year2023.js";

const aug2023 = document.querySelector('#month-2023-8');
aug2023.remove();

aug2023.querySelector('caption').addEventListener('click', showYear2023);

function showAug() {
    showView(aug2023);
}

export {
    showAug
}