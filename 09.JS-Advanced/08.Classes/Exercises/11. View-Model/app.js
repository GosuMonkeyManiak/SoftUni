class Textbox {

    constructor(selector, regex) {
        this._value = '';
        this._invalidSymbols = regex;

        this._populateElements(selector);
        this._addChangeEventForAllInputElements();
    }

    _populateElements(selector) {
        this._elements = document.querySelectorAll(selector);
    }

    _addChangeEventForAllInputElements() {

        Array.from(this._elements).forEach(el => {
            el.addEventListener('change', e => {
                this.value = e.target.value;
            });
        })
    }

    get value() {
        return this._value;
    }

    set value(value) {
        this._value = value;

        Array.from(this._elements).forEach(e => e.value = value);
    }

    get elements() {
        return this._elements;
    }

    isValid() {

        let results = Array.from(this._elements)
            .map(x => {

                if (this._invalidSymbols.test(x.value)) {
                    return false;
                }

                return true;
            });

        return !results.includes(false);
    }
}

let textbox = new Textbox(".textbox",/[^a-zA-Z0-9]/);
let inputs = document.getElementsByClassName('.textbox');

//inputs.addEventListener('click',function(){console.log(textbox.value);});
