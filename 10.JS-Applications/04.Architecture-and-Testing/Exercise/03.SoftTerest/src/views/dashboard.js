import { get } from '../api.js';
import { showView } from '../utilities.js';

const dashboardView = document.querySelector('#dashboard-holder');
dashboardView.remove();

let context = null;

function showDashborad(innerContext) {
    context = innerContext;
    loadIdeas();
    showView(dashboardView);
}

async function getAllIdeas() {
    return await get('/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
}

async function loadIdeas() {
    let ideas = await getAllIdeas();

    if (ideas.length == 0) {
        let h1 = document.createElement('h1');
        h1.textContent = 'No ideas yet! Be the first one :)';

        dashboardView.replaceChildren(h1);
    } else {
        dashboardView.innerHTML = '';

        ideas.forEach(idea => {
            dashboardView.appendChild(createIdeaLayout(idea));
        });
    }
}

function createIdeaLayout(idea) {
    let divCard = document.createElement('div');
    divCard.className = 'card overflow-hidden current-card details';
    divCard.style.width = '20rem';
    divCard.style.height = '18rem';

    let divCardBody = document.createElement('div');
    divCardBody.className = 'card-body';

    let pTitle = document.createElement('p');
    pTitle.className = 'card-text';
    pTitle.textContent = idea.title;
    divCardBody.appendChild(pTitle);

    divCard.appendChild(divCardBody);

    let img = document.createElement('img');
    img.className = 'card-image';
    img.src = idea.img;
    divCard.appendChild(img);

    let detailsButton = document.createElement('a');
    detailsButton.className = 'btn';
    detailsButton.dataset.id = idea._id;
    detailsButton.textContent = 'Details';
    detailsButton.addEventListener('click', e => context.getViewFunction('details').call(null, e));
    divCard.appendChild(detailsButton);

    return divCard;
}

export {
    showDashborad
}