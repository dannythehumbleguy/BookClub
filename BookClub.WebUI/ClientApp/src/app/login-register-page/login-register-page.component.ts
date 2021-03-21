import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {ActivatedRoute, Params, Router} from "@angular/router";
import {AuthRequest} from "../shared/interfaces";
import {AuthService} from "../services/auth.service";
import {delay} from "rxjs/operators";

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
  constructor(private authService: AuthService,
              private router: Router,
              private route: ActivatedRoute) {
    this.route.queryParams.subscribe((params:Params) =>
    {
      if(params["accessDenied"] === "true"){
        this.message = "You have not authenticated\n";
      }
    })
  }

  loginOrRegister() {
    this.submitted = true;
    const request:AuthRequest = {
      password: this.loginForm.value.password,
      email: this.loginForm.value.email
    }
    this.authService.loginOrRegister(request).subscribe((response) =>{
      if(!response.wasRegistered){
        this.message += "A user with such an email will not find it, so he was registered.\n";
        delay(2000);
      }
      this.loginForm.reset();
      this.router.navigate(['']);
      this.submitted = false;
    }, error => {
      this.submitted = false
    })
  }
}
