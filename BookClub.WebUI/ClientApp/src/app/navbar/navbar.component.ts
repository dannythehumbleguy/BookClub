import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {AuthService} from "../services/auth.service";
import {ACCESS_TOKEN} from "../shared/local-storage-variables";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  constructor(private router:Router,
              public authService: AuthService) { }


  logout() {
    localStorage.removeItem(ACCESS_TOKEN);
    this.router.navigate(["login"]);
  }
}
