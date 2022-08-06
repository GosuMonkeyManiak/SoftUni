import * as api from '../infrastructure/back4appApi.js';
import { getUserData, assignPointer } from '../utilities.js';

const quizzesEndPoint = `${api.classBaseEndPoint}/Quizzes`;

async function getById(quizId) {
    let quizResult = await api.get(quizzesEndPoint, {
        where: JSON.stringify({ objectId: quizId })
    });

    return quizResult.results[0];
}

async function createQuiz(title, topicId) {
    let userData = getUserData();

    let newQuiz = {
        title
    };
    assignPointer(newQuiz, 'topicId', 'Topics', topicId);
    assignPointer(newQuiz, 'ownerId', '_User', userData.id);

    return api.post(quizzesEndPoint, newQuiz);
}

export {
    createQuiz,
    getById
}