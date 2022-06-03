function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let ulRef = document.querySelectorAll('tbody tr');

      Array.from(ulRef)
         .map(tr => tr.classList.remove('select'));

      let allRows = Array.from(ulRef);
      let searchInput = document.getElementById('searchField');
      let searchTerm = searchInput.value;

      allRows = allRows.filter(tr => 
         Array.from(tr.children)
            .some(td => td.textContent.includes(searchTerm)))
         .map(tr => tr.classList.add('select'));

      searchInput.value = '';
   }
}