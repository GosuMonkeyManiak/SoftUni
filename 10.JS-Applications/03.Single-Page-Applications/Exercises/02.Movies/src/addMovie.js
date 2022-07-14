import { showView, addFormHandler, clearAllInputs } from './utilities.js';
import { post } from './api.js';
import { showHome } from './home.js';

const addMovieView = document.querySelector('#container #add-movie');
addMovieView.remove();

addFormHandler(addMovieView, '#add-movie-form', addMovie)

function showAddMovie() {
    showView(addMovieView);
}

async function addMovie(formData) {
    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('img');

    if (title == '' || description == '' || img == '') {
        alert('All field are required!');
        return;
    }

    let newMovie = {
        title,
        description,
        img
    };

    try {
        await post('/data/movies', newMovie);
    } catch (error) {
        alert(error.message);
        return;
    }

    clearAllInputs();
    showHome();
}

export {
    showAddMovie
}