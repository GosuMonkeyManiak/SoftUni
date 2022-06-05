function solve() {
    let tableRef = document.querySelector('table');
    let paragraph = document.querySelector('#check p');

    document.querySelectorAll('td button')[0]
        .addEventListener('click', e => {
            let allRows = document.querySelectorAll('tbody tr');
            let matrixOfElements = generateMatrix(Array.from(allRows));

            if (checkIsAllRowsAreUnique(matrixOfElements) && checkIsAllColsAreUnique(matrixOfElements)) {
                tableRef.style.border = '2px solid green';
                paragraph.textContent = 'You solve it! Congratulations!';
                paragraph.style.color = 'green';
            } else {
                tableRef.style.border = '2px solid red';
                paragraph.textContent = 'NOP! You are not done yet...';
                paragraph.style.color = 'red';
            }
        });

    document.querySelectorAll('td button')[1]
        .addEventListener('click', e => {
            tableRef.style.border = 'none';
            paragraph.textContent = '';
            paragraph.style.color = 'none';

            Array.from(document.querySelectorAll('td input[type="number"]'))
                .forEach(x => x.value = '');
        });

    function generateMatrix(arrayOfRows) {
        let result = [];

        for (let i = 0; i < arrayOfRows.length; i++) {
            
            let inputs = [];

            Array.from(arrayOfRows[i].children)
                .forEach(x => {
                    let tdChildren = Array.from(x.children);

                    inputs.push(tdChildren.find(x => x.tagName == 'INPUT'));
                });

            inputs = inputs.map(x => Number(x.value));

            result.push(inputs);
        }

        return result;
    }

    function checkIsAllRowsAreUnique(matrixOfElements) {

        let isUnique = true;

        for (let row = 0; row < matrixOfElements.length; row++) {
            
            for (let col = 0; col < matrixOfElements[row].length; col++) {
                
                let currentElement = matrixOfElements[row][col];
                let currentElements = matrixOfElements[row].filter((v, i) => i != col);
                
                if (currentElements.some(x => x == currentElement)) {
                    isUnique = false;
                }
            }

            if (!isUnique) {
                break;
            }
        }

        return isUnique;
    }

    function checkIsAllColsAreUnique(matrixOfElements) {

        let isUnique = true;

        for (let col = 0; col < matrixOfElements.length; col++) {
            
            for (let row = 0; row < matrixOfElements.length; row++) {
                
                let currentElement = matrixOfElements[row][col];
                let currentElements = getColAsArray(matrixOfElements, col).filter((v, i) => i != row);
                
                if (currentElements.some(x => x == currentElement)) {
                    isUnique = false;
                }
            }

            if (!isUnique) {
                break;
            }
        }

        return isUnique;
    }

    function checkIsAllDiagonalsAreUnique(matrixOfElements) {
        let primaryDiagonal = [];
        let secondaryDiagonal = [];

        for (let row = 0; row < matrixOfElements.length; row++) {
            primaryDiagonal.push(matrixOfElements[row][row]);
        }

        for (let row = matrixOfElements.length - 1; row >= 0; row--) {
           secondaryDiagonal.push(matrixOfElements[row][row]);
        }

        let isUnique = true;

        for (let i = 0; i < primaryDiagonal.length; i++) {
            
            let currentElement = primaryDiagonal[i];
            let currentElements = primaryDiagonal.filter((v, index) => index != i);

            if (currentElements.some(x => x == currentElement)) {
                isUnique = false;
            }

            if (!isUnique) {
                return isUnique;
            }
        }

        for (let i = 0; i < secondaryDiagonal.length; i++) {
            
            let currentElement = secondaryDiagonal[i];
            let currentElements = secondaryDiagonal.filter((v, index) => index != i);

            if (currentElements.some(x => x == currentElement)) {
                isUnique = false;
            }

            if (!isUnique) {
                return isUnique;
            }
        }

        return isUnique;
    }

    function getColAsArray(matrixOfElements, colIndex) {
        
        let result = [];

        for (let row = 0; row < matrixOfElements.length; row++) {
            result.push(matrixOfElements[row][colIndex]);
        }

        return result;
    }
}