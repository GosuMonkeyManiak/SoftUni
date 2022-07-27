import * as api from './api.js';

const paths = {
    ALL_FURNITURES: '/data/catalog',
    FURNITURE_BY_ID: '/data/catalog',
    CREATE_FURNITURE: '/data/catalog',
    DELETE_FURNITURE: '/data/catalog'
}

async function getAllFurnitures() {
    return api.get(paths.ALL_FURNITURES);
}

async function getFurnitureById(id) {
    return api.get(paths.FURNITURE_BY_ID + `/${id}`);
}

async function getUserFurnituresById(userId) {
    return api.get(paths.ALL_FURNITURES + `?where=_ownerId%3D%22${userId}%22`);
}

async function createFurniture(furniture) {
    return api.post(paths.CREATE_FURNITURE, furniture);
}

async function updateFurnitureById(furnitureId, furniture) {
    return api.put(paths.ALL_FURNITURES + `/${furnitureId}`, furniture);
}

async function deleteFurnitureById(id) {
    return api.del(paths.DELETE_FURNITURE + `/${id}`);
}

export {
    getAllFurnitures,
    getFurnitureById,
    createFurniture,
    deleteFurnitureById,
    getUserFurnituresById,
    updateFurnitureById
}