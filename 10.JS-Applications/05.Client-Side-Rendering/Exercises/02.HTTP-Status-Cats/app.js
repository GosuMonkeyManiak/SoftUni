import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

window.addEventListener('load', load);

function load() {
    let catCardTemplate = (cat) => html`<li>
                <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
                <div class="info">
                    <button class="showBtn" @click=${toggle}>Show status code</button>
                    <div class="status" style="display: none" id=${cat.id}>
                        <h4>Status Code: ${cat.statusCode}</h4>
                        <p>${cat.statusMessage}</p>
                    </div>
                </div>
            </li>`;

    let allCatTemplate = (cats, catCardTemplate) => html`<ul>
        ${cats.map(catCardTemplate)}
    </ul>`;

    render(allCatTemplate(cats, catCardTemplate), document.querySelector('#allCats'))
}

function toggle(event) {
    let button = event.target;
    let divMoreInfo = button.parentElement.lastElementChild;

    if (button.textContent == 'Show status code') {

        button.textContent = 'Hide status code';
        divMoreInfo.style.display = 'inline-block';
    } else { //Hide status code
        button.textContent = 'Show status code';
        divMoreInfo.style.display = 'none';
    }
}