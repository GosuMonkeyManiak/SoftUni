import { showView } from "../../utilities.js";
import { showYear2021 } from "../../years/year2021.js";

const oct2021 = document.querySelector('#month-2021-10');
oct2021.remove();

oct2021.querySelector('caption').addEventListener('click', showYear2021);

function showOct() {
    showView(oct2021);
}

export {
    showOct
}