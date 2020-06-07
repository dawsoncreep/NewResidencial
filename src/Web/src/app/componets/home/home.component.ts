import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { User } from 'src/app/Models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public currentUser: User;
  
  constructor(private titleService: Title, private authenticationService: AuthenticationService) { 
    this.authenticationService.currentUserObservable.subscribe(result => {
      this.currentUser = result;
    });
  }

  ngOnInit(): void {
    this.titleService.setTitle(`${environment.applicationName} - Home`);
  }

}
