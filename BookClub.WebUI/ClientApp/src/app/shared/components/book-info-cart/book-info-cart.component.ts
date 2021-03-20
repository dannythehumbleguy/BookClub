import {Component, Input, OnInit} from '@angular/core';
import {Book} from "../../interfaces";

@Component({
  selector: 'app-book-info-cart',
  templateUrl: './book-info-cart.component.html',
  styleUrls: ['./book-info-cart.component.scss']
})
export class BookInfoCartComponent {

  @Input()
  book!:Book;
  @Input()
  buttonMessage!:string;
}
