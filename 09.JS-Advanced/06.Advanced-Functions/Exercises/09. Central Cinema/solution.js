function solve() {

    let allInputs = document.querySelectorAll('#container input');
    let nameMovieInput = allInputs[0];
    let hallMovieInput = allInputs[1];
    let ticketPriceInput = allInputs[2];

    let movieList = document.querySelector('#movies ul');
    let archiveList = document.querySelector('#archive ul');

    document.querySelector('#add-new').addEventListener('click', e => {
        e.preventDefault();

        if (e.target.tagName == 'BUTTON' &&
            nameMovieInput.value != '' && 
            hallMovieInput.value != '' &&
            ticketPriceInput.value != '' &&
            isNum(Number(ticketPriceInput.value))) {
            
            let movieLi = document.createElement('li');

            let span = document.createElement('span');
            span.textContent = nameMovieInput.value;
            movieLi.appendChild(span);

            let strong = document.createElement('strong');
            strong.textContent = `Hall: ${hallMovieInput.value}`;
            movieLi.appendChild(strong);

            let div = document.createElement('div');

            let divStrong = document.createElement('strong');
            divStrong.textContent = Number(ticketPriceInput.value).toFixed(2);
            div.appendChild(divStrong);

            let input = document.createElement('input');
            input.placeholder = 'Tickets Sold';
            div.appendChild(input);

            let archiveButton = document.createElement('button');
            archiveButton.textContent = 'Archive';
            archiveButton.addEventListener('click', archive);
            div.appendChild(archiveButton);

            movieLi.appendChild(div);

            movieList.appendChild(movieLi);

            nameMovieInput.value = '';
            hallMovieInput.value = '';
            ticketPriceInput.value = '';
        }
    });

    function archive(e) {

        let divChildren = Array.from(this.parentElement.children);

        let inputForTicketCount = divChildren.find(x => x.tagName == 'INPUT');
        let ticketPrice = divChildren.find(x => x.tagName == 'STRONG');

        if (inputForTicketCount.value != '' && isNum(Number(inputForTicketCount.value))) {
            
            let priceForAllTickets = Number(inputForTicketCount.value) * Number(ticketPrice.textContent);

            let movieLi = inputForTicketCount.parentElement.parentElement;
            inputForTicketCount.parentElement.remove();

            Array.from(movieLi.children).find(x => x.tagName == 'STRONG').textContent = `Total amount: ${priceForAllTickets.toFixed(2)}`;

            let deleteButton = document.createElement('button');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', deleteArchiveMovie);
            movieLi.appendChild(deleteButton);

            archiveList.appendChild(movieLi);
        }
    }

    function deleteArchiveMovie(e) {
        this.parentElement.remove();
    }

    document.querySelector('#archive button').addEventListener('click', e => {

        let ul = Array.from(e.currentTarget.parentElement.children).find(x => x.tagName == 'UL');

        Array.from(ul.children).forEach(e => ul.removeChild(e));
    });

    function isNum(val){
        return !isNaN(val)
    }
}