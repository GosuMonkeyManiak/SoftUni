class LibraryCollection {

    constructor(capacity) {
        this.capacity = Number(capacity);
        this.books = [];
    }

    addBook(bookName, bookAuthor) {

        if (this.capacity == 0) {
            throw new Error('Not enough space in the collection.');
        }

        this.books.push({
            bookName,
            bookAuthor,
            payed: false
        });

        this.capacity--;

        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName) {

        let currentBook = this.books.find(x => x.bookName == bookName);

        if (currentBook == undefined) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        if (currentBook.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }

        currentBook.payed = true;

        return `${bookName} has been successfully paid.`
    }

    removeBook(bookName) {

        let currentBook = this.books.find(x => x.bookName == bookName);

        if (currentBook == undefined) {
            throw new Error('The book, you\'re looking for, is not found.');
        }

        if (!currentBook.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        let curretnBookIndex = this.books.findIndex(x => x.bookName == bookName);

        this.books.splice(curretnBookIndex, 1);
        this.capacity++;

        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {

        let result = '';
        
        if (bookAuthor == undefined) {

            result += `The book collection has ${this.capacity} empty spots left.\n`;
            
            this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));

            for (const book of this.books) {
                result += `${book.bookName} == ${book.bookAuthor} - ${book.payed ? 'Has Paid' : 'Not Paid'}.\n`;
            }
        }
        else {

            if (!this.books.some(x => x.bookAuthor == bookAuthor)) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            let bookFromThatAuthor = this.books.filter(x => x.bookAuthor == bookAuthor);

            for (const book of bookFromThatAuthor) {
                result += `${book.bookName} == ${book.bookAuthor} - ${book.payed ? 'Has Paid' : 'Not Paid'}.\n`;
            }
        }

        return result.trim();
    }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());