function extensibleObject() {
    
    return {
        extend(template) {

            for (const key in template) {

                if (typeof template[key] == 'function') {
                    let prototype = Object.getPrototypeOf(this);

                    Object.defineProperty(prototype, key, {
                        enumerable: true,
                        configurable: true,
                        writable: true,
                        value: template[key]
                    });

                } else {
                    Object.defineProperty(this, key, {
                        enumerable: true,
                        configurable: true,
                        writable: true,
                        value: template[key]
                    });
                }
            }
        }
    }
} 

const myObj = extensibleObject();

console.log(myObj);

const template = { 
  extensionMethod: function () {}, 
  extensionProperty: 'someString' 
}

myObj.extend(template); 

console.log(myObj);
console.log(Object.getPrototypeOf(myObj));