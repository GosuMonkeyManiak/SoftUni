class Contact {

    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;

        this.isOnline = false;

        this.createElement();
    }

    set online(value) {
        this.isOnline = value;

        this.addOrRemoveOnlineToDivElement(value);
    }

    addOrRemoveOnlineToDivElement(value) {

        let divElement = Array.from(this.element.children)[0];

        if (value) {
            divElement.classList.add('online');
        } else {
             divElement.classList.remove('online');
        }
    }

    createElement() {
        this.element = document.createElement('article');

        let summaryInfoDiv = document.createElement('div');
        summaryInfoDiv.classList.add('title');
        summaryInfoDiv.textContent = `${this.firstName} ${this.lastName}`;

        let infoButton = document.createElement('button');
        infoButton.textContent = `\u2139`;
        summaryInfoDiv.appendChild(infoButton);

        this.element.appendChild(summaryInfoDiv);

        let personalInformationDiv = document.createElement('div');
        personalInformationDiv.classList.add('info');
        personalInformationDiv.style.display = 'none';

        let phoneSpan = document.createElement('span');
        phoneSpan.textContent = `\u260E ${this.phone}`;
        personalInformationDiv.appendChild(phoneSpan);

        let emailSpan = document.createElement('span');
        emailSpan.textContent = `\u2709 ${this.email}`;
        personalInformationDiv.appendChild(emailSpan);
        
        infoButton.addEventListener('click', e => {

            if (personalInformationDiv.style.display == 'none') {
                personalInformationDiv.style.display = 'block';
            } else {
                personalInformationDiv.style.display = 'none';
            }
        });

        this.element.appendChild(personalInformationDiv);
    }

    render(elementId) {
        let parent = document.getElementById(elementId);
        parent.appendChild(this.element);
    }
}

let contacts = [
  new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
  new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
  new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));

// After 1 second, change the online status to true
setTimeout(() => contacts[1].online = true, 2000);
