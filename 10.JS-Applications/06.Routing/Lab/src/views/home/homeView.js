import { html } from '../../../node_modules/lit-html/lit-html.js';


const homeTemplate = (recentRecipes, redirect) => html`
<section id="home">
    <div class="hero">
        <h2>Welcome to My Cookbook</h2>
    </div>
    <header class="section-title">Recently added recipes</header>
    <div class="recent-recipes">
        ${recentRecipes[0] ? recentRecipe(recentRecipes[0], redirect) : ''}
        ${spacer()}
        ${recentRecipes[1] ? recentRecipe(recentRecipes[1], redirect) : ''}
        ${spacer()}
        ${recentRecipes[2] ? recentRecipe(recentRecipes[2], redirect) : ''}
    </div>
    <footer class="section-title">
        <p>Browse all recipes in the <a href="/catalog">Catalog</a></p>
    </footer>
</section>`;

const recentRecipe = (recipe, redirect) => html`
<article class="recent" @click=${() => redirect(`/details/${recipe._id}`)}>
    <div class="recent-preview"><img src=${recipe.img}></div>
    <div class="recent-title">${recipe.name}</div>
</article>`;

const spacer = () => html`<div class="recent-space"></div>`;

export {
    homeTemplate
}