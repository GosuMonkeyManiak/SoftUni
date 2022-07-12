import { showView } from "../../utilities.js";
import { showYear2023 } from "../../years/year2023.js";

const sept2023 = document.querySelector('#month-2023-9');
sept2023.remove();

sept2023.querySelector('caption').addEventListener('click', showYear2023);

function showSept() {
    showView(sept2023);
}

export {
    showSept
}