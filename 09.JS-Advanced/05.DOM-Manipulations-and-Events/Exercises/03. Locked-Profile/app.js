function lockedProfile() {
    let profiles = document.querySelectorAll('.profile');

    Array.from(profiles).forEach(x => {
        x.addEventListener('click', e => {

            let sectionToHideAndShow = x.children[x.children.length - 2];

            if (e.target.tagName == 'BUTTON' && e.target.textContent == 'Show more' && isProfileUnlock(x)) {

                sectionToHideAndShow.style.display = 'block';
                e.target.textContent = 'Hide it';

            } else if (e.target.tagName == 'BUTTON' && e.target.textContent == 'Hide it' && isProfileUnlock(x)) {
                
                sectionToHideAndShow.style.display = 'none';
                e.target.textContent = 'Show more';
            }
        });
    });

    function isProfileUnlock(profile) {
        return Array.from(profile.children)
            .find(x => x.tagName == 'INPUT' && x.value == 'unlock')
            .checked;
    }
}