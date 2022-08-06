import { html } from '../../node_modules/lit-html/lit-html.js';

const profileTemplate = () => html`
<section id="profile">
    <header class="pad-large">
        <h1>Profile Page</h1>
    </header>

    <div class="hero pad-large">
        <article class="glass pad-large profile">
            <h2>Profile Details</h2>
            <p>
                <span class="profile-info">Username:</span>
                Peter
            </p>
            <p>
                <span class="profile-info">Email:</span>
                peter@mail.cx
            </p>
            <h2>Your Quiz Results</h2>
            <table class="quiz-results">
                <tbody>
                    <tr class="results-row">
                        <td class="cell-1">23. March 2021</td>
                        <td class="cell-2"><a href="#">RISC Architecture</a></td>
                        <td class="cell-3 s-correct">85%</td>
                        <td class="cell-4 s-correct">12/15 correct answers</td>
                    </tr>
                </tbody>
            </table>
        </article>
    </div>

    <header class="pad-large">
        <h2>Quizes created by you</h2>
    </header>

    <div class="pad-large alt-page">

        <article class="preview layout">
            <div class="right-col">
                <a class="action cta" href="#">View Quiz</a>
                <a class="action cta" href="#"><i class="fas fa-edit"></i></a>
                <a class="action cta" href="#"><i class="fas fa-trash-alt"></i></a>
            </div>
            <div class="left-col">
                <h3><a class="quiz-title-link" href="#">Extensible Markup Language</a></h3>
                <span class="quiz-topic">Topic: Languages</span>
                <div class="quiz-meta">
                    <span>15 questions</span>
                    <span>|</span>
                    <span>Taken 54 times</span>
                </div>
            </div>
        </article>

        
    </div>
</section>`;

const quizTemplate = (quiz) => html`
<article class="preview layout">
    <div class="right-col">
        <a class="action cta" href="">View Quiz</a>
        <a class="action cta" href="/editor/${quiz.objectId}">
            <i class="fas fa-edit"></i>
        </a>
        <a class="action cta" href="#">
            <i class="fas fa-trash-alt"></i>
        </a>
    </div>
    <div class="left-col">
        <h3><a class="quiz-title-link" href="#">${quiz.title}</a></h3>
        <span class="quiz-topic">Topic: Hardware</span>
        <div class="quiz-meta">
            <span>10 questions</span>
            <span>|</span>
            <span>Taken 107 times</span>
        </div>
    </div>
</article>`;

function profileView(ctx) {
    ctx.renderTemplate(profileTemplate());
}

export {
    profileView
}