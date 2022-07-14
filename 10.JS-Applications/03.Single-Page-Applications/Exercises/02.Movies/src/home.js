import { showAddMovie } from './addMovie.js';
import { get } from './api.js';
import { showMovieDetails } from './movieDetails.js';
import { showView, showCorrectNavBar, changeDisplayOfElements  } from './utilities.js';

const homeView = document.querySelector('#container #home-page');
homeView.remove();

homeView.querySelector('#add-movie-button a').addEventListener('click', showAddMovie);

function showHome() {
    showView(homeView);
    showCorrectNavBar();
    displaySettingForAddMovieButton();
    loadMovies();
}

function displaySettingForAddMovieButton() {
    if (sessionStorage.getItem('userData') != null) {
        changeDisplayOfElements('#home-page #add-movie-button', 'block');
    } else {
        changeDisplayOfElements('#home-page #add-movie-button', 'none');
    }
}

async function loadMovies() {
    let movies;

    try {
        movies = Object.values(await get('/data/movies'));
    } catch (error) {
        alert(error.message);
        return;
    }

    let movieList = document.querySelector('#movies-list');
    movieList.innerHTML = '';

    movies.forEach(movie => {
        movieList.appendChild(createMovieLayout(movie));
    });
}

function createMovieLayout(movie) {
    let movieLi = document.createElement('li');
    movieLi.className = 'card';

    let img = document.createElement('img');
    img.className = 'card-img-top';
    img.src = movie.img;
    movieLi.appendChild(img);

    let p = document.createElement('p');
    p.textContent = movie.title;
    movieLi.appendChild(p);

    let detailButton = document.createElement('button');
    detailButton.className = 'btn btn-info';
    detailButton.textContent = 'Details';
    detailButton.dataset.id = movie._id;
    detailButton.addEventListener('click', showMovieDetails.bind(null, movie._id));
    movieLi.appendChild(detailButton);

    return movieLi;
}

export {
    showHome
}