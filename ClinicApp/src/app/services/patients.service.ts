import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { of } from "rxjs";
import { map } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Member } from "../models/member";

@Injectable({
  providedIn: "root"
})

export default class PatientService {
  baseUrl = environment.apiUrl;
  patients: Member[] = [];

  constructor(private http: HttpClient) {}

  getPatients(){
    return this.http.get<Member[]>(this.baseUrl + 'Patient/GetPatients');
  }

  getPatient(id: string) {
    const patient = this.patients.find(x =>x.id === id);
    if (patient !== undefined) return of(patient);
    return this.http.get<Member>(this.baseUrl +'Patient/'+id);
  }

  getPatientByEmail(userName: string){
    const patient = this.patients.find(x=>x.userName === userName);
    if (patient !== undefined) return of(patient);
    return this.http.get<Member>(this.baseUrl +'Patient/PatientEmail/'+ userName);
  }

  updatePatientCard(patient: Member){
    return this.http.put(this.baseUrl+'Patient/add-patient-card', patient).pipe(
      map(() => {
        const index = this.patients.indexOf(patient);
        this.patients[index] = patient;
      })
    )
  }
}
