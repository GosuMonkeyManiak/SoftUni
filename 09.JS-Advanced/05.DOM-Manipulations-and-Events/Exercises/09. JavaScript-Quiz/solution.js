function solve() {

    let allQuestionSections = Array.from(document.querySelectorAll('section'));
    let question = 0;
    let score = 0;

    Array.from(document.querySelectorAll('.answer-wrap'))
        .forEach(x => {
            x.addEventListener('click', e => {
                let answer = Array.from(x.children).find(p => p.tagName == 'P').textContent;

                if (answer == 'onclick') {
                    score++;
                } else if (answer == 'JSON.stringify()') {
                    score++;
                } else if (answer == 'A programming API for HTML and XML documents') {
                    score++;
                }

                allQuestionSections[question].classList.add('hidden')
                allQuestionSections[question].style.display = 'none';

                if (question == 2) {
                    let ulOutput = document.getElementById('results');
                    ulOutput.style.display = 'block';

                    let outputRef = document.querySelector('ul li h1');

                    if (score == 3) {
                        outputRef.textContent = 'You are recognized as top JavaScript fan!';
                    } else {
                        outputRef.textContent = `You have ${score} right answers`;
                    }

                    return;
                }

                question++;
                allQuestionSections[question].classList.remove('hidden')
                allQuestionSections[question].style.display = 'block';;
            });
        });
}
