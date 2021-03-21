import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {JwtModule} from "@auth0/angular-jwt";

import {ACCESS_TOKEN} from "./shared/local-storage-variables";
import {TokenInterceptor} from "./interceptors/token-interceptor";
import { LoginRegisterPageComponent } from './login-register-page/login-register-page.component';
import { ReadBooksPageComponent } from './read-books-page/read-books-page.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BookInfoCartComponent } from './shared/components/book-info-cart/book-info-cart.component';

export function tokenGetter() {
  return localStorage.getItem(ACCESS_TOKEN);
}

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
    ReactiveFormsModule ,
    JwtModule.forRoot({
      config: {
        tokenGetter
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
