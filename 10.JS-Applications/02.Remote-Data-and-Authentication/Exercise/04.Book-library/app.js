document.getElementById('loadBooks').addEventListener('click', loadBooks);
document.querySelector('form').addEventListener('submit', onSubmit);

async function loadBooks() {
    let response = await fetch('http://localhost:3030/jsonstore/collections/books');
    let books = Object.values(await response.json());

    let listOfBooks = document.querySelector('table tbody');

    listOfBooks.innerHTML = '';

    books.forEach(book => {
        listOfBooks.appendChild(createBookRow(book));
    });
}

function createBookRow(book) {
    let bookRow = document.createElement('tr');

    let titleTd = document.createElement('td');
    titleTd.textContent = book.title;
    bookRow.appendChild(titleTd);

    let authorTd = document.createElement('td');
    authorTd.textContent = book.author;
    bookRow.appendChild(authorTd);

    let actionsTd = document.createElement('td');

    let editButton = document.createElement('button');
    editButton.textContent = 'Edit';
    editButton.addEventListener('click', loadBookInForm.bind(null, book));
    actionsTd.appendChild(editButton);

    let deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.dataset.id = book._id;
    deleteButton.addEventListener('click', deleteBook);
    actionsTd.appendChild(deleteButton);

    bookRow.appendChild(actionsTd);

    return bookRow;
}

async function onSubmit(event) {
    event.preventDefault();

    let submitButton = document.getElementById('submit');

    let formData = new FormData(this);

    let title = formData.get('title');
    let author = formData.get('author');

    if (title == '' || author == '') {
        alert('All field are required!');
        return;
    }

    if (submitButton.textContent == 'Submit') {
        let newBook = {
            author,
            title
        }

        await fetch('http://localhost:3030/jsonstore/collections/books', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(newBook)
        });

        loadBooks();
    } else if (submitButton.textContent == 'Save') {
        let updatedBook = {
            author,
            title
        }

        await fetch(`http://localhost:3030/jsonstore/collections/books/${submitButton.dataset.id}`, {
            method: 'put',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(updatedBook)
        });

        loadBooks();

        let form = document.querySelector('form');

        form.querySelector('h3').textContent = 'FORM';
        form.querySelector('#submit').textContent = 'Submit';
        form.querySelector('#submit').dataset.id = undefined;
    }

    document.querySelectorAll('input').forEach(input => {
        input.value = '';
    });
}

function loadBookInForm(book) {
    let form = document.querySelector('form');

    form.querySelector('h3').textContent = 'Edit FORM';
    form.querySelector('#submit').textContent = 'Save';
    form.querySelector('#submit').dataset.id = book._id;

    form.querySelector('input[name="title"]').value = book.title;
    form.querySelector('input[name="author"]').value = book.author;
}

async function deleteBook() {
    await fetch(`http://localhost:3030/jsonstore/collections/books/${this.dataset.id}`, {
        method: 'delete'
    });

    loadBooks();
}