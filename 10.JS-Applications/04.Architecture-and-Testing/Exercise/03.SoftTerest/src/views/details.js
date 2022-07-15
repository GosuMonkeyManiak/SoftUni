import { del, get } from '../api.js';
import { showView } from '../utilities.js';

const detailsView = document.querySelector('#detailsView');
detailsView.remove();

const divDeleteSection = detailsView.querySelector('.text-center');
divDeleteSection.remove();

let context = null

function setupDetails(innerContext) {
    context = innerContext;
}

async function showDetails(event) {
    event.preventDefault();

    let ideaId = event.target.dataset.id;

    if (ideaId == undefined) {
        context.goTo('dashboard');
        return;
    }

    let idea;

    try {
        idea = await getIdeaById(ideaId);
    } catch (error) {
        alert(error.message);
        return;
    }

    loadIdea(idea);
    showView(detailsView);
}

async function getIdeaById(ideaId) {
    return await get(`/data/ideas/${ideaId}`);
}

function loadIdea(idea) {
    detailsView.querySelector('img').src = idea.img;
    detailsView.querySelector('h2').textContent = idea.title;
    detailsView.querySelector('.idea-description').textContent = idea.description;

    let userId = sessionStorage.getItem('id');

    if (userId == idea._ownerId) {
        let deleteButton = divDeleteSection.querySelector('a');
        deleteButton.dataset.id = idea._id;
        deleteButton.addEventListener('click', onDelete);

        detailsView.appendChild(divDeleteSection);
    } else {
        divDeleteSection.remove();
    }
}

async function onDelete(event) {
    let ideaId = event.target.dataset.id;

    if (ideaId == undefined) {
        context.goTo('dashboard');
        return;
    }

    try {
        await del(`/data/ideas/${ideaId}`);
    } catch (error) {
        alert(error.message);
        return;
    }

    context.goTo('dashboard');
}

export {
    showDetails,
    setupDetails
}