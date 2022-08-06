import * as api from '../infrastructure/back4appApi.js';
import { assignPointer } from '../utilities.js';

const questionEndPoint = `${api.classBaseEndPoint}/Questions`;

async function getAllByQuizId(quizId) {
    let whereParameter = {};
    assignPointer(whereParameter, 'quizId', 'Quizzes', quizId);

    let quizzesResult = await api.get(questionEndPoint, {
        where: JSON.stringify(whereParameter),
        order: 'createdAt'
    });
   
    return quizzesResult.results;
}

async function getById(questionId) {
    let questionResult = await api.get(questionEndPoint, {
        where: JSON.stringify({ objectId: questionId })
    });

    return questionResult.results[0];
}

async function create(question, quizId) {
    assignPointer(question, 'quizId', 'Quizzes', quizId);

    return api.post(questionEndPoint, question);
}

async function edit(questionId, editedQuestion) {
    return api.put(questionEndPoint + `/${questionId}`, editedQuestion);
}

async function delById(questionId) {
    return api.del(questionEndPoint + `/${questionId}`);
}

export {
    create,
    getAllByQuizId,
    getById,
    edit,
    delById
}