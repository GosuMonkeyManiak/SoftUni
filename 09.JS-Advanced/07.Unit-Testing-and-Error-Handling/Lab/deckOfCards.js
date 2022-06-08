function printDeckOfCards(cards) {

    cards = cards.map(card => {
        return {
            face: card.slice(0, card.length - 1),
            suit: card[card.length - 1]
        }
    });

    let deck = [];

    for (let i = 0; i < cards.length; i++) {
        
        try {
            let currentCard = createCard(cards[i].face, cards[i].suit);
            deck.push(currentCard);
        } catch (error) {
            console.log(`Invalid card: ${cards[i].face}${cards[i].suit}`);
            return;
        }
    }

    console.log(deck.join(' '));

    function createCard(face, suit) {

        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A',];
        const suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663'
        }

        if (!faces.includes(face) || !Object.keys(suits).includes(suit)) {
            throw new Error('Error');
        }
        
        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit;
            }
        }
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '5X']);
