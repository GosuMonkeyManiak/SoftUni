import { html, render } from '../node_modules/lit-html/lit-html.js';

document.querySelector('#loadBooks').addEventListener('click', loadBooks);

const addForm = document.querySelector('#add-form');
const editForm = document.querySelector('#edit-form');

editForm.style.display = 'none';

addForm.addEventListener('submit', addBook);
editForm.addEventListener('submit', editBook);

async function loadBooks() {
    let response = await fetch('http://localhost:3030/jsonstore/collections/books');
    let books = await response.json();

    let bookTemplate = (book, bookId) => html`<tr>
        <td>${book.title}</td>
        <td>${book.author}</td>
        <td>
            <button @click=${loadBookInEditForm.bind(null, bookId)}>Edit</button>
            <button>Delete</button>
        </td>
    </tr>`;

    let hydratedBooks = [];

    for (const bookId in books) {
        hydratedBooks.push(bookTemplate(books[bookId], bookId));
    }

    render(hydratedBooks, document.querySelector('body table tbody'));
}

async function loadBookInEditForm(bookId) {
    addForm.style.display = 'none';
    editForm.style.display = 'block';

    let response = await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`);
    let book = await response.json();

    editForm.querySelector('input[name="title"]').value = book.title;
    editForm.querySelector('input[name="author"]').value = book.author;
    editForm.querySelector('input[name="id"]').value = bookId;
}

async function editBook(event) {
    event.preventDefault();

    let formData = new FormData(event.currentTarget);

    let bookId = formData.get('id');
    let bookTitle = formData.get('title');
    let bookAuthor = formData.get('author');

    if (bookTitle == '' || bookAuthor == '') {
        alert('All field are required!');
        return;
    }

    let editedBook = {
        author: bookAuthor,
        title: bookTitle
    };

    try {
        let response = await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(editedBook)
        });

        if (!response.ok) {
            throw new Error('Something went wrong!');
        }
    } catch (error) {
        alert(error.message);
        return;
    }

    editForm.querySelector('input[name="title"]').value = '';
    editForm.querySelector('input[name="author"]').value = '';
    editForm.querySelector('input[name="id"]').value = '';

    addForm.style.display = 'block';
    editForm.style.display = 'none';
}

async function addBook(event) {
    event.preventDefault();

    let formData = new FormData(event.currentTarget);

    let bookTitle = formData.get('title');
    let bookAuthor = formData.get('author');

    if (bookTitle == '' || bookAuthor == '') {
        alert('All field are required!');
        return;
    }

    let newBook = {
        author: bookAuthor,
        title: bookTitle
    }

    try {
        let response = await fetch('http://localhost:3030/jsonstore/collections/books', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newBook)
        });

        if (!response.ok) {
            throw new Error('Something went wrong!');
        }
    } catch (error) {
        alert(error.message);
        return;
    }

    addForm.querySelector('input[name="title"]').value = '';
    addForm.querySelector('input[name="author"]').value = '';
}