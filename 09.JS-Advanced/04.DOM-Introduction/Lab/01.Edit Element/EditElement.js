function editElement(htmlElement, match, replacer) {

    let regex = new RegExp(match, 'g');

    htmlElement.textContent = htmlElement.textContent.replace(regex, replacer);
}