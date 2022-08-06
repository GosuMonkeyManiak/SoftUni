import * as api from '../services/api.js';

async function getAll() {
    return api.get('/data/offers?sortBy=_createdOn%20desc');
}

async function getById(jobOfferId) {
    return api.get('/data/offers/' + jobOfferId);
}

async function getAllApplications(jobOfferId) {
    return api.get(`/data/applications?where=offerId%3D%22${jobOfferId}%22&distinct=_ownerId&count`);
}

async function getUserApplies(jobOfferId, userId) {
    return api.get(`/data/applications?where=offerId%3D%22${jobOfferId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

async function create(title, imageUrl, category, description, requirements, salary) {
    return api.post('/data/offers', {
        title,
        imageUrl,
        category,
        description,
        requirements,
        salary
    });
}

async function edit(jobOfferId, title, imageUrl, category, description, requirements, salary) {
    return api.put('/data/offers/' + jobOfferId, {
        title,
        imageUrl,
        category,
        description,
        requirements,
        salary
    });
}

async function del(jobOfferId) {
    return api.del('/data/offers/' + jobOfferId);
}

async function apply(offerId) {
    return api.post('/data/applications', { offerId });
}

export {
    getAll,
    getById,
    getAllApplications,
    getUserApplies,
    create,
    edit,
    del,
    apply
}