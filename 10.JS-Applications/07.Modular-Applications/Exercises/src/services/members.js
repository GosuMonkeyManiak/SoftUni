import * as api from './api.js';

const endPoints = {
    COUNT_BY_TEAM_ID: (teamId) => `/data/members?where=status%3D%22member%22%20AND%20teamId%3D%22${teamId}%22&count`
}

async function getCountByTeamId(teamId) {
    return api.get(endPoints.COUNT_BY_TEAM_ID(teamId));
}

export {
    getCountByTeamId
}