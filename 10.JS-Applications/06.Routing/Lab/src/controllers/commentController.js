import { getCommentsByRecipeId, createComment } from '../api/data.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { commentsTemplate, commentFormTemplate } from '../views/comment/commentView.js';

let context = null;

function showComments(recipe, innerContext) {
    context = innerContext;

    return hydratedTemplate(recipe);
}

function hydratedTemplate(recipe) {
    let formActive = false;
    
    let commentsPromise = getCommentsByRecipeId(recipe._id);

    let initialSubmitFunction = createIntialSubmitFunction(create);
    let commentForm = createForm(formActive, toggleForm, initialSubmitFunction);

    let hydratedTemplate = commentsTemplate(recipe, commentForm, commentsPromise);

    return hydratedTemplate;

    function toggleForm(event) {
        if (event != undefined) {
            event.preventDefault();   
        }
        
        let divComments = document.querySelector('div#comments');
        let documentFragment = document.createDocumentFragment();

        formActive = !formActive;

        commentsPromise = getCommentsByRecipeId(recipe._id);
        commentForm = createForm(formActive, toggleForm, initialSubmitFunction);
        hydratedTemplate = commentsTemplate(recipe, commentForm, commentsPromise);

        context.render(hydratedTemplate, documentFragment);

        divComments.replaceChildren(documentFragment);
    }

    async function create(data) {
        const comment = {
            content: data.content,
            recipeId: recipe._id
        };

        await createComment(comment);
        toggleForm();
    }
}

function createForm(formActive, toggleForm, createFunction) {
    const userId = sessionStorage.getItem('userId');
    if (userId == null) {
        return '';
    } else {
        return commentFormTemplate(formActive, toggleForm, createFunction);
    }
}

export {
    showComments
}