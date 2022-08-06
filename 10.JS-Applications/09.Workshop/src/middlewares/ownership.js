import { getById } from '../services/quizzes.js';

async function ownerShipForQuiz(ctx , next) {
    let quizId = ctx.params.id;
    let quiz = await getById(quizId);

    let userData = ctx.getUserData();

    if (quiz.ownerId.objectId == userData.id) {
        next();
    } else {
        ctx.redirect('/login');
    }
}

export {
    ownerShipForQuiz
}