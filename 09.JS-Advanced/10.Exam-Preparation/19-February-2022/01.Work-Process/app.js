function solve() {

    const firtsNameInput = document.getElementById('fname');
    const lastNameInput = document.getElementById('lname');
    const emailInput = document.getElementById('email');
    const birthdayInput = document.getElementById('birth');
    const positionInput = document.getElementById('position');
    const salaryInput = document.getElementById('salary');

    const employeesTable = document.getElementById('tbody');
    const budget = document.getElementById('sum');

    document.getElementById('add-worker').addEventListener('click', e => {
        e.preventDefault();

        let firstname = firtsNameInput.value;
        let lastname = lastNameInput.value;
        let email = emailInput.value;
        let birthday = birthdayInput.value;
        let position = positionInput.value;
        let salary = salaryInput.value;

        if (firstname == '' || lastname == '' || email == '' || birthday == '' || position == '' || salary == '') {
            return;
        }

        let tableRow = document.createElement('tr');
        
        let tdForFName = document.createElement('td');
        tdForFName.textContent = firstname;
        tableRow.appendChild(tdForFName);

        let tdForLName = document.createElement('td');
        tdForLName.textContent = lastname;
        tableRow.appendChild(tdForLName);

        let tdForEmail = document.createElement('td');
        tdForEmail.textContent = email;
        tableRow.appendChild(tdForEmail);

        let tdForBirthday = document.createElement('td');
        tdForBirthday.textContent = birthday;
        tableRow.appendChild(tdForBirthday);

        let tdForPosition = document.createElement('td');
        tdForPosition.textContent = position;
        tableRow.appendChild(tdForPosition);

        let tdForSalary = document.createElement('td');
        tdForSalary.textContent = Number(salary).toFixed(2);
        tableRow.appendChild(tdForSalary);

        let tdForActions = document.createElement('td');

        let firedButton = document.createElement('button');
        firedButton.className = 'fired';
        firedButton.textContent = 'Fired';
        firedButton.addEventListener('click', e => {
            tableRow.remove();

            budget.textContent = (Number(budget.textContent) - Number(salary)).toFixed(2);
        });

        let editButton = document.createElement('button');
        editButton.className = 'edit';
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', 
            edit.bind(null, tableRow, firstname, lastname, email, birthday, position, salary));

        tdForActions.appendChild(firedButton);
        tdForActions.appendChild(editButton);

        tableRow.appendChild(tdForActions);

        employeesTable.appendChild(tableRow);

        budget.textContent = (Number(budget.textContent) + Number(salary)).toFixed(2);

        firtsNameInput.value = '';
        lastNameInput.value = '';
        emailInput.value = '';
        birthdayInput.value = '';
        positionInput.value = '';
        salaryInput.value = '';
    });

    function edit(tableRow, firstName, lastName, email, birthDay, position, salary) {
        tableRow.remove();

        firtsNameInput.value = firstName;
        lastNameInput.value = lastName;
        emailInput.value = email;
        birthdayInput.value = birthDay;
        positionInput.value = position;
        salaryInput.value = salary;

        budget.textContent = (Number(budget.textContent) - Number(salary)).toFixed(2);
    }
}

solve();