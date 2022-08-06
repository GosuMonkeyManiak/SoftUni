import * as api from './api.js';

const endPoints = {
    ALL_BY_PAGINATION: (offSet, pageSize) => `/data/teams?offset=${offSet}&pageSize=${pageSize}`,
    ALL_COUNT: '/data/teams?count'
};

async function getAll(offset, pageSize) {
    return api.get(endPoints.ALL_BY_PAGINATION(offset, pageSize));
}

async function getCount() {
    return api.get(endPoints.ALL_COUNT);
}

export {
    getAll,
    getCount
}