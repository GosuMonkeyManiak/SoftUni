import { showView } from '../utilities.js';
import { showHome } from '../home.js';
import { showJan } from '../months/2020/jan-2020.js';
import { showFeb } from '../months/2020/feb-2020.js';
import { showMar } from '../months/2020/mar-2020.js';
import { showApr } from '../months/2020/apr-2020.js';
import { showMay } from '../months/2020/may-2020.js';
import { showJun } from '../months/2020/jun-2020.js';
import { showJul } from '../months/2020/jul-2020.js';
import { showAug } from '../months/2020/aug-2020.js';
import { showSept } from '../months/2020/sept-2020.js';
import { showOct } from '../months/2020/oct-2020.js';
import { showNov } from '../months/2020/nov-2020.js';
import { showDec } from '../months/2020/dec-2020.js';

const year2020 = document.querySelector('#year-2020');
year2020.remove();

year2020.querySelector('caption').addEventListener('click', showHome);
year2020.querySelector('tbody').addEventListener('click', onNavigation);

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
};

function showYear2020() {
    showView(year2020);
}

function onNavigation(event) {
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
    showYear2020
}