import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Appointment } from "../models/appointment";


@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  baseUrl = environment.apiUrl;
  appointment: Appointment[] = [];

  constructor(private http: HttpClient) { }

  getAppointmentList(patientuserName: string){
    return this.http.get<Appointment[]>(this.baseUrl +'Appointment/' + patientuserName)
  }

  addAppointment(userName: string, reason: string,
    diagnosis: string, recommendation: string, medicines: string, dose: string,
    recommendedDose: string){
      return this.http.post<Appointment>(this.baseUrl +'Appointment', {patientuserName : userName,
      reason, diagnosis, recommendation, medicines,dose,recommendedDose})
    }
}
