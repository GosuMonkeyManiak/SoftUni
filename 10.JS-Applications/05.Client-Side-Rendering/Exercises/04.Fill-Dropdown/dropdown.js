import { html, render } from '../node_modules/lit-html/lit-html.js';

window.addEventListener('load', loadItems);
document.querySelector('form').addEventListener('submit', addItem)

async function loadItems() {
    let response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    let items = Object.values(await response.json());

    let itemTemplate = (item) => html`<option .value=${item._id}>
        ${item.text}
    </option>`;

    let itemOptions = items.map(itemTemplate);

    render(itemOptions, document.querySelector('#menu'));
}

async function addItem(event) {
    event.preventDefault();
    let input = document.querySelector('#itemText');
    
    let newItem = {
        text: input.value
    };

    try {
        let response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newItem)
        });

        if (!response.ok) {
            throw new Error('Something went wrong!')
        }

    } catch (error) {
        alert(error.message);
        return;
    }

    input.value = '';
    loadItems();
}