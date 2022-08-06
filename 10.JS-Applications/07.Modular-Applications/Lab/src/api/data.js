import * as api from './api.js';

const endpoints = {
    RECIPE_LIST: '/data/recipes?select=' + encodeURIComponent('_id,name,img'),
    RECIPE_COUNT: '/data/recipes?count',
    RECENT_RECIPES: '/data/recipes?select=' + encodeURIComponent('_id,name,img') + '&sortBy=' + encodeURIComponent('_createdOn desc'),
    RECIPES: '/data/recipes',
    RECIPE_BY_ID: '/data/recipes/',
    COMMENTS: '/data/comments',
    COMMENT_BY_ID: '/data/comments/',
    COMMENTS_BY_RECIPE_ID: '/data/comments?where=' + encodeURIComponent('recipeId='),
};

async function getRecipes(page = 1, search) {
    let url = endpoints.RECIPE_LIST + `&offset=${(page - 1) * 5}&pageSize=5`;
    if (search) {
        url += '&where=' + encodeURIComponent(`name like "${search}"`);
    }
    return await api.get(url);
}

async function getRecipeCount(search) {
    let url = endpoints.RECIPE_COUNT;
    if (search) {
        url += '&where=' + encodeURIComponent(`name like "${search}"`);
    }
    return await api.get(url);
}

async function getRecent() {
    return await api.get(endpoints.RECENT_RECIPES);
}

async function getRecipeById(id) {
    return await api.get(endpoints.RECIPE_BY_ID + id);
}

async function createRecipe(recipe) {
    return await api.post(endpoints.RECIPES, recipe);
}

async function editRecipe(id, recipe) {
    return await api.put(endpoints.RECIPE_BY_ID + id, recipe);
}

async function deleteRecipeById(id) {
    return await api.del(endpoints.RECIPE_BY_ID + id);
}

async function getCommentsByRecipeId(recipeId) {
    return await api.get(endpoints.COMMENTS_BY_RECIPE_ID + encodeURIComponent(`"${recipeId}"`) + '&load=' + encodeURIComponent('author=_ownerId:users'));
}

async function createComment(comment) {
    const result = await api.post(endpoints.COMMENTS, comment);
    return await api.get(endpoints.COMMENT_BY_ID + result._id + '?load=' + encodeURIComponent('author=_ownerId:users'));
}

async function deleteCommentById(commentId) {
    return await api.del(endpoints.COMMENTS + `/${commentId}`);
}

export {
    getRecipes,
    getRecipeCount,
    getRecent,
    getRecipeById,
    createRecipe,
    editRecipe,
    deleteRecipeById,
    getCommentsByRecipeId,
    createComment,
    deleteCommentById
}