import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl;
  user: User[] = [];

  constructor(private http: HttpClient) { }

  getUsersWithRoles(){
    return this.http.get<Partial<User[]>>(this.baseUrl + 'Admin/users-with-roles')
  }

  updateUserRoles(userName: string, roles: string[]){
    return this.http.post(this.baseUrl + 'Admin/edit-roles/'+userName+'?roles='+roles, {})
  }

  getUsersTemporaryRole(){
    return this.http.get<User[]>(this.baseUrl + 'Admin/users-with-temporaryRole')
  }

  updateTemporaryRole(user: User){
    return this.http.put(this.baseUrl+ 'Admin/edit-temporaryRole', user)
  }

}
