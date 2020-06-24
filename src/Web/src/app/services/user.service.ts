import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';
import { JwtService } from './jwt.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
8
  private StorageKey = 'token';
  private userSubject: BehaviorSubject<User>;
  private userObservable: Observable<User>;

  constructor(private http: HttpClient, private tokenService: JwtService) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('token')));
    this.userObservable = this.userSubject.asObservable();
   }

   public GetUsers(){
    var url = `${environment.apiUrl}/User/GetAll`;
    return this.http.get<any>(url)
                    .pipe(map(res => {
                      var user = res;
                      return user;
                    }));
  }
}
