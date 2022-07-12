import { showView } from "../../utilities.js";
import { showYear2021 } from "../../years/year2021.js";

const nov2021 = document.querySelector('#month-2021-11');
nov2021.remove();

nov2021.querySelector('caption').addEventListener('click', showYear2021);

function showNov() {
    showView(nov2021);
}

export {
    showNov
}