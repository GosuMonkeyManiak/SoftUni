import * as api from './api.js';

async function getAllPosts() {
    return api.get('/data/posts?sortBy=_createdOn%20desc');
}

async function getPostById(id) {
    return api.get('/data/posts/' + id);
}

async function getUserPostsById(userId) {
    return api.get(`/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

async function getTotalDonationsForPostById(postId) {
    return api.get(`/data/donations?where=postId%3D%22${postId}%22&distinct=_ownerId&count`);
}

async function getTotalUserDonationsForPostById(postId, userId) {
    return api.get(`/data/donations?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}

async function createPost(title, description, imageUrl, address, phone) {
    return api.post('/data/posts', {
        title,
        description,
        imageUrl,
        address,
        phone
    });
}

async function editPost(id, title, description, imageUrl, address, phone) {
    return api.put('/data/posts/' + id, {
        title,
        description,
        imageUrl,
        address,
        phone
    });
}

async function deletePost(id) {
    return api.del('/data/posts/' + id);
}

async function donate(postId) {
    return api.post('/data/donations', {
        postId
    });
}

export {
    getAllPosts,
    getPostById,
    getUserPostsById,
    getTotalDonationsForPostById,
    getTotalUserDonationsForPostById,
    createPost,
    editPost,
    deletePost,
    donate
}