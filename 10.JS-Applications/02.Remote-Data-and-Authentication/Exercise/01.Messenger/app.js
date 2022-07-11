function attachEvents() {
    document.getElementById('refresh').addEventListener('click', refresh);
    document.getElementById('submit').addEventListener('click', addNewMessage);
}

async function refresh() {
    let response = await fetch('http://localhost:3030/jsonstore/messenger');
    let messages = Object.values(await response.json());

    console.log(messages);

    let allMessagesRef = document.getElementById('messages');

    allMessagesRef.textContent = '';

    messages.forEach(message => {
        allMessagesRef.textContent += `${message.author}: ${message.content}\n`;
    });
}

async function addNewMessage() {
    let author = document.querySelector('input[name="author"]');
    let message = document.querySelector('input[name="content"]');

    if (author.value == '' || message.value == '') {
        alert('Author and Message are required!');
        return;
    }

    let data = {
        author: author.value,
        content: message.value
    }

    await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    });

    author.value = '';
    message.value = '';

    await refresh();
}

attachEvents();