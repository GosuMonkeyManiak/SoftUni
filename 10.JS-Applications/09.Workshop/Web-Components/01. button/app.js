class AppButton extends HTMLElement {
    #root
    #template

    constructor() {
        super();
        this.#root = this.attachShadow({ mode: 'closed' });
        this.#template = document.querySelector('#app-button').content.cloneNode(true);
    }

    connectedCallback() {
        console.log(this.isConnected);
        this.#root.appendChild(this.#template);
    }

    static get observedAttributes() {
        return ['type'];
    }

    // call before connectedCallback 
    attributeChangedCallback(name, oldValue, newValue) {
        //oldValue can be string with multiple values
        //newValue can be string with multiple values

        let button = this.#template.querySelector('button');

        if (this.isConnected) {
            button = this.#root.querySelector('button');
        }

        //accent warn
        let newValues = newValue.split(' ');
        newValues = newValues.filter(x => x != '');

        if (oldValue != null) {
            //primary aceent warn
            let oldValues = oldValue.split(' ');
            oldValues = oldValues.filter(x => x != '');
            
            button.classList.remove(oldValues[0]);
        }
        
        button.classList.add(newValues[0]);
    }
}

customElements.define('app-button', AppButton);