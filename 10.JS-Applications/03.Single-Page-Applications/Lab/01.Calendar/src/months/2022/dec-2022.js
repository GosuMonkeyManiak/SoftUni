import { showView } from "../../utilities.js";
import { showYear2022 } from "../../years/year2022.js";

const dec2022 = document.querySelector('#month-2022-12');
dec2022.remove();

dec2022.querySelector('caption').addEventListener('click', showYear2022);

function showDec() {
    showView(dec2022);
}

export {
    showDec
}