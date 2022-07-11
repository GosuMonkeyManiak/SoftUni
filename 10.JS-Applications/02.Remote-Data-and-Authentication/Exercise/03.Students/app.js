window.addEventListener('load', loadStudents);

async function loadStudents() {
    let response = await fetch('http://localhost:3030/jsonstore/collections/students');
    let students = Object.values(await response.json());

    let tableOfStudenst = document.querySelector('#results tbody');
    
    tableOfStudenst.innerHTML = '';

    students.forEach(student => {
        tableOfStudenst.appendChild(createStudentRow(student));
    });
}

function createStudentRow(student) {
    let studentRow = document.createElement('tr');

    let firstNameTd = document.createElement('td');
    firstNameTd.textContent = student.firstName;
    studentRow.appendChild(firstNameTd);

    let lastNameTd = document.createElement('td');
    lastNameTd.textContent = student.lastName;
    studentRow.appendChild(lastNameTd);

    let facultyNumberTd = document.createElement('td');
    facultyNumberTd.textContent = student.facultyNumber;
    studentRow.appendChild(facultyNumberTd);

    let gradeTd = document.createElement('td');
    gradeTd.textContent = Number(student.grade).toFixed(2);
    studentRow.appendChild(gradeTd);

    return studentRow;
}

document.getElementById('form').addEventListener('submit', async e => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let firstName = formData.get('firstName');
    let lastName = formData.get('lastName');
    let facultyNumber = formData.get('facultyNumber');
    let grade = formData.get('grade');

    if (firstName == '' || lastName == '' || 
        facultyNumber == '' || grade == '') {
        alert('All field are required!');
        return;
    }

    if (isNaN(grade)) {
        alert('Grade must be a number!');
        return;
    }

    let newStudent = {
        firstName,
        lastName,
        facultyNumber,
        grade
    };

    await fetch('http://localhost:3030/jsonstore/collections/students', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newStudent)
    });

    loadStudents();

    document.querySelectorAll('input').forEach(input => {
        input.value = '';
    });
});