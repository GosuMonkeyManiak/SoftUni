import { html, render } from '../node_modules/lit-html/lit-html.js';

window.addEventListener('load', loadStudents);
document.querySelector('#searchBtn').addEventListener('click', searchForStudent)

async function loadStudents() {
    let response = await fetch('http://localhost:3030/jsonstore/advanced/table');
    let students = Object.values(await response.json());

    let studentRowTemplate = (student) => html`<tr>
        <td>${student.firstName + ' ' + student.lastName}</td>
        <td>${student.email}</td>
        <td>${student.course}</td>
    </tr>`;

    students = students.map(studentRowTemplate);

    render(students, document.querySelector('table tbody'));
}

function searchForStudent() {
    let input = document.querySelector('#searchField');
    let searchString = input.value;

    if (searchString == '') {
        return;
    }

    let allStudentTds = document.querySelectorAll('tbody td');

    allStudentTds.forEach(td => {
        td.parentElement.classList.remove('select');
    });

    allStudentTds = Array.from(allStudentTds).filter(x => x.textContent.toLocaleLowerCase().includes(searchString.toLocaleLowerCase()));

    allStudentTds.forEach(td => {
        td.parentElement.classList.add('select');
    });

    input.value = '';
}