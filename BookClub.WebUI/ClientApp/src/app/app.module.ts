import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginRegisterPageComponent } from './login-register-page/login-register-page.component';
import { ReadBooksPageComponent } from './read-books-page/read-books-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { BookInfoCartComponent } from './shared/components/book-info-cart/book-info-cart.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginRegisterPageComponent,
    ReadBooksPageComponent,
    NavbarComponent,
    BookInfoCartComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
