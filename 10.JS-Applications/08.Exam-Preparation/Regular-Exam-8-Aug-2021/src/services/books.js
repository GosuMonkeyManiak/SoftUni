import * as api from './api.js';

async function getAll() {
    return api.get('/data/books?sortBy=_createdOn%20desc');
}

async function getById(bookId) {
    return api.get('/data/books/' + bookId);
}

async function getAllLikes(bookId) {
    return api.get(`/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
}

async function getAllLikeByUser(bookId, userId) {
    return api.get(`/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

async function getAllByUser(userId) {
    return api.get(`/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

async function add(title, description, imageUrl, type) {
    return api.post('/data/books', {
        title,
        description,
        imageUrl,
        type
    });
}

async function edit(bookId, title, description, imageUrl, type) {
    return api.put('/data/books/' + bookId, {
        title,
        description,
        imageUrl,
        type
    });
}

async function del(bookId) {
    return api.del('/data/books/' + bookId);
}

async function like(bookId) {
    return api.post('/data/likes', {
        bookId
    }); 
}

export {
    getAll,
    getById,
    getAllLikes,
    getAllLikeByUser,
    getAllByUser,
    add,
    edit,
    del,
    like
}