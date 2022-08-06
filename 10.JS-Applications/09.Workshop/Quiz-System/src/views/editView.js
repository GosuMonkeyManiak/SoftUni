import { getById, edit as editQuestion } from '../services/questions.js';
import { getHydratedQuestionForm } from './createQuestionForm.js';

let ctx = null;
let quizId = null;

async function editView(event, questionId, innerQuizId, questionNumber, currentTarget) {
    ctx = this;
    quizId = innerQuizId;
    let containerElement = document.querySelector('#question-form');

    if (containerElement.children.length != 0) {
        return;
    }

    //this == ctx
    //load into edit question form
    event.currentTarget.disabled = true;

    let question = await getById(questionId);
    let editForm = getHydratedQuestionForm(edit.bind(ctx), questionNumber, question);

    //remove click question
    currentTarget.parentElement.parentElement.parentElement.remove();

    ctx.render(editForm, containerElement);
}

async function edit(event) {
    //this == ctx
    let questionFormView = event.currentTarget.parentElement.parentElement.parentElement;
    let questionForm = questionFormView.querySelector('form');

    let formData = new FormData(questionForm);

    let questionId = formData.get('id');
    let title = formData.get('title');
    let correctAnswer = formData.get(formData.get('correctAnswer'));

    if (title == '') {
        alert('Title is required!');
        return;
    }

    if (correctAnswer == null) {
        alert('Choose correct asnwer!');
        return;
    }

    formData.delete('title');
    formData.delete('correctAnswer');
    formData.delete('id');

    if ([...formData.entries()].length < 3) {
        alert('Question must have at least 3 asnwers!');
        return;
    }

    let question = {
        title,
        answers: [],
        correctAnswer
    };

    for (const [key, value] of formData.entries()) {
        question.answers.push(value);
    }

    questionForm.reset();

    await editQuestion(questionId, question);

    questionFormView.remove();

    this.redirect(`/editor/${quizId}`);
}

export {
    editView
}