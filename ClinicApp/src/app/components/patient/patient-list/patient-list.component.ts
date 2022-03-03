import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/models/member';
import PatientService from 'src/app/services/patients.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.scss']
})
export class PatientListComponent implements OnInit {
  patients!: Member[] ;
  lastName! : string;
  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.loadPatients();
  }

  loadPatients(){
    this.patientService.getPatients().subscribe(patients => {
      this.patients = patients;
      this.lastName = '';
    })
  }

  Search(){
    this.patients = this.patients!.filter(res =>{
      return res.lastName?.toLocaleLowerCase().match(this.lastName?.toLocaleLowerCase());
    })
  }
}
