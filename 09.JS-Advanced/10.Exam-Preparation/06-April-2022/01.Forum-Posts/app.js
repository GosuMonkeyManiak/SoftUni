window.addEventListener('load', solve);

function solve() {

    let titleRef = document.getElementById('post-title');
    let categoryRef = document.getElementById('post-category');
    let content = document.getElementById('post-content');

    let ulForReview = document.getElementById('review-list');
    let ulForPusblish = document.getElementById('published-list');

    document.getElementById('publish-btn').addEventListener('click', e => {
        e.preventDefault();

        let titleValue = titleRef.value;
        let categoryValue = categoryRef.value;
        let contentValue = content.value;

        if (titleValue == '' || categoryValue == '' || contentValue == '') {
            return;
        }


        let li = document.createElement('li');
        li.className = 'rpost';

        let article = document.createElement('article');

        let h4 = document.createElement('h4');
        h4.textContent = titleValue;
        article.appendChild(h4);

        let p = document.createElement('p');
        p.textContent = `Category: ${categoryValue}`;
        article.appendChild(p);

        let secondP = document.createElement('p');
        secondP.textContent = `Content: ${contentValue}`;
        article.appendChild(secondP);

        li.appendChild(article);

        let editButton = document.createElement('button');
        editButton.textContent = 'Edit';
        editButton.classList.add('action-btn');
        editButton.classList.add('edit');
        editButton.addEventListener('click', e => {
            titleRef.value = titleValue;
            categoryRef.value = categoryValue;
            content.value = contentValue;

            li.remove();
        });
        li.appendChild(editButton);

        let approveButton = document.createElement('button');
        approveButton.textContent = 'Approve';
        approveButton.classList.add('action-btn');
        approveButton.classList.add('approve');
        approveButton.addEventListener('click', e => {
            editButton.remove();
            approveButton.remove();

            ulForPusblish.appendChild(li);
        });
        li.appendChild(approveButton);

        ulForReview.appendChild(li);

        titleRef.value = '';
        categoryRef.value = '';
        content.value = '';
    });

    document.getElementById('clear-btn').addEventListener('click', e => {
        ulForPusblish.innerHTML = '';
    });
}