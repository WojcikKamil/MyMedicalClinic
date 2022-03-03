import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from 'src/app/models/member';
import PatientService from 'src/app/services/patients.service';

@Component({
  selector: 'app-patient-medical-card-medical',
  templateUrl: './patient-medical-card-medical.component.html',
  styleUrls: ['./patient-medical-card-medical.component.scss']
})
export class PatientMedicalCardMedicalComponent implements OnInit {
  @Input() patient!: Member;

  constructor() { }

  ngOnInit(): void {

  }

}
