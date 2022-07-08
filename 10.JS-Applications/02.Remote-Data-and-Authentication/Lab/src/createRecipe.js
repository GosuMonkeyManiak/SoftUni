document.querySelector('form').addEventListener('submit', createRecipe);

async function createRecipe(event) {
    event.preventDefault();

    if (sessionStorage.getItem('authToken') == undefined) {
        location.href = 'login.html';
        return;
    }

    let formData = new FormData(this);

    try {

        let data = {
            name: formData.get('name'),
            img: formData.get('img'),
            ingredients: formData.get('ingredients').split('\n'),
            steps: formData.get('steps').split('\n')
        };

        let reponse = await fetch('http://localhost:3030/data/recipes', {
            method: 'post',
            headers: { 'X-Authorization': sessionStorage.getItem('authToken'), 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })

        if (reponse.status != 200) {
            throw new Error('Something went wrong!');
        }

        location.href = 'index.html';
    } catch (error) {
        alert(error.message);
    }
}