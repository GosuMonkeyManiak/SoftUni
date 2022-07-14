import { showPost } from "./post.js";
import { clearAllInputs } from "./utilities.js";

const homeView = document.querySelector('#homeView');
homeView.remove();

homeView.querySelector('form').addEventListener('submit', onSubmit);

function showHome() {
    document.querySelector('main').replaceChildren(homeView);
    loadTopics();
}

async function onSubmit(event) {
    event.preventDefault();

    if (event.target.textContent == 'Cancel') {
        clearAllInputs();
        return;    
    }

    let formData = new FormData(this);

    let topicTitle = formData.get('topicName');
    let username = formData.get('username');
    let topicContent = formData.get('postText');

    if (topicTitle == '' || username == '' || topicContent == '') {
        alert('All field are required!');
        return;
    }

    let topic = {
        title: topicTitle,
        username,
        createOn: Date.now()
    }

    let topicResponse = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(topic)
    });

    if (!topicResponse.ok) {
        let error = await topicResponse.json();
        alert(error.message);
        return;
    }

    let topicId = (await topicResponse.json())._id;

    let comment = {
        topicId,
        username,
        content: topicContent
    }

    let commentResponse = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(comment)
    });

    if (!commentResponse.ok) {
        let error = await commentResponse.json();
        alert(error.message);
        return;
    }

    clearAllInputs();
    loadTopics();
}

async function loadTopics() {
    let response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    let allTopics = Object.values(await response.json());

    let topciContainer = document.querySelector('.topic-title');

    topciContainer.innerHTML = '';

    allTopics.forEach(topic => {
        topciContainer.appendChild(createTopicLayout(topic));
    });
}

function createTopicLayout(topic) {
    let divTopicContainer = document.createElement('div');
    divTopicContainer.className = 'topic-container';

    divTopicContainer.innerHTML = `<div class="topic-name-wrapper">
        <div class="topic-name">
            <a data-id="${topic._id}" href="#" class="normal">
                <h2>${topic.title}</h2>
            </a>
            <div class="columns">
                <div>
                    <p>Date: <time>${new Date(topic.createOn).toLocaleString('sv')}</time></p>
                    <div class="nick-name">
                        <p>Username: <span>${topic.username}</span></p>
                    </div>
                </div>
            </div>
        </div>
    </div>`;

    divTopicContainer.querySelector('a').addEventListener('click', showPost);

    return divTopicContainer;
}

export {
    showHome
}