function extract(elementId) {
    let para = document.getElementById(elementId).textContent;
    let regex = new RegExp('\(([^)]+)\)', 'g');
    let result = [];

    let match = regex.exec(para);

    while (match) {
        result.push(match[1]);
        match = regex.exec(para);
    }

    return result.join('; ');
}   