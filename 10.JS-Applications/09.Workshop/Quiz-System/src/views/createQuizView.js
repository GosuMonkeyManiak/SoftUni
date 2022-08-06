import { getAllTopics } from '../services/topics.js';
import { createQuiz as apiCreateQuiz } from '../services/quizzes.js';
import { createIntialSubmitFunction } from '../utilities.js';

import { html } from '../../node_modules/lit-html/lit-html.js';

const createTemplate = (allTopics, createQuizFunc) => html`
<section id="editor">
    <header class="pad-large">
        <h1>New quiz</h1>
    </header>

    <div class="pad-large alt-page">
        <form @submit=${createQuizFunc} >
            <label class="editor-label layout">
                <span class="label-col">Title:</span>
                <input class="input i-med" type="text" name="title">
            </label>

            <label class="editor-label layout">
                <span class="label-col">Topic:</span>
                <select class="input i-med" name="topicId">
                    ${allTopics.map(topicTemplate)}
                </select>
            </label>

            <input class="input submit action" type="submit" value="Save">
        </form>
    </div>
</section>`

const topicTemplate = (topic) => html`<option .value=${topic.objectId} >${topic.name}</option>`;

const intialSubmitCreateQuizFunc = createIntialSubmitFunction(createQuiz);

let ctx = null;

async function createQuizView(innerCtx) {
    ctx = innerCtx;

    let allTopics = await getAllTopics();

    ctx.renderTemplate(createTemplate(allTopics, intialSubmitCreateQuizFunc));
}

async function createQuiz({ title, topicId }) {
    if (title == '' || topicId == '') {
        alert('All field are required!');
        return;
    }

    let quizId = (await apiCreateQuiz(title, topicId)).objectId;

    this.reset();

    ctx.redirect(`/editor/${quizId}`);
}

export {
    createQuizView
}