import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { User } from 'src/app/Models/user';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  public currentUser: User;

  constructor(private router: Router, private authenticationService: AuthenticationService) {
    this.authenticationService.currentUserObservable.subscribe(result => {
      this.currentUser = result
    });
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
