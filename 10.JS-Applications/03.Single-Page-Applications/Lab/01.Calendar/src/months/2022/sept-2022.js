import { showView } from "../../utilities.js";
import { showYear2022 } from "../../years/year2022.js";

const sept2022 = document.querySelector('#month-2022-9');
sept2022.remove();

sept2022.querySelector('caption').addEventListener('click', showYear2022);

function showSept() {
    showView(sept2022);
}

export {
    showSept
}