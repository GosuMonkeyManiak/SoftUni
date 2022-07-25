import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

window.addEventListener('load', load);

function load() {
    let townTemplate = (town) => html`<li>${town}</li>`;

    let townsTempplate = (towns, townTemplate) => html`<ul>
        ${towns.map(townTemplate)}
    </ul>`;

    render(townsTempplate(towns, townTemplate), document.querySelector('#towns'));
}

document.querySelector('article button').addEventListener('click', e => {
    let searchTown = document.querySelector('input[type="text"]').value;

    let lis = document.querySelectorAll('#towns ul li');

    lis.forEach(li => {
        li.classList.remove('active');
    });

    let matches = 0;

    lis.forEach(li => {
        if (li.textContent.includes(searchTown)) {
            li.classList.add('active');        
            matches++;
        }
    });

    document.querySelector('#result').textContent = `${matches} matches found`;
});