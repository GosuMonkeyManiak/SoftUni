window.addEventListener('load', load);

async function load() {
    let response = await fetch('http://localhost:3030/jsonstore/cookbook/recipes');
    let data = await response.json();

    let mainElementRef = document.querySelector('main');

    for (const recipeKey of Object.keys(data)) {

        let recipeTitle = data[recipeKey].name;
        let recipeImage = data[recipeKey].img;

        let currentArticle = createRecipeArticle(recipeKey, recipeTitle, recipeImage);

        currentArticle.addEventListener('click', loadFullRecipe);

        mainElementRef.appendChild(currentArticle);
    }
}

function createRecipeArticle(recipeId, recipeTitle, imgSrc) {
    let article = document.createElement('article');
    article.className = 'preview';
    article.dataset.recipeId = recipeId;

    let divTitle = document.createElement('div');
    divTitle.className = 'title';

    let h2Title = document.createElement('h2');
    h2Title.textContent = recipeTitle;

    divTitle.appendChild(h2Title);

    article.appendChild(divTitle);

    let divPicture = document.createElement('div');
    divPicture.className = 'small';

    let image = document.createElement('img');
    image.src = imgSrc;

    divPicture.appendChild(image);

    article.appendChild(divPicture);

    return article;
}

async function loadFullRecipe(e) {
    let currentArticle = e.currentTarget;
    let recipeId = currentArticle.dataset.recipeId;
    let urlToFullRecipe = `http://localhost:3030/jsonstore/cookbook/details/${recipeId}`;

    let response = await fetch(urlToFullRecipe);
    let data = await response.json();

    changeRecipeArticleToFull(currentArticle, data);
}

function changeRecipeArticleToFull(article, recipe) {

    if (!article.classList.contains('preview')) {
        let newArticle = createRecipeArticle(recipe._id, recipe.name, recipe.img);
        newArticle.addEventListener('click', loadFullRecipe);
        article.parentElement.replaceChild(newArticle, article);
        return;
    }

    article.className = '';
    article.innerHTML = '';

    let h2Title = document.createElement('h2');
    h2Title.textContent = recipe.name;
    article.appendChild(h2Title);

    let divWrapper = document.createElement('div');
    divWrapper.className = 'band';

    let divImage = document.createElement('div');
    divImage.className = 'thumb';

    let image = document.createElement('img');
    image.src = recipe.img;

    divImage.appendChild(image);
    divWrapper.appendChild(divImage);

    let divIngredients = document.createElement('div');
    divIngredients.className = 'ingredients';

    let h3Ingredients = document.createElement('h3');
    h3Ingredients.textContent = 'Ingredients:';
    divIngredients.appendChild(h3Ingredients);

    let ulIngredients = document.createElement('ul');

    for (const ingredient of recipe.ingredients) {

        let liIngredient = document.createElement('li');
        liIngredient.textContent = ingredient;
        ulIngredients.appendChild(liIngredient);
    }

    divIngredients.appendChild(ulIngredients);
    divWrapper.appendChild(divIngredients);
    article.appendChild(divWrapper);

    let divDescription = document.createElement('div');
    divDescription.className = 'description';

    let h3Description = document.createElement('h3');
    h3Description.textContent = 'Preparation:';
    divDescription.appendChild(h3Description);

    for (const step of recipe.steps) {

        let pStep = document.createElement('p');
        pStep.textContent = step;
        divDescription.appendChild(pStep);
    }

    article.appendChild(divDescription);
}