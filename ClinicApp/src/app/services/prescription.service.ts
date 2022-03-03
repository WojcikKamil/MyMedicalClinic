import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Prescription } from '../models/prescription';

@Injectable({
  providedIn: 'root'
})
export class PrescriptionService {
  baseUrl = environment.apiUrl;
  prescription: Prescription[] = [];

  constructor(private http: HttpClient) { }

  getPrescriptionRequestV1(){
    return this.http.get<Prescription[]>(this.baseUrl + 'Prescription/Active-RequestsV1')
  }

  GetPatientWrittenOutMedicines(patientuserName: string) {
    return this.http.get<Prescription>(this.baseUrl +'Prescription/' + patientuserName)
  }

  getConfirmedPrescriptionRequest(){
    return this.http.get<Prescription[]>(this.baseUrl + 'Prescription/Confirmed-Requests')
  }

  getRejectedPrescriptionRequest(){
    return this.http.get<Prescription[]>(this.baseUrl + 'Prescription/Rejected-Requests')
  }

  getPrescriptionHistory(){
    return this.http.get<Prescription[]>(this.baseUrl + 'Prescription/Request-History')
  }

  sendPrescriptionRequest(specialization: string, medicines: string, dose: string, content: string){
    return this.http.post<Prescription>(this.baseUrl + 'Prescription/v1', {specialization, medicines, dose, content})
  }

  updateStatus(prescription: Prescription){
    return this.http.put(this.baseUrl+'Prescription/Update-Prescription-StatusV1', prescription);
  }
}
