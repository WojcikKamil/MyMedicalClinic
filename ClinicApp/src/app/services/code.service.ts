import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AccesCode } from '../models/accesCode';

@Injectable({
  providedIn: 'root'
})
export class CodeService {
  baseUrl = environment.apiUrl;
  accesCode! : AccesCode;

  constructor(private http: HttpClient) { }

  generateAccesCode(){
    return this.http.get<AccesCode>(this.baseUrl +'Users/GenerateAccesCode')
  }
}
