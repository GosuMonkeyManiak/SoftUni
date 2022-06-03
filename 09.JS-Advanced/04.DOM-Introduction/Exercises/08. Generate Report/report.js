function generateReport() {

    let allInputs = document.querySelectorAll('input[type="checkbox"]');

    let selectedColumns = Array.from(allInputs).filter((v, i) => {
        v.inputOrder = i;
        return v.checked;
    });

    let allRows = document.querySelectorAll('tbody tr');

    let rowsForReport = Array.from(allRows);

    let report = [];

    for (const row of rowsForReport) {
    
        let tds = Array.from(row.children);
        tds = tds.filter((v, i) => selectedColumns.some(c => c.inputOrder == i)); // arry of td
        
        let currentRowObject = {};

        //create a object of td for row
        for (let i = 0; i < tds.length; i++) {

            let columnName = selectedColumns[i].name;
            let columnValue = tds[i].textContent;

            currentRowObject[columnName] = columnValue;
        }

        report.push(currentRowObject);
    }

    let reportAsJSON = JSON.stringify(report, null, 2);

    document.getElementById('output').textContent = reportAsJSON;
}