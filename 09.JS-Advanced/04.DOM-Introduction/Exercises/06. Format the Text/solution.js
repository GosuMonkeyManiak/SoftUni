function solve() {
    let textAreaRef = document.getElementById('input');
    let divOutPutRef = document.getElementById('output');

    let sentences = textAreaRef.value.split('.').map(x => x.trim()).filter(x => x);

    let open = true;

    let currentParagraph = '<p>';

    for (let i = 1; i <= sentences.length; i++) {

        if (!open) {
            currentParagraph = '<p>';
            open = true;
        }

        currentParagraph += sentences[i - 1] + '.';

        if (i % 3 == 0) {
            open = false;
            divOutPutRef.innerHTML += currentParagraph;
            currentParagraph = '</p>';
        }
    }

    if (open && currentParagraph.trim().length > 3) {
        currentParagraph += '</p>';
        divOutPutRef.innerHTML += currentParagraph;
    }
}