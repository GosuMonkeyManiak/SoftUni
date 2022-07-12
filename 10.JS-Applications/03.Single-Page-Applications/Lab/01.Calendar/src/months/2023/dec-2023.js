import { showView } from "../../utilities.js";
import { showYear2023 } from "../../years/year2023.js";

const dec2023 = document.querySelector('#month-2023-12');
dec2023.remove();

dec2023.querySelector('caption').addEventListener('click', showYear2023);

function showDec() {
    showView(dec2023);
}

export {
    showDec
}