import { showView } from "../../utilities.js";
import { showYear2023 } from "../../years/year2023.js";

const oct2023 = document.querySelector('#month-2023-10');
oct2023.remove();

oct2023.querySelector('caption').addEventListener('click', showYear2023);

function showOct() {
    showView(oct2023);
}

export {
    showOct
}