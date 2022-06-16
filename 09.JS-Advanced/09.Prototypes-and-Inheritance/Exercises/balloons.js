function ballons() {

    class Balloon {

        constructor(color, weight) {
            this.color = color;
            this.hasWeight = Number(weight);
        }
    }

    class PartyBalloon extends Balloon {

        constructor(color, weight, ribbonColor, ribbonLength) {
            super(color, weight);

            this._ribbon = {
                color: ribbonColor,
                length: ribbonLength
            };
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {

        constructor(color, weight, ribbonColor, ribbonLength, text) {
            super(color, weight, ribbonColor, ribbonLength);

            this._text = text;
        }

        get text() {
            return this._text;
        }
    }

    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    };
}

let classes = ballons();
let testBalloon = new classes.Balloon("yellow", 20.5);
let testPartyBalloon = new classes.PartyBalloon("yellow", 20.5, "red", 10.25);
let ribbon = testPartyBalloon.ribbon;
console.log(testBalloon);
console.log(testPartyBalloon);
console.log(ribbon);
