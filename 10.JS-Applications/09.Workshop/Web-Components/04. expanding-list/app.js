class CustomExpandingList extends HTMLUListElement {
    #root

    constructor() {
        super();
        this.addEventListener('click', this.onClick);
    }

    onClick(event) {
        let clickedElement = event.target;

        if (clickedElement.tagName == 'LI') {
            
            if (clickedElement.classList.contains('open')) {
                clickedElement.classList.remove('open');
                clickedElement.classList.add('closed');

                for (const child of clickedElement.children) {
                    child.style.display = 'none';
                }
            } else if (clickedElement.classList.contains('closed')) {
                clickedElement.classList.remove('closed');
                clickedElement.classList.add('open');

                for (const child of clickedElement.children) {
                    child.style.display = 'block';
                }
            }
        }
    }
}

customElements.define('expanding-list', CustomExpandingList, { extends: 'ul' });