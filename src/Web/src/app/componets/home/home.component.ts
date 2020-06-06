import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  title = 'web';
  
  constructor(private titleService: Title ) { }

  ngOnInit(): void {
    this.titleService.setTitle(`${environment.applicationName} - Home`);
  }

}
