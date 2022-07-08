async function lockedProfile() {
    let url = `http://localhost:3030/jsonstore/advanced/profiles`;

    let response = await fetch(url);
    let users = await response.json();

    let main = document.getElementById('main');

    for (const userId of Object.keys(users)) {
        main.appendChild(createProfile(users[userId]));
    }

    function createProfile(user) {
        let divProfile = document.createElement('div');
        divProfile.className = 'profile';
        
        let image = document.createElement('img');
        image.className = 'userIcon';
        image.src = './iconProfile2.png';
        divProfile.appendChild(image);

        let lockLabel = document.createElement('label');
        lockLabel.textContent = 'Lock';
        divProfile.appendChild(lockLabel);

        let lockRadioInput = document.createElement('input');
        lockRadioInput.name = user.username;
        lockRadioInput.type = 'radio';
        lockRadioInput.value = 'lock';
        lockRadioInput.setAttribute('checked', '');
        divProfile.appendChild(lockRadioInput);

        let unlockLabel = document.createElement('label');
        unlockLabel.textContent = 'Unlock';
        divProfile.appendChild(unlockLabel);

        let unlockRadioInput = document.createElement('input');
        unlockRadioInput.name = user.username;
        unlockRadioInput.type = 'radio';
        unlockRadioInput.value = 'unlock';
        divProfile.appendChild(unlockRadioInput);

        divProfile.appendChild(document.createElement('br'));
        divProfile.appendChild(document.createElement('hr'));

        let userNameLabel = document.createElement('label');
        userNameLabel.textContent = 'Username';
        divProfile.appendChild(userNameLabel);

        let userNameInput = document.createElement('input');
        userNameInput.type = 'text';
        userNameInput.value = user.username;
        userNameInput.disabled = true;
        userNameInput.readOnly = true;
        divProfile.appendChild(userNameInput);

        let divHiddenInfo = document.createElement('div');
        divHiddenInfo.className = 'user1Username';
        divHiddenInfo.style.display = 'none';

        divHiddenInfo.appendChild(document.createElement('hr'));

        let emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';
        divHiddenInfo.appendChild(emailLabel);

        let emailInput = document.createElement('input');
        emailInput.type = 'email';
        emailInput.value = user.email;
        emailInput.disabled = true;
        emailInput.readOnly = true;
        divHiddenInfo.appendChild(emailInput);

        let ageLabel = document.createElement('label');
        ageLabel.textContent = 'Age:';
        divHiddenInfo.appendChild(ageLabel);

        let ageInput = document.createElement('input');
        ageInput.type = 'text';
        ageInput.value = user.age;
        ageInput.disabled = true;
        ageInput.readOnly = true;
        divHiddenInfo.appendChild(ageInput);

        divProfile.appendChild(divHiddenInfo);

        let showMoreButton = document.createElement('button');
        showMoreButton.textContent = 'Show more';
        showMoreButton.addEventListener('click', showMoreInfo.bind(null, unlockRadioInput, showMoreButton, divHiddenInfo));
        divProfile.appendChild(showMoreButton);

        return divProfile;
    }

    function showMoreInfo(unlockInputRef, showMoreButtonRef, moreInfoSection) {
        if (unlockInputRef.checked) {
            if (showMoreButtonRef.textContent == 'Show more') {
                moreInfoSection.style.display = 'block';
                showMoreButtonRef.textContent = 'Hide it';
            } else {
                moreInfoSection.style.display = 'none';
                showMoreButtonRef.textContent = 'Show more';
            }
        }
    }
}