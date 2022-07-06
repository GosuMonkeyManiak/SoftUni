function loadRepos() {

    let httpRequest = new XMLHttpRequest();

    httpRequest.addEventListener('readystatechange', e => {
       
        if (httpRequest.readyState == 4 && httpRequest.status == 200) {
            document.getElementById('res').textContent = httpRequest.responseText;
        }
    });

    httpRequest.open('GET', 'https://api.github.com/users/testnakov/repos');
    httpRequest.send();
}