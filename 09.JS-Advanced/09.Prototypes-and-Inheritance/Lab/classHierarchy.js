function classHierarchy() {

    class Figure {

        constructor() {
            this.units = 'cm';
        }

        get area() {

        }

        changeUnits(unit) {

            if (unit == 'm' || unit == 'cm' || unit == 'mm') {
                this.units = unit;
            }
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure {

        constructor(raidus) {
            super();
            this.raidus = raidus;
        }

        get area() {
            let result = Math.PI * this.raidus * this.raidus;

            if (this.units == 'mm') {
                return result * 100;
            } else if (this.units == 'm') {
                return result / 10000;
            }

            return result;
        }

        toString() {
            let base = super.toString();
            let finalRadius = this.raidus;

            if (this.units == 'mm') {
                finalRadius *= 10;
            } else if (this.units == 'm'){
                finalRadius /= 100;
            }

            base += ` Area: ${this.area} - radius: ${finalRadius}`;
            return base;
        }
    }

    class Rectangle extends Figure {

        constructor(width, height, unit) {
            super();
            this.width = width;
            this.height = height;
            super.changeUnits(unit);
        }

        get area() {
            let result = this.width * this.height;

            if (this.units == 'mm') {
                return result * 100;
            } else if (this.units == 'm') {
                return result / 10000;
            }

            return result;
        }

        toString() {
            let base = super.toString();
            let finalWidth = this.width;
            let finalHeight = this.height;

            if (this.units == 'mm') {
                finalWidth *= 10;
                finalHeight *= 10;
            } else if (this.units == 'm'){
                finalWidth /= 100;
                finalHeight /= 100;
            }
            
            base += ` Area: ${this.area} - width: ${finalWidth}, height: ${finalHeight}`;
            return base;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    };
}


let {Figure, Circle, Rectangle} = classHierarchy();

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
