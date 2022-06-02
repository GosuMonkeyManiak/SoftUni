function extractText() {
    let ul = document.getElementById('items');
    
    let text = ul.textContent.split('\n').map(x => x.trim()).filter(x => x);
    let result = text.join('\n');

    let textArea = document.getElementById('result');
    textArea.textContent = result;
}