import { getAll, getCount } from '../services/teams.js';
import { getCountByTeamId } from '../services/members.js';

import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { until } from '../../node_modules/lit-html/directives/until.js';

const browseTemplate = (allTeams, isHaveUser, currentPage, lastPage) => html`
<section id="browse">
    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>

    ${isHaveUser
        ? html`
            <article class="layout narrow">
                <div class="pad-small"><a href="#" class="action cta">Create Team</a></div>
            </article>`
        : nothing}

    ${until((async () => teamTemplateWrapper(await allTeams))(), 'Loading...')}

    <div>
        <a .href=${currentPage > 1 ? ('/browse/' + (currentPage - 1)) : 'javascript:void(0)'} class="action"><< Previous</a>
        <a .href=${currentPage < lastPage ? ('/browse/' + (currentPage + 1)) : 'javascript:void(0)'} class="action">Next >></a>
    </div>
</section>`;

const teamTemplateWrapper = (allTeams) => html`
<div>
    ${allTeams.map(teamTemplate)}
</div>`;

const teamTemplate = (team) => html`
<article class="layout">
    <img .src=${team.logoUrl} class="team-logo left-col">

    <div class="tm-preview">
        <h2>${team.name}</h2>
        <p>${team.description}</p>
        <span class="details">${until((async () => await getCountByTeamId(team._id))(), 'Loading...')} Members</span>
        <div>
            <a href="/details/${team._id}" class="action">See details</a>
        </div>
    </div>
</article>`;

let pageSize = 3;

async function browseView(context) {
    let pageParameter = context.params.page

    let currentPage = pageParameter == undefined || pageParameter <= 0 ? 1 : pageParameter;
    let offSet = (currentPage - 1) * pageSize;

    let allTeamsPromise = getAll(offSet, pageSize);
    let lastPage = Math.ceil((await getCount()) / pageSize);

    context.renderTemplate(browseTemplate(allTeamsPromise, context.isHaveUser, currentPage, lastPage));
    //where and count
}

export {
    browseView
}