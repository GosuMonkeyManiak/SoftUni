import { getRecipeCommnetsById } from '../api/data.js';

import { html } from '../../../node_modules/lit-html/lit-html.js';

let commentsTitleTemplate = (recipe) => html`<div class="section-title">
        Comments for ${recipe.name}
    </div>`;

let commnetsTemplate = (recipeCommnets) => html`<div class="comments">
        <ul>
            <li class="comment">
                <header>${data.author.email}</header>
                <p>${data.content}</p>
            </li>
        </ul>
    </div>`;

async function showCommnets(recipe) {
    const recipeCommnetsWithAuthors = await getRecipeCommnetsWithAuthors(recipe._id);

    let commnets = [];
    commnets.push(commentsTitleTemplate(recipe));

}

async function getRecipeCommnetsWithAuthors(recipeId) {
    let recipeCommnets = await getRecipeCommnetsById(recipeId);

    let commentsWithAuthor = [
        {
            content: '',
            author: {

            }
        }
    ];

    for (let i = 0; i < recipeCommnets.length; i++) {
        
        let commnetWithAuthor = {
            content: recipeCommnets[i].content
        };

        commentsWithAuthor.push(commnetWithAuthor);
    }
}

export {
    showCommnets
}