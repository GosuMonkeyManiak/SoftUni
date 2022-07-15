function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}

function getElementBySelector(cssSelector) {
    return document.querySelector(cssSelector);
}

function showView(view) {
    getElementBySelector('main').replaceChildren(view);
}

function setUserNav() {
    if (sessionStorage.getItem('authToken') != null) {
        getElementBySelector('#user').style.display = 'inline-block';
        getElementBySelector('#guest').style.display = 'none';
    } else {
        getElementBySelector('#user').style.display = 'none';
        getElementBySelector('#guest').style.display = 'inline-block';
    }
}

export {
    e,
    getElementBySelector,
    showView,
    setUserNav
}