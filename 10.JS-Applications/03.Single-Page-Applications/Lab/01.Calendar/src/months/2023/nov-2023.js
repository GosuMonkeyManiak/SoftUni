import { showView } from "../../utilities.js";
import { showYear2023 } from "../../years/year2023.js";

const nov2023 = document.querySelector('#month-2023-11');
nov2023.remove();

nov2023.querySelector('caption').addEventListener('click', showYear2023);

function showNov() {
    showView(nov2023);
}

export {
    showNov
}