import {Injectable} from "@angular/core";
import {JwtHelperService} from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})

export class TokenService {
  set token(token: string) {
    localStorage.setItem('token', token);
  }

  get token() {
    return localStorage.getItem('token') as string;
  }

  removeToken() {
    return localStorage.removeItem('token');
  }

  isTokenValid() {
    const token = this.token;
    // check if token doesnt exist
    if (!token) {
      return false;
    }

    const jwtHelper = new JwtHelperService();

    // check expiry date
    const isTokenExpired = jwtHelper.isTokenExpired(token);
    if (isTokenExpired) {
      localStorage.clear();
      return false;
    }
    return true;
  }

  isTokenNotValid() {
    return !this.isTokenValid();
  }

  public getUserRoles(): string[] {
    const token = this.token;
    if (token) {
      const jwtHelper = new JwtHelperService();
      const decodedToken = jwtHelper.decodeToken(token);
      console.log(decodedToken)
      const roles = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      return roles ? (Array.isArray(roles) ? roles : [roles]) : [];
    }
    return [];
  }
}

