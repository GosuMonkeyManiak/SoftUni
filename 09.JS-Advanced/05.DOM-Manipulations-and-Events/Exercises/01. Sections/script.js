function create(words) {
    let content = document.getElementById('content');

    words.forEach(x => {
        let div = document.createElement('div');
        let paragraph = document.createElement('p');
        paragraph.textContent = x;
        paragraph.style.display = 'none';
        div.appendChild(paragraph);

        div.addEventListener('click', e => {
            e.currentTarget.children[0].style.display = 'inline';
        });

        content.appendChild(div);
    });
}