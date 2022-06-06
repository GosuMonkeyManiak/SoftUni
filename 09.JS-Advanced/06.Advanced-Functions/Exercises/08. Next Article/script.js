function getArticleGenerator(articles) {
    let allArticles = articles;
    let currentArticleNumber = 0;
    let divOutputRef = document.querySelector('#content');

    function showNext() {

        if (currentArticleNumber < allArticles.length) {
            let articleElement = document.createElement('article');
            articleElement.textContent = allArticles[currentArticleNumber];

            divOutputRef.appendChild(articleElement);
            currentArticleNumber++;
        }
    }

    return showNext;
}