import { getRecent } from '../api/data.js';

import { html } from '../dom.js';

const homeTemplate = (recentRecipes) => html`
<section id="home">
    <div class="hero">
        <h2>Welcome to My Cookbook</h2>
    </div>
    <header class="section-title">Recently added recipes</header>
    <div class="recent-recipes">
        ${recentRecipes[0] ? recentRecipe(recentRecipes[0]) : ''}
        ${spacer()}
        ${recentRecipes[1] ? recentRecipe(recentRecipes[1]) : ''}
        ${spacer()}
        ${recentRecipes[2] ? recentRecipe(recentRecipes[2]) : ''}
    </div>
    <footer class="section-title">
        <p>Browse all recipes in the <a href="/catalog">Catalog</a></p>
    </footer>
</section>`;

const recentRecipe = (recipe) => html`
<a class="card" href=${`/details/${recipe._id}`} >
    <article class="recent">
        <div class="recent-preview"><img src=${'/' + recipe.img}></div>
        <div class="recent-title">${recipe.name}</div>
    </article>
</a>`;

const spacer = () => html`<div class="recent-space"></div>`;

async function homeView(context) {
    const recipes = await getRecent();

    context.renderTemplate(homeTemplate(recipes));
}

export {
    homeView
}