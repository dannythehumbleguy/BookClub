import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Params, Router} from "@angular/router";

@Component({
  selector: 'app-login-register-page',
  templateUrl: './login-register-page.component.html',
  styleUrls: ['./login-register-page.component.scss']
})
export class LoginRegisterPageComponent {

  loginForm = new FormGroup({
    email: new FormControl(null,[Validators.required,Validators.email]),
    password: new FormControl(null,[Validators.required, Validators.minLength(8)])
  });
  message:string = '';
  submitted = false;
  constructor(
              private router: Router,
              private route: ActivatedRoute) {
    this.route.queryParams.subscribe((params:Params) =>
    {
      if(params["accessDenied"] === "true"){
        this.message = "You have not authenticated";
      }
    })
  }

  login() {

  }
}
