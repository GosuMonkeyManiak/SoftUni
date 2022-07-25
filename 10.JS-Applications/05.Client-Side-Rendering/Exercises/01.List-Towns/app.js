import { html, render } from '../node_modules/lit-html/lit-html.js';

document.querySelector('form').addEventListener('submit', e => {
    e.preventDefault();

    let towns = document.querySelector('#towns').value
        .split(', ');

    let townsTemplate = (towns) => html`<ul>
            ${towns.map(t => html`<li>${t}</li>`)}
        </ul>`;

    render(townsTemplate(towns), document.querySelector('#root'));
});