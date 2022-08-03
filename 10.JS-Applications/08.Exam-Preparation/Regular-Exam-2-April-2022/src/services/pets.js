import * as api from './api.js';

async function getAll() {
    return api.get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}

async function getById(petId) {
    return api.get('/data/pets/' + petId);
}

async function getDonations(petId) {
    return api.get(`/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);
}

async function getDonationsForSpecificUser(petId, userId) {
    return api.get(`/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

async function create(name, breed, age, weight, image) {
    return api.post('/data/pets', {
        name,
        breed,
        age,
        weight,
        image
    });
}

async function edit(petId, name, breed, age, weight, image) {
    return api.put('/data/pets/' + petId, {
        name,
        breed,
        age,
        weight,
        image
    });
}

async function del(petId) {
    return api.del('/data/pets/' + petId);
}

async function donate(petId) {
    return api.post('/data/donation', {
        petId
    });
}

export {
    getAll,
    getById,
    getDonations,
    getDonationsForSpecificUser,
    create,
    edit,
    del,
    donate
}