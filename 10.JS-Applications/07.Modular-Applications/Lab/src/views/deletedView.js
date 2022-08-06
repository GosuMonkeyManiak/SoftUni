import { deleteRecipeById } from '../api/data.js';

import { html } from '../dom.js';

const deletedTemplate = () => html`
<section id="details">
    <article>
        <h2>Recipe deleted</h2>
    </article>
</section>`;

function deletedView(context) {
    context.renderTemplate(deletedTemplate());
}

async function onDelete(recipe, context) {
    const confirmed = confirm(`Are you sure you want to delete ${recipe.name}?`);

    if (confirmed) {
        try {
            await deleteRecipeById(recipe._id);
            context.redirect('/deleted/' + recipe._id);
        } catch (err) {
            alert(err.message);
        }
    }
}

export {
    deletedView,
    onDelete
}