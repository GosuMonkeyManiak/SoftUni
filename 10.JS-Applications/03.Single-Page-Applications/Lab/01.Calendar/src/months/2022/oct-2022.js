import { showView } from "../../utilities.js";
import { showYear2022 } from "../../years/year2022.js";

const oct2022 = document.querySelector('#month-2022-10');
oct2022.remove();

oct2022.querySelector('caption').addEventListener('click', showYear2022);

function showOct() {
    showView(oct2022);
}

export {
    showOct
}