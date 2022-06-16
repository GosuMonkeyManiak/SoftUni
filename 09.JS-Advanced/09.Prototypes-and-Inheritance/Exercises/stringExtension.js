(function solve() {
    String.prototype.ensureStart = function(str) {

        if (!this.startsWith(str)) {
            return `${str}${this}`;
        }

        return `${this}`;
    };

    String.prototype.ensureEnd = function(str) {
      
        if (!this.endsWith(str)) {
            return `${this}${str}`;
        }

        return `${this}`;
    };

    String.prototype.isEmpty = function() {
        return this.length == 0;
    };

    String.prototype.truncate = function(n) {

        if (this.length < n) {
            return `${this}`;
        }

        if (n < 4) {
            let period = '.';
            return `${period.repeat(n)}`;
        }

        if (this.includes(' ')) {

            let leftSpaceIndex = 0;

            while (true) {
                let currentSpaceIndex = this.indexOf(' ', leftSpaceIndex + 1);

                if (currentSpaceIndex == -1) {
                    break;
                }

                if (currentSpaceIndex >= leftSpaceIndex && leftSpaceIndex <= n - 1) {
                    leftSpaceIndex = currentSpaceIndex;
                }
            }

            let rightSpaceIndex = this.indexOf(' ', leftSpaceIndex + 1) == -1 ? this.length - 1 : this.indexOf(' ', leftSpaceIndex + 1);

            let result = '';

            for (let i = 0; i < leftSpaceIndex; i++) {
                result += this[i];
            }

            for (let i = this.length - 1; i > rightSpaceIndex; i--) {
                result += this[i];
            }

            result += '...';

            return result;

        } else {
            let result = '';

            for (let i = 0; i < n - 3; i++) {
                result += this[i];
            }

            result += '...';

            return result;
        }
    };

    String.format = function(string, ...params) {

        let result = string;

        for (let i = 0; i < params.length; i++) {

            let stringToSearch = `{${i}}`;

            if (result.includes(stringToSearch)) {
                result = result.replace(stringToSearch, params[i]);
            }
            
        }

        return result;
    };

})();

let str = 'my string';

str = str.ensureStart('my');
console.log(str);

str = str.ensureStart('hello ');
console.log(str);

str = str.truncate(16);
console.log(str);

str = str.truncate(14);
console.log(str);

str = str.truncate(8);
console.log(str);

str = str.truncate(4);
console.log(str);

str = str.truncate(2);
console.log(str);

str = String.format('The {0} {1} fox','quick', 'brown');
console.log(str);

str = String.format('jumps {0} {1}','dog');
console.log(str);