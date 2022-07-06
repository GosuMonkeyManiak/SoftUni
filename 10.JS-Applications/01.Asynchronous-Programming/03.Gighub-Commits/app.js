function loadCommits() {

    let githubUsername = document.getElementById('username').value;
    let githubRepoName = document.getElementById('repo').value;
    let listOfCommits = document.getElementById('commits');

    let url = `https://api.github.com/repos/${githubUsername}/${githubRepoName}/commits`;

    fetch(url)
        .then(response => {
            if (!response.ok) {
                throw Error(response.status);
            }

            return response.json();
        })
        .then(data => {

            data.forEach(wholeCommit => {
                createAndAppendLi(`${wholeCommit.commit.author.name}: ${wholeCommit.commit.message}`);    
            });
        })
        .catch(error => {
            listOfCommits.innerHTML = '';
            createAndAppendLi(`Error: ${error.message} (Not Found)`);
        });

    function createAndAppendLi(content) {

        let currentLi = document.createElement('li');
        currentLi.textContent = content;

        listOfCommits.appendChild(currentLi);
    }
}