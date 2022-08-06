import { create as createQuestion, delById } from '../services/questions.js';

async function save(event, quizId) {
    let questionFormView = event.currentTarget.parentElement.parentElement.parentElement;
    let questionForm = questionFormView.querySelector('form');

    let formData = new FormData(questionForm);

    let title = formData.get('title').trim();
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
        let answer = value.trim();

        if (answer == '') {
            alert('Answers can\'t be empty!')
            return;
        }

        question.answers.push(answer);
    }

    questionForm.reset();
    
    await createQuestion(question, quizId);

    let questionsAndFormsDiv = questionFormView.parentElement.parentElement;
    let questionsDiv = questionsAndFormsDiv.querySelector('#createdQuestions');
    questionFormView.remove();

    return {
        question,
        questionsDiv
    };
}

async function del(event, questionId) {
    event.currentTarget.disabled = true;
    await delById(questionId);
}

export {
    save,
    del
}