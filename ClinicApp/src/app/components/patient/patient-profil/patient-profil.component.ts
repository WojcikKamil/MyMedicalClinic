import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from 'src/app/models/member';
import PatientService from 'src/app/services/patients.service';

@Component({
  selector: 'app-patient-profil',
  templateUrl: './patient-profil.component.html',
  styleUrls: ['./patient-profil.component.scss']
})
export class PatientProfilComponent implements OnInit {
  @Input() patient!: Member;

  constructor(private patientService: PatientService,
    private route : ActivatedRoute) { }

  ngOnInit(): void {

  }
}
