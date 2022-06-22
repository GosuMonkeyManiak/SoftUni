function solve() {

    const recipientInput = document.getElementById('recipientName');
    const titleInput = document.getElementById('title');
    const messageInput = document.getElementById('message');

    const listOfMails = document.getElementById('list');
    const listOfSendMails = document.querySelector('.sent-list');
    const listOfDeleteMails = document.querySelector('.delete-list');

    document.getElementById('add').addEventListener('click', e => {
        e.preventDefault();

        let recipientValue = recipientInput.value;
        let titleValue = titleInput.value;
        let messageValue = messageInput.value;

        if (recipientValue == '' || titleValue == '' || messageValue == '') {
            return;
        }

        let li = document.createElement('li');

        let titleH4 = document.createElement('h4');
        titleH4.textContent = `Title: ${titleValue}`;
        li.appendChild(titleH4);

        let recipientH4 = document.createElement('h4');
        recipientH4.textContent = `Recipient Name: ${recipientValue}`;
        li.appendChild(recipientH4);

        let messageSpan = document.createElement('span');
        messageSpan.textContent = messageValue;
        li.appendChild(messageSpan);

        let divOfButtons = document.createElement('div');
        divOfButtons.id = 'list-action';

        let sendButton = document.createElement('button');
        sendButton.type = 'submit';
        sendButton.id = 'send';
        sendButton.textContent = 'Send';
        sendButton.addEventListener('click', e => {

            let deleteLi = document.createElement('li');

            let toSpan = document.createElement('span');
            toSpan.textContent = `To: ${recipientValue}`;
            deleteLi.appendChild(toSpan);

            let titleSpan = document.createElement('span');
            titleSpan.textContent = `Title: ${titleValue}`;
            deleteLi.appendChild(titleSpan);

            let divForDeleteButton = document.createElement('div');
            divForDeleteButton.className = 'btn';

            let deleteButton = document.createElement('button');
            deleteButton.type = 'submit';
            deleteButton.className = 'delete';
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', deleteMail.bind(null, deleteLi, titleValue, recipientValue));

            divForDeleteButton.appendChild(deleteButton);

            deleteLi.appendChild(divForDeleteButton);

            listOfSendMails.appendChild(deleteLi);

            li.remove();
        });
        divOfButtons.appendChild(sendButton);

        let deleteButton = document.createElement('button');
        deleteButton.type = 'submit';
        deleteButton.id = 'delete';
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteMail.bind(null, li, titleValue, recipientValue))
        divOfButtons.appendChild(deleteButton);

        li.appendChild(divOfButtons);

        listOfMails.appendChild(li);

        clearButtonsContent();
    });

    document.getElementById('reset').addEventListener('click', e => {
        e.preventDefault();

        clearButtonsContent();
    });

    function clearButtonsContent() {
        recipientInput.value = '';
        titleInput.value = '';
        messageInput.value = '';
    }

    function deleteMail(li, mailTitle, recipient) {
        li.remove();

        let liForDeleteMail = document.createElement('li');

        let toSpan = document.createElement('span');
        toSpan.textContent = `To: ${recipient}`;
        liForDeleteMail.appendChild(toSpan);

        let titleSpan = document.createElement('span');
        titleSpan.textContent = `Title: ${mailTitle}`;
        liForDeleteMail.appendChild(titleSpan);

        listOfDeleteMails.appendChild(liForDeleteMail);
    }
}

solve();