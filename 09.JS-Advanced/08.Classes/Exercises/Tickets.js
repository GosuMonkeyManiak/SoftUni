function tickets(arrayOfTickets, sortingCriterion) {

    class Ticket {

        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status
        }
    }

    const tickets = [];

    for (const ticket of arrayOfTickets) {
        
        let ticketParts = ticket.split('|');

        let destination = ticketParts[0];
        let price = ticketParts[1];
        let status = ticketParts[2];

        tickets.push(new Ticket(destination, price, status));
    }

    if (sortingCriterion == 'destination' || sortingCriterion == 'status') {

        tickets.sort((a, b) => a[sortingCriterion].localeCompare(b[sortingCriterion]));
    } else {
        tickets.sort((a, b) => a[sortingCriterion] - b[sortingCriterion]);
    }

    return tickets;
}

console.log(tickets(['Philadelphia|94.20|available',
 'New York City|95.99|available',
 'New York City|95.99|sold',
 'Boston|126.20|departed'],
'price'));