function Person(firstName, lastName) {
    this._firstName = firstName;
    this._lastName = lastName;
    this._fullName = `${this._firstName} ${this._lastName}`;

    Object.defineProperty(this, 'fullName', {
        enumerable: true,
        configurable: true,
        get() {
            return this._fullName;
        },
        set(value) {
            let fullNameParts = value.trim().split(' ');

            if (fullNameParts.length == 2) {
                this.firstName = fullNameParts[0];
                this.lastName = fullNameParts[1];
                this._fullName = value;
            }
        }
    });

    Object.defineProperty(this, 'firstName', {
        enumerable: true,
        configurable: true,
        get() {
            return this._firstName;
        },
        set(value) {
            let fullnameparts = this._fullName.split(' ');

            this._fullName = `${value} ${fullnameparts[1]}`;
            this._firstName = value;
        }
    });

    Object.defineProperty(this, 'lastName', {
        enumerable: true,
        configurable: true,
        get() {
            return this._lastName;
        },
        set(value) {
            let fullnameparts = this._fullName.split(' ');

            this._fullName = `${fullnameparts[0]} ${value}`;
            this._lastName = value;
        }
    });
}

let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov

person.firstName = "George";
console.log(person.fullName); //George Ivanov

person.lastName = "Peterson";
console.log(person.fullName); //George Peterson

person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla