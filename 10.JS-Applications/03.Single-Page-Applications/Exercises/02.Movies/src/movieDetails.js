import { del, get } from './api.js';
import { showEditMovie } from './editMovie.js';
import { showHome } from './home.js';
import { showView } from './utilities.js';

const movieDetailsView = document.querySelector('#container #movie-example');
movieDetailsView.remove();

async function showMovieDetails(movieId) {
    let movieDetails;

    try {
        movieDetails = await get(`/data/movies/${movieId}`)
    } catch (error) {
        alert(error.message);
        return;
    }

    replaceMovieInfoInView(movieDetails);
    showView(movieDetailsView);
}

function replaceMovieInfoInView(movie) {
    movieDetailsView.querySelector('h1').textContent = movie.title;
    movieDetailsView.querySelector('img').src = movie.img;
    movieDetailsView.querySelector('p').textContent = movie.description;

    movieDetailsView.querySelectorAll('a').forEach(a => {
        a.dataset.id = movie._id;
    });

    let userSession = JSON.parse(sessionStorage.getItem('userData'));

    let deleteButton = movieDetailsView.querySelector('a.btn-danger');
    let editButton = movieDetailsView.querySelector('a.btn-warning');

    if (userSession != null && userSession.id == movie._ownerId) {
        deleteButton.style.display = '';
        deleteButton.addEventListener('click', deleteMovie);

        editButton.style.display = '';
        editButton.addEventListener('click', showEditMovie);
    } else {
        deleteButton.style.display = 'none';
        editButton.style.display = 'none';
    }
}

async function deleteMovie(event) {
    event.preventDefault();
    let movieId = event.currentTarget.dataset.id;

    try {
        await del(`/data/movies/${movieId}`);
    } catch (error) {
        alert(error.message);
        return;
    }

    showHome();
}

export {
    showMovieDetails
}