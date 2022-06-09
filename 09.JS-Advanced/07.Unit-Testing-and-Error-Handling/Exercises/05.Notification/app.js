function notify(message) {

    const notificationDiv = document.querySelector('div#notification');

    notificationDiv.textContent = message;
    notificationDiv.style.display = 'block';

    notificationDiv.addEventListener('click', e => {
        notificationDiv.textContent = '';
        notificationDiv.style.display = 'none';
    });
}