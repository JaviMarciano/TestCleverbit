import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IUser from '../domain/user-credential';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  user: IUser = null;

  constructor(private http: HttpClient) { }

  async login(userCredential: IUser): Promise<IUser> {
    return this.http.post<IUser>("api/account/login", userCredential).toPromise();
  }
  
  isAuthenticated() {
    return this.user != null;
  }
}
