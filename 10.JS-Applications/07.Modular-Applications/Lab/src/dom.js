import { html, render, nothing } from '../node_modules/lit-html/lit-html.js';
import { until } from '../node_modules/lit-html/directives/until.js';

const main = document.querySelector('body main');
const nav = document.querySelector('body header nav');

function renderNav(hydratedNavTemplate) {
    render(hydratedNavTemplate, nav);
}

function renderTemplate(hydratedTemplate) {
    render(hydratedTemplate, main);
}

export {
    html,
    render,
    until,
    nothing,
    renderNav,
    renderTemplate
};