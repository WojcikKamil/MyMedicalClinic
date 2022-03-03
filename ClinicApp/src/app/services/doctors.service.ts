import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { of } from "rxjs";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Member } from "../models/member";
import { PaginatedResult } from "../models/Pagination";
import { Photo } from "../models/photo";



@Injectable({
  providedIn: "root"
})

export default class DoctorsService {
  baseUrl = environment.apiUrl;
  doctors: Member[] = [];
  paginatedResult: PaginatedResult<Member[] | null> = new PaginatedResult<Member[] | null>();

  constructor(private http: HttpClient) {}

  getDoctors(page?: number, itemsPerPage?: number){
    let params = new HttpParams();

    if(page !== null && itemsPerPage !== null){
      params = params.append('pageNumber', page!.toString());
      params = params.append('pageSize', itemsPerPage!.toString());
    }

    return this.http.get<Member[]>(this.baseUrl + 'Doctor/GetDoctors', {observe: 'response', params}).pipe(
      map(response => {
        this.paginatedResult.result = response.body;
        if (response.headers.get('Pagination') !== null) {
          this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination') || '{}');
        }
        return this.paginatedResult;
      })
    )
  }

  getDoctor(id: string) {
    const doctor = this.doctors.find(x=>x.id === id);
    if (doctor !== undefined) return of(doctor);
    return this.http.get<Member>(this.baseUrl +'Doctor/'+id);
  }

  getDoctorByEmail(UserName: string){
    const doctor = this.doctors.find(x=>x.userName === UserName);
    if (doctor !== undefined) return of(doctor);
    return this.http.get<Member>(this.baseUrl +'Doctor/'+ UserName);
  }

  updateDoctor(doctor: Member){
    return this.http.put(this.baseUrl +'Doctor', doctor).pipe(
      map(() => {
        const index = this.doctors.indexOf(doctor);
        this.doctors[index] =doctor;
      })
    )
  }

  deletePhoto(PhotoId: number){
    return this.http.delete(this.baseUrl + 'Photo/delete-photo/' + PhotoId);
  }
}

