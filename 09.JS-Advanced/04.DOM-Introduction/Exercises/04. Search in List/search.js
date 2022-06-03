function search() {
    let ul = document.getElementById('towns');
    let input = document.getElementById('searchText');
    let result = document.getElementById('result');

    Array.from(ul.children).map(e => {
        e.style.fontWeight = 'normal';
        e.style.textDecoration = 'none';
    });
    
    let matchedTowns = Array.from(ul.children)
        .filter(e => e.textContent.includes(input.value))
        .map(e => {
            e.style.fontWeight = 'bold';
            e.style.textDecoration = 'underline';
        });
        
    result.textContent = `${matchedTowns.length} matches found`;
}
