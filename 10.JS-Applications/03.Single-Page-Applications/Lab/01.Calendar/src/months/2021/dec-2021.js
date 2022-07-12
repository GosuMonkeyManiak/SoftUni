import { showView } from "../../utilities.js";
import { showYear2021 } from "../../years/year2021.js";

const dec2021 = document.querySelector('#month-2021-12');
dec2021.remove();

dec2021.querySelector('caption').addEventListener('click', showYear2021);

function showDec() {
    showView(dec2021);
}

export {
    showDec
}