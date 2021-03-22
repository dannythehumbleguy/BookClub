import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Book} from "../shared/interfaces";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http:HttpClient) { }

  getUnreadBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${environment.apiUrl}User/unread-books`)
  }

  getReadBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${environment.apiUrl}User/read-books`)
  }

  addBookToReadBooks(bookId:string) {
    return this.http.patch<any>(`${environment.apiUrl}User/read-books/${bookId}`,{});
  }
  deleteBookToReadBooks(bookId:string) {
    return this.http.delete<any>(`${environment.apiUrl}User/read-books/${bookId}`,{});
  }
}
