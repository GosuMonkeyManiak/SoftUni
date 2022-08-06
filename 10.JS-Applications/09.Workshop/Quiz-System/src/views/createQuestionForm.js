import { html, nothing, render } from '../../node_modules/lit-html/lit-html.js';

const questionFormTemplate = (addAnswer, cancelFunc, saveFunc, questionNumber, question) => html`
<article class="editor-question">
    <div class="layout">
        <div class="question-control">
            <button @click=${saveFunc} class="input submit action">
                <i class="fas fa-check-double"></i>
                Save
            </button>

            <button @click=${cancelFunc} class="input submit action">
                <i class="fas fa-times"></i> 
                Cancel
            </button>
        </div>
        <h3>Question ${questionNumber}</h3>
    </div>
    <form>
        ${question != undefined ? html`<input type="hidden" name="id" .value=${question.objectId} />` : nothing}
        <textarea class="input editor-input editor-text" name="title" placeholder="Enter question">${question != undefined ? question.title : nothing}</textarea>
        <div id="form-answers">
            ${question != undefined 
                ? question.answers.map(answer => answerInputTemplate(removeAnswer, answersCount++, answer))
                : nothing}
        </div>
        <div class="editor-input">
            <button @click=${addAnswer} class="input submit action">
                <i class="fas fa-plus-circle"></i>
                Add answer
            </button>
        </div>
    </form>
</article>`;

const answerInputTemplate = (removeFunc, answerNumber, answer) => html`
<div class="editor-input">
    <label class="radio">
        <input class="input" type="radio" name="correctAnswer" value="answer-${answerNumber}" />
        <i class="fas fa-check-circle"></i>
    </label>

    <input class="input" type="text" name="answer-${answerNumber}" .value=${answer != undefined ? answer : nothing} />

    <button @click=${removeFunc} class="input submit action">
        <i class="fas fa-trash-alt"></i>
    </button>
</div>`;

let answersCount = 0;

function getHydratedQuestionForm(saveFunc, questionNumber, question) {
    return questionFormTemplate(addAnswer, cancelForm, saveFunc, questionNumber, question);
}

function addAnswer(event) {
    event.preventDefault();

    let documentFragmnet = document.createDocumentFragment();
    render(answerInputTemplate(removeAnswer, answersCount), documentFragmnet);

    answersCount++;

    let form = event.currentTarget.parentElement.parentElement;
    let divOfInputs = form.querySelector('#form-answers');

    divOfInputs.appendChild(documentFragmnet);
}

function removeAnswer(event) {
    event.preventDefault();
    event.currentTarget.parentElement.remove();
}

function cancelForm(event) {
    event.currentTarget.parentElement.parentElement.parentElement.remove();
}

export {
    getHydratedQuestionForm
}