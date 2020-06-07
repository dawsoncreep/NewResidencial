import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { User } from 'src/app/Models/user';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Role } from 'src/app/Models/role';

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public currentUser: User;
  public nickName: string;

  constructor(private router: Router, private authenticationService: AuthenticationService) {
    this.authenticationService.currentUserObservable.subscribe(result => {
      this.currentUser = result

      if (this.currentUser != null) {
        this.nickName = `${this.currentUser.UserName} - ${this.currentUser.Role}`;
      }

    });
  }

  public logout(): void {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }

  public isSettler(): boolean {
    return this.currentUser != null && (this.currentUser.Role == Role.Settler || this.currentUser.Role == Role.Representative)
  }

  public isAdmin(): boolean {
    return this.currentUser != null && (this.currentUser.Role == Role.Administrator || this.currentUser.Role == Role.Ceo)
  }
}
