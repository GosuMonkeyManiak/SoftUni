import { get, put } from './api.js';
import { showMovieDetails } from './movieDetails.js';
import { showView, addFormHandler } from './utilities.js';

const editMovieView = document.querySelector('#container #edit-movie');
editMovieView.remove();

addFormHandler(editMovieView, 'form', update);

async function showEditMovie(event) {
    event.preventDefault();
    let movieId = event.currentTarget.dataset.id;

    let movie;

    try {
        movie = await get(`/data/movies/${movieId}`);
    } catch (error) {
        alert(error.message);
        return;
    }

    populateField(movie);
    showView(editMovieView);
}

function populateField(movie) {
    editMovieView.querySelector('input[name="title"]').value = movie.title;
    editMovieView.querySelector('textarea').value = movie.description;
    editMovieView.querySelector('input[name="img"]').value = movie.img;
    editMovieView.querySelector('button').dataset.id = movie._id;
}

async function update(formData) {
    let title = formData.get('title');
    let description = formData.get('description');
    let img = formData.get('img');

    let movieId = editMovieView.querySelector('button').dataset.id;

    if (title == '' || description == '' || img == '') {
        alert('All field are required!');
        return;
    }

    let updateMovie = {
        title,
        description,
        img
    }

    try {
        await put(`/data/movies/${movieId}`, updateMovie);
    } catch (error) {
        alert(error.message);
        return;
    }

    showMovieDetails(movieId);
}

export {
    showEditMovie
}