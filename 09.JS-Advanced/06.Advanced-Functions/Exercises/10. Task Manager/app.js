function solve() {
    let taskNameInputRef = document.getElementById('task');
    let taskDescTextAreaRef = document.getElementById('description');
    let taskDateInputRef = document.getElementById('date');

    let allSections = document.querySelectorAll('section');

    let openSectionRef = allSections[1];
    let progressSectionRef = allSections[2];
    let finishSectionRef = allSections[3];

    document.getElementById('add').addEventListener('click', e => {
        e.preventDefault();

        if (taskNameInputRef.value != '' && 
            taskDescTextAreaRef.value != '' && 
            taskDateInputRef.value != '') {

            let article = document.createElement('article');

            let h3 = document.createElement('h3');
            h3.textContent = taskNameInputRef.value;
            article.appendChild(h3);

            let descParagraph = document.createElement('p');
            descParagraph.textContent = `Description: ${taskDescTextAreaRef.value}`;
            article.appendChild(descParagraph);

            let dueParagraph = document.createElement('p');
            dueParagraph.textContent = `Due Date: ${taskDateInputRef.value}`;
            article.appendChild(dueParagraph);

            let div = document.createElement('div');
            div.classList.add('flex');

            let startButton = document.createElement('button');
            startButton.classList.add('green');
            startButton.textContent = 'Start';
            startButton.addEventListener('click', moveToProgress);
            div.appendChild(startButton);

            let deleteButton = document.createElement('button');
            deleteButton.classList.add('red');
            deleteButton.textContent = 'Delete';
            deleteButton.addEventListener('click', deleteTask);
            div.appendChild(deleteButton);

            article.appendChild(div);

            openSectionRef.children[1].appendChild(article);
        }
    });

    function deleteTask(e) {
        this.parentElement.parentElement.remove();
    }

    function moveToProgress(e) {
        let divRef = this.parentElement;

        Array.from(this.parentElement.children).forEach(x => x.remove());

        let deleteButton = document.createElement('button');
        deleteButton.classList.add('red');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteTask);
        divRef.appendChild(deleteButton);

        let finishButton = document.createElement('button');
        finishButton.classList.add('orange');
        finishButton.textContent = 'Finish';
        finishButton.addEventListener('click', finishTask);
        divRef.appendChild(finishButton);

        progressSectionRef.children[1].appendChild(divRef.parentElement);
    }

    function finishTask(e) {
        let articleRef = this.parentElement.parentElement;

        this.parentElement.remove();

        finishSectionRef.children[1].appendChild(articleRef);
    }
}