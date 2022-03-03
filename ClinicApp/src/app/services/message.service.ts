import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Member } from "../models/member";
import { Message } from "../models/message";
import { PaginatedResult } from "../models/Pagination";

@Injectable({
  providedIn: 'root'
})

export class MessageService{
  baseUrl = environment.apiUrl;
  paginatedResult: PaginatedResult<Message[] | null> = new PaginatedResult<Message[] | null>();

  constructor(private http: HttpClient){}

    getMessages( page?: number, itemsPerPage?: number, container?: any){

      let params = new HttpParams();

    if(page !== null && itemsPerPage !== null){
      params = params.append('pageNumber', page!.toString());
      params = params.append('pageSize', itemsPerPage!.toString());
      params = params.append('Container', container);
    }
    return this.http.get<Message[]>(this.baseUrl + 'Messages', {observe: 'response', params}).pipe(
      map(response => {
        this.paginatedResult.result = response.body;
        if (response.headers.get('Pagination') !== null) {
          this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination') || '{}');
        }
        return this.paginatedResult;
      })
    )
    }

    GetMessageThread(userName: string){
      return this.http.get<Message[]>(this.baseUrl+ 'Messages/thread/' + userName);
    }

    SendMessage(userName: string, content: string){
      return this.http.post<Message>(this.baseUrl+ 'Messages', {recipientUserName: userName, content})
    }
}
