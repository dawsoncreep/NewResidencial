import { Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {UserService} from 'src/app/services/user.service';
import {MatTableDataSource} from '@angular/material/table';
import { from } from 'rxjs';
import { User } from 'src/app/Models/user';

@Component({
  selector: 'app-user-management-admin-list',
  templateUrl: './user-management-admin-list.component.html',
  styleUrls: ['./user-management-admin-list.component.css']
})
export class UserManagementAdminListComponent implements OnInit {
  displayedColumns: string[] = ['id', 'UserName', 'Apellidos', 'Email'];
  dataSource: MatTableDataSource<User>;
  public Users;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private userService : UserService) {
     this.userService.GetUsers().subscribe(
      result => {
        this.Users = result;
        this.dataSource = new MatTableDataSource(this.Users);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error => {
        var errorMessage = <any>error;
        console.log(errorMessage);
      }
    );
      
   }

  ngOnInit(): void {
    
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}



