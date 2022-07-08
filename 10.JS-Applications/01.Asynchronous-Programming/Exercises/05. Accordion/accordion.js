window.addEventListener('load', solution);

async function solution() {
    let url = `http://localhost:3030/jsonstore/advanced/articles/list`;

    let response = await fetch(url);
    let data = await response.json();

    let mainSectionRef = document.getElementById('main');

    data.forEach(article => {
        mainSectionRef.appendChild(createArticle(article));
    });

    function createArticle(article) {
        let divAccordion = document.createElement('div');
        divAccordion.className = 'accordion';

        let divHead = document.createElement('div');
        divHead.className = 'head';

        let summarySpan = document.createElement('span');
        summarySpan.textContent = article.title;
        divHead.appendChild(summarySpan);

        let moreButton = document.createElement('button');
        moreButton.className = 'button';
        moreButton.id = article._id;
        moreButton.textContent = 'More';
        divHead.appendChild(moreButton);

        divAccordion.appendChild(divHead);

        let divMoreInfo = document.createElement('div');
        divMoreInfo.className = 'extra';
        divMoreInfo.style.display = 'none';

        let contentParagraph = document.createElement('p');
        divMoreInfo.appendChild(contentParagraph);

        divAccordion.appendChild(divMoreInfo);
        
        moreButton.addEventListener('click', loadMoreInfo.bind(moreButton, contentParagraph, divMoreInfo));

        return divAccordion;
    }

    async function loadMoreInfo(contentParagraph, divMoreInfo) {
        
        if (this.textContent == 'More') {

            if (contentParagraph.textContent == '') {
                let url = `http://localhost:3030/jsonstore/advanced/articles/details/${this.id}`;

                let response = await fetch(url);
                let data = await response.json();

                contentParagraph.textContent = data.content;
            }

            this.textContent = 'Hide';
            divMoreInfo.style.display = 'block';
        } else {
            this.textContent = 'More';
            divMoreInfo.style.display = 'none';
        }
    }
}