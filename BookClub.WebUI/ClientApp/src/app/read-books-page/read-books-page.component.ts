import { Component, OnInit } from '@angular/core';
import {Book} from "../shared/interfaces";
import {BookService} from "../services/book.service";

@Component({
  selector: 'app-read-books-page',
  templateUrl: './read-books-page.component.html',
  styleUrls: ['./read-books-page.component.scss']
})
export class ReadBooksPageComponent implements OnInit {

  readBooks:Book[] = [];
  unreadBooks:Book[] = [];

  constructor(private bookService:BookService) {
  }
  ngOnInit(): void {
    this.updateColumns();
  }

  addBookToReadBooks(bookId:string){
    this.bookService.addBookToReadBooks(bookId).subscribe(()=>{
      this.updateColumns();
    });
  }

  deleteBookToReadBooks(bookId:string){
    this.bookService.deleteBookToReadBooks(bookId).subscribe(()=>{
      this.updateColumns();
    });
  }

  updateColumns(){
    this.bookService.getUnreadBooks().subscribe((books)=>{
      this.unreadBooks = books;
    })
    this.bookService.getReadBooks().subscribe((books) => {
      this.readBooks = books;
    })
  }
}
