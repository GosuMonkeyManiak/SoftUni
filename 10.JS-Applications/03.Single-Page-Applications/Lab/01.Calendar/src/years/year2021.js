import { showView } from '../utilities.js';
import { showHome } from '../home.js';
import { showJan } from '../months/2021/jan-2021.js';
import { showFeb } from '../months/2021/feb-2021.js';
import { showMar } from '../months/2021/mar-2021.js';
import { showApr } from '../months/2021/apr-2021.js';
import { showMay } from '../months/2021/may-2021.js';
import { showJun } from '../months/2021/jun-2021.js';
import { showJul } from '../months/2021/jul-2021.js';
import { showAug } from '../months/2021/aug-2021.js';
import { showSept } from '../months/2021/sept-2021.js';
import { showOct } from '../months/2021/oct-2021.js';
import { showNov } from '../months/2021/nov-2021.js';
import { showDec } from '../months/2021/dec-2021.js';

const year2021 = document.querySelector('#year-2021');
year2021.remove();

year2021.querySelector('caption').addEventListener('click', showHome);
year2021.querySelector('tbody').addEventListener('click', onNavigate);

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

function showYear2021() {
    showView(year2021);
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
    showYear2021
}