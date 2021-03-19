import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ReadBooksPageComponent} from "./read-books-page/read-books-page.component";
import {LoginRegisterPageComponent} from "./login-register-page/login-register-page.component";

const routes: Routes = [
  {path: '', component:ReadBooksPageComponent},
  {path: 'login', component:LoginRegisterPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
