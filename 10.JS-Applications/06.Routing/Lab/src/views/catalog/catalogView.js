import { html } from '../../../node_modules/lit-html/lit-html.js';

const catalogTemplate = (recipes, redirect, page, pages) => html`
<section id="catalog">
    <header class="section-title">${pager(page, pages)}</header>
    ${recipes.map(r => recipePreview(r, redirect))}
    <footer class="section-title">${pager(page, pages)}</footer>
</section>`;

const recipePreview = (recipe, redirect) => html`
<article class="preview" @click=${() => redirect(`/details/${recipe._id}`)}>
    <div class="title">
        <h2>${recipe.name}</h2>
    </div>
    <div class="small"><img src="/${recipe.img}"></div>
</article>`;

const pager = (page, pages) => html`
Page ${page} of ${pages}
${page > 1 ? html`<a class="pager" href="/catalog/${page - 1}" >&lt; Prev</a>` : ''}
${page < pages ? html`<a class="pager" href="/catalog/${page + 1}" >Next &gt;</a>` : ''}`;

export {
    catalogTemplate
}