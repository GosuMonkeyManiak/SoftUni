import { getAllByQuizId } from '../services/questions.js';
import { getHydratedQuestionForm } from './createQuestionForm.js';

import { del, save } from './questionUtilities.js';
import { editView } from './editView.js';

import { html } from '../../node_modules/lit-html/lit-html.js';
import { until } from '../../node_modules/lit-html/directives/until.js';

const editorTemplate = (quizId, allQuizQuestions, addQuestionFunc, delWrapper, editView) => html`
<section id="editor">
    <header class="pad-large">
        <h2>Questions</h2>
    </header>

    <div class="pad-large alt-page">
        <div id="createdQuestions">
            ${allQuizQuestions.map((question, index) => questionTemplate(question, index, delWrapper, quizId, editView))}
        </div>
        <div id="question-form">
        </div>
        <article class="editor-question">
            <div class="editor-input">
                <button @click=${e => addQuestionFunc(e, quizId)} class="input submit action">
                    <i class="fas fa-plus-circle"></i>
                    Add question
                </button>
            </div>
        </article>
    </div>
</section>`;

const questionTemplate = (question, questionIndex, delWrapper, quizId, editView) => html`
<article class="editor-question">
    <div class="layout">
        <div class="question-control">
            <button @click=${e => editView(e, question.objectId, quizId, questionIndex + 1, e.currentTarget)} class="input submit action">
                <i class="fas fa-edit"></i> 
                Edit
            </button>
            <button @click=${(e) => delWrapper(e, question.objectId, quizId)} class="input submit action">
                <i class="fas fa-trash-alt"></i> 
                Delete
            </button>
        </div>
        <h3>Question ${questionIndex + 1}</h3>
    </div>
    <form>
        <p class="editor-input">${question.title}</p>
        ${question.answers.map((answer, index) => answerTemplate(answer, index, questionIndex))}
    </form>
</article>`;

const answerTemplate = (answer, asnwerIndex, questionIndex) => html`
<div class="editor-input">
    <label class="radio">
        <input class="input" type="radio" name="question-${questionIndex}" .value=${asnwerIndex} disabled />
        <i class="fas fa-check-circle"></i>
    </label>
    <span>${answer}</span>
</div>`;

const loadingTemplate = () => html`<div class="loading-overlay working"></div>`;

let ctx = null;
let nextQuestionNumber = null;

async function editorView(innerCtx) {
    ctx = innerCtx;
    
    let quizId = ctx.params.id;
    let allQuestions = getAllByQuizId(quizId);

    ctx.renderTemplate(until(editTemplateWrapper(ctx, quizId, allQuestions), loadingTemplate()));
}

async function editTemplateWrapper(ctx, quizId, allQuestionsInput) {
    let allQuestions = await allQuestionsInput;
    nextQuestionNumber = allQuestions.length + 1;

    ctx.renderTemplate(
        editorTemplate(quizId, allQuestions, addQuestionForm, delWrapper.bind(ctx), editView.bind(ctx)));
}

function addQuestionForm(event, quizId) {
    let questionViewDiv = event.currentTarget.parentElement.parentElement.parentElement;
    let questionFormDiv = questionViewDiv.querySelector('#question-form');

    if (questionFormDiv.children.length == 0) {
        let documentFragment = document.createDocumentFragment();

        ctx.render(getHydratedQuestionForm(saveWrapper.bind(quizId), nextQuestionNumber), documentFragment);

        questionFormDiv.appendChild(documentFragment);
    }
}

async function saveWrapper(event) {
    //this == quizId
    //save return questionObject
    let { question, questionsDiv } = await save(event, this);
    renderNewCreatedQuestion(question, questionsDiv, this);
}

function renderNewCreatedQuestion(question, parentElement, quizId) {
    let documentFragment = document.createDocumentFragment();

    ctx.render(questionTemplate(question, nextQuestionNumber - 1, delWrapper, quizId), documentFragment);
    nextQuestionNumber++;

    parentElement.appendChild(documentFragment);
}

async function delWrapper(event, questionId, quizId) {
    //this == ctx
    await del(event, questionId);
    nextQuestionNumber--;
    this.redirect(`/editor/${quizId}`);
}

export {
    editorView
}