import { Component, OnInit } from '@angular/core';
import {Book} from "../shared/interfaces";

@Component({
  selector: 'app-read-books-page',
  templateUrl: './read-books-page.component.html',
  styleUrls: ['./read-books-page.component.scss']
})
export class ReadBooksPageComponent implements OnInit {

  readBooks:Book[] = [];
  unreadBooks:Book[] = [];

  ngOnInit(): void {
    this.unreadBooks = [
      {id: "1", name: "1984", author: "Джордж Оруэлл" },
      {id: "4", name: "Маленький принц", author: "Антуан де Сент-Экзюпери" },
      {id: "5", name: "Убить пересмешника", author: "Харпер Ли" }
    ]
    this.readBooks = [
      {id: "2", name: "Мастер и Маргарита", author: "Михаил Булгаков" },
      {id: "3", name: "Портрет Дориана Грея", author: "Оскар Уайльд" }
    ]
  }
}
