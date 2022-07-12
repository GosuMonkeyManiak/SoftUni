import { showView } from '../utilities.js';
import { showHome } from '../home.js';
import { showJan } from '../months/2022/jan-2022.js';
import { showFeb } from '../months/2022/feb-2022.js';
import { showMar } from '../months/2022/mar-2022.js';
import { showApr } from '../months/2022/apr-2022.js';
import { showMay } from '../months/2022/may-2022.js';
import { showJun } from '../months/2022/jun-2022.js';
import { showJul } from '../months/2022/jul-2022.js';
import { showAug } from '../months/2022/aug-2022.js';
import { showSept } from '../months/2022/sept-2022.js';
import { showOct } from '../months/2022/oct-2022.js';
import { showNov } from '../months/2022/nov-2022.js';
import { showDec } from '../months/2022/dec-2022.js';

const year2022 = document.querySelector('#year-2022');
year2022.remove();

year2022.querySelector('caption').addEventListener('click', showHome);
year2022.querySelector('tbody').addEventListener('click', onNavigate);

const monthsViews = {
    'Jan': showJan,
    'Feb': showFeb,
    'Mar': showMar,
    'Apr': showApr,
    'May': showMay,
    'Jun': showJun,
    'Jul': showJul,
    'Aug': showAug,
    'Sept': showSept,
    'Oct': showOct,
    'Nov': showNov,
    'Dec': showDec,
}

function showYear2022() {
    showView(year2022);
}

function onNavigate(event) {
    let monthView;

    if (event.target.tagName == 'DIV') {
        monthView = monthsViews[event.target.textContent];
    } else if (event.target.tagName == 'TD') {
        let div = event.target.firstElementChild;
        monthView = monthsViews[div.textContent];
    }

    if (typeof monthView == 'function') {
        monthView();        
    }
}

export {
    showYear2022
}