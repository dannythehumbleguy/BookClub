import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ReadBooksPageComponent} from "./read-books-page/read-books-page.component";
import {LoginRegisterPageComponent} from "./login-register-page/login-register-page.component";
import {AuthGuard} from "./guards/auth-guard";

const routes: Routes = [
  {path: '', canActivate:[AuthGuard] ,component:ReadBooksPageComponent},
  {path: 'login', component:LoginRegisterPageComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
