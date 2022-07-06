function loadRepos() {

	let listWithRepos = document.getElementById('repos');
	let username = document.getElementById('username').value;
	let url = `https://api.github.com/users/${username}/repos`;

	fetch(url)
		.then(response => response.json())
		.then(data => {

			listWithRepos.innerHTML = '';
			data.forEach(repo => {
				createLiWithAnchorAndAppendIt(repo.full_name, repo.html_url);
			});
		})
		.catch(error => {
			listWithRepos.innerHTML = '';
			
			let li = document.createElement('li');
			li.textContent = 'Not Found!';

			listWithRepos.appendChild(li);
		});

	function createLiWithAnchorAndAppendIt(textContent, urlToRepo) {
	
		let currentLi = document.createElement('li');

		let anchor = document.createElement('a');
		anchor.textContent = textContent;
		anchor.href = urlToRepo;

		currentLi.appendChild(anchor);
		listWithRepos.appendChild(currentLi);
	}
}