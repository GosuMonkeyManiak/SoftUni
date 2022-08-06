import * as api from '../infrastructure/back4appApi.js';

const topicsEndPoint = `${api.classBaseEndPoint}/Topics`;

async function getAllTopics() {
    let responseData = await api.get(topicsEndPoint);

    return responseData.results;
}

export {
    getAllTopics
}