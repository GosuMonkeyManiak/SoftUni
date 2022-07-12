import { showView } from "../../utilities.js";
import { showYear2021 } from "../../years/year2021.js";

const sept2021 = document.querySelector('#month-2021-9');
sept2021.remove();

sept2021.querySelector('caption').addEventListener('click', showYear2021)

function showSept() {
    showView(sept2021);
}

export {
    showSept
}