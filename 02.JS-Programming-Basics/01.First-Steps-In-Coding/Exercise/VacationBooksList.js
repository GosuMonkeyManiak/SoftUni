function vacationBooksList(pageNumber, pagesPerHour, numberDay){

    let hour = Number(pageNumber) / Number(pagesPerHour);
    let hourPerday = hour / Number(numberDay);

    console.log(hourPerday);
}

vacationBooksList("212", "20", "2");