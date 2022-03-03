import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Symptom } from "../models/symptom";


@Injectable({
  providedIn: 'root'
})
export class SymptomService {
  baseUrl = environment.apiUrl;
  symptom: Symptom[] = [];

  constructor(private http: HttpClient) { }

  getActiveSymptomRequest(){
    return this.http.get<Symptom[]>(this.baseUrl + 'Symptom/Active-Requests')
  }

  getActiveSymptomCount(){
    return this.http.get<Symptom[]>(this.baseUrl + 'Symptom/RequestCount')
  }

  getAnsweredSymptomRequest(){
    return this.http.get<Symptom[]>(this.baseUrl + 'Symptom/Answered-Requests')
  }

  getSymptomRequestHistory(){
    return this.http.get<Symptom[]>(this.baseUrl + 'Symptom/Request-History')
  }

  getSymptomAnsweredRequestHistory(){
    return this.http.get<Symptom[]>(this.baseUrl + 'Symptom/Request-Answered-History')
  }

  sendSymptomRequest(specialization:string, worryingSymptom:string){
    return this.http.post<Symptom>(this.baseUrl + 'Symptom', {specialization, worryingSymptom})
  }

  UpdateSymptomAnswer(symptom:Symptom){
    return this.http.put<Symptom>(this.baseUrl + 'Symptom/Update-Symptom-Answer', symptom)
  }
}

