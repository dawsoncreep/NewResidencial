import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../Models/user';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

  private userSubject: BehaviorSubject<User>;
  private userObservable: Observable<User>;

  constructor(private http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('token')));
    this.userObservable = this.userSubject.asObservable();
  }

  public get currentUserValue(): User {
    return this.userSubject.value;
  }

  public get currentUserObservable(): Observable<User> {
    return this.userObservable;
  }

  public logout(): void {
    localStorage.removeItem('token');
    this.userSubject.next(null);
  }

  public login(username: string, password: string): Observable<any> {
    var url = `${environment.apiUrl}/Authentication/Authenticate`;
    
    return this.http.post<any>(url, { "UserName": username, "Password": password }).pipe(map(user => {

      localStorage.setItem('token', JSON.stringify(user));
      this.userSubject.next(user);

      return user;
    }));
  }
}