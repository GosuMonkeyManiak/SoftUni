function encodeAndDecodeMessages() {
    let allDivsInMain = document.querySelectorAll('main div');

    let senderDiv = allDivsInMain[0];
    let receiverDiv = allDivsInMain[1];

    let senderTextAreaRef = Array.from(senderDiv.children)
        .find(e => e.tagName == 'TEXTAREA');

    let receiverTextAreaRef = Array.from(receiverDiv.children)
        .find(e => e.tagName == 'TEXTAREA');

    Array.from(senderDiv.children)
        .find(e => e.tagName == 'BUTTON')
        .addEventListener('click', e => {
            let message = senderTextAreaRef.value;
            let result = '';

            for (let i = 0; i < message.length; i++) {
                result += String.fromCharCode(message.charCodeAt(i) + 1);
            }

            senderTextAreaRef.value = '';
            receiverTextAreaRef.value = result;
        });

    Array.from(receiverDiv.children)
        .find(e => e.tagName == 'BUTTON')
        .addEventListener('click', e => {
            let message = receiverTextAreaRef.value;
            let result = '';

            for (let i = 0; i < message.length; i++) {
                result += String.fromCharCode(message.charCodeAt(i) - 1);
            }

            receiverTextAreaRef.value = result;
        })
}