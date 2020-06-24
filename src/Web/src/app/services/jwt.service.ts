import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  private jwt: JwtHelperService;

  constructor() {
    this.jwt = new JwtHelperService();
  }

  public decode(token: string): User {
    try {
      var actual = this.jwt.decodeToken(token);

      var user = new User();
      user.Id = actual.primarysid;
      user.UserName = actual.unique_name;
      user.Email = actual.email;
      user.Role = actual.role;
      user.Apellidos = actual.LastName;
      user.Permisions = [];
      user.Token = token;
      return user;
    } catch (error) {
      return null;
    }
  }
}
