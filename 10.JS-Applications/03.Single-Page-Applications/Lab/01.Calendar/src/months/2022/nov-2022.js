import { showView } from "../../utilities.js";
import { showYear2022 } from "../../years/year2022.js";

const nov2022 = document.querySelector('#month-2022-11');
nov2022.remove();

nov2022.querySelector('caption').addEventListener('click', showYear2022);

function showNov() {
    showView(nov2022);
}

export {
    showNov
}