import { contacts } from './contacts.js';
import { contactTemplate } from './views/card.js';
import { render } from '../../node_modules/lit-html/lit-html.js';

window.addEventListener('load', load);

async function load() {
    let contactList = document.querySelector('#contacts');

    let allContactTemplates = [];

    for (let index = 0; index < contacts.length; index++) {
        const contact = contacts[index];
        
        allContactTemplates.push(contactTemplate(contact, details));
    }

    render(allContactTemplates, contactList);
}

function details(event) {
    let divMoreInfo = event.currentTarget.parentElement.lastElementChild;

    if (divMoreInfo.style.display == 'none' || divMoreInfo.style.display == '') {
        divMoreInfo.style.display = 'inline-block';
    } else {
        divMoreInfo.style.display = 'none';
    }
}