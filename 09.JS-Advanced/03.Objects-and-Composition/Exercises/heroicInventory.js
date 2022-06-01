function heroicInventory(heroes) {

    let allParsedHeroes = [];

    for (let i = 0; i < heroes.length; i++) {

        let currentHero = {};

        let heroParts = heroes[i].split(' / ');

        currentHero.name = heroParts[0];
        currentHero.level = Number(heroParts[1]);
        currentHero.items = [];

        if (heroParts.length > 2) {
            let heroItems = heroParts[2].split(', ').map(x => x.trim());
            heroItems.map(i => currentHero.items.push(i));
        }

        allParsedHeroes.push(currentHero);
    }

    console.log(JSON.stringify(allParsedHeroes));
}

heroicInventory(
    ['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);