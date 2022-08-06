import { html } from '../../node_modules/lit-html/lit-html.js';

const homeTemplate = () => html`
<section id="welcome">
    <div class="hero layout">
        <div class="splash right-col">
            <i class="fas fa-clipboard-list"></i>
        </div>
        <div class="glass welcome">
            <h1>Welcome to Quiz Fever!</h1>
            <p>Home to 157 quizes in 12 topics. <a href="/browse">Browse all quizes</a>.</p>
            <a class="action cta" href="/login">Sign in to create a quiz</a>
        </div>
    </div>

    <div class="pad-large alt-page">
        <h2>Our most recent quiz:</h2>

        <article class="preview layout">
            <div class="right-col">
                <a class="action cta" href="#">View Quiz</a>
            </div>
            <div class="left-col">
                <h3>Extensible Markup Language</h3>
                <span class="quiz-topic">Topic: Languages</span>
                <div class="quiz-meta">
                    <span>15 questions</span>
                    <span>|</span>
                    <span>Taken 54 times</span>
                </div>
            </div>
        </article>

        <div>
            <a class="action cta" href="/browse">Browse all quizes</a>
        </div>
    </div>

</section>`;

function homeView(ctx) {
    ctx.renderTemplate(homeTemplate());
}

export {
    homeView
}