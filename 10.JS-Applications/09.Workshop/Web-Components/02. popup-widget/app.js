class PopUpWidget extends HTMLElement {
    #root
    #template

    constructor() {
        super();
        this.#root = this.attachShadow({ mode: 'closed' });
        this.#template = document.querySelector('#popup-template');
    }

    static get observedAttributes() {
        return ['sourceImg', 'altImg'];
    }

    connectedCallback() {
        this.#root.appendChild(this.#template.content.cloneNode(true));
    }

    attributeChangedCallback(name, oldValue, newValue) {
        let img = this.#template.querySelector('img');

        if (this.isConnected) {
            img = this.#root.querySelector('img');
        }
        
        switch (name) {
            case 'sourceImg':
                this.onSourceChange(oldValue, newValue, img);
                break;
        
            case 'alImg':
                this.onAltChange(oldValue, newValue, img);
                break;
        }
    }

    onSourceChange(oldValue, newValue, imgElement) {
        imgElement.src = newValue;
    }

    onAltChange(oldValue, newValue, imgElement) {
        imgElement.alt = newValue;
    }
}

customElements.define('popup-widget', PopUpWidget);