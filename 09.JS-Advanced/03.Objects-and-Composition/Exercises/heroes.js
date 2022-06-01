function solve() {

    let state = {
        name: '',
        health: 100
    };

    let creater = {
        mage(name) {
            let mage = Object.assign({}, state);
            mage.name = name;
            mage.mana = 100;
            mage.cast = (spell) => {
                if (mage.mana > 0) {
                    mage.mana--;
                    console.log(`${mage.name} cast ${spell}`);
                }
            }

            return mage;
        },
        fighter(name) {
            let fighter = Object.assign({}, state);
            fighter.name = name;
            fighter.stamina = 100;
            fighter.fight = () => {
                if (fighter.stamina > 0) {
                    fighter.stamina--;
                    console.log(`${fighter.name} slashes at the foe!`);
                }
            };

            return fighter;
        }
    }

    return creater;
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")

const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()

console.log(scorcher2.stamina);
console.log(scorcher.mana);
