import { showView } from '../utilities.js';
import { showHome } from '../home.js';
import { showJan } from '../months/2023/jan-2023.js';
import { showFeb } from '../months/2023/feb-2023.js';
import { showMar } from '../months/2023/mar-2023.js';
import { showApr } from '../months/2023/apr-2023.js';
import { showMay } from '../months/2023/may-2023.js';
import { showJun } from '../months/2023/jun-2023.js';
import { showJul } from '../months/2023/jul-2023.js';
import { showAug } from '../months/2023/aug-2023.js';
import { showSept } from '../months/2023/sept-2023.js';
import { showOct } from '../months/2023/oct-2023.js';
import { showNov } from '../months/2023/nov-2023.js';
import { showDec } from '../months/2023/dec-2023.js';

const year2023 = document.querySelector('#year-2023');
year2023.remove();

year2023.querySelector('caption').addEventListener('click', showHome);
year2023.querySelector('tbody').addEventListener('click', onNavigate);

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

function showYear2023() {
    showView(year2023);
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
    showYear2023
}