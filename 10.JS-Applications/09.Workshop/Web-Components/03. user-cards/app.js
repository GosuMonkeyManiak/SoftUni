class UserCard extends HTMLElement {

    constructor() {
        super();

        this._root = this.attachShadow({ mode: 'closed' });
        this._template = document.querySelector('template');
    }

    connectedCallback() {
        let button = this._template.content.querySelector('button');
        button.addEventListener('click', this.onToggle);

        this._root.appendChild(this._template.content);
    }

    static get observedAttributes() {
        return ['username', 'avatar'];
    }

    attributeChangedCallback(name, oldValue, newValue) {
        let h3Element = this._template.content.querySelector('h3');
        let imgElement = this._template.content.querySelector('img');

        switch (name) {
            case 'username':
                this.onUsernameChange(newValue, h3Element);
                break;
            
            case 'avatar':
                this.onAvatarChange(newValue, imgElement);
                break;
        }
    }

    onUsernameChange(newValue, h3Element) {
        h3Element.textContent = newValue;
    }

    onAvatarChange(newValue, imgElement) {
        imgElement.src = newValue;
    }

    onToggle(event) {
        let button = event.target;
        let toggleDiv = event.target.parentElement.querySelector('div');

        if (button.textContent == 'Show Info') {
            button.textContent = 'Hide Info';
            toggleDiv.style.display = 'block';
        } else {
            button.textContent = 'Show Info';
            toggleDiv.style.display = 'none';
        }
    }
}

customElements.define('user-card', UserCard);