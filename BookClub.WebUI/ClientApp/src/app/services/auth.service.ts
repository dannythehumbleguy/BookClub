import { Injectable } from '@angular/core';
import {JwtHelperService} from "@auth0/angular-jwt";
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {AuthRequest, AuthResponse} from "../shared/interfaces";
import {tap} from "rxjs/operators";
import {ACCESS_TOKEN} from "../shared/local-storage-variables";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,
              private jwtService: JwtHelperService,
              private router: Router) { }

  loginOrRegister(request:AuthRequest) : Observable<AuthResponse>{
    return this.http.post<AuthResponse>(`${environment.apiUrl}Auth/login-register`, request)
      .pipe(
        tap(
          response =>localStorage.setItem(ACCESS_TOKEN, response.token)
        )
      )
  }
  isAuthenticated(): boolean{
    const token = localStorage.getItem(ACCESS_TOKEN);
    if(token == null)
      return false;

    return !this.jwtService.isTokenExpired(token);
  }
}
