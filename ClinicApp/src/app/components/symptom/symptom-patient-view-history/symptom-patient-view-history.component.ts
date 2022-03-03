import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Symptom } from 'src/app/models/symptom';

@Component({
  selector: 'app-symptom-patient-view-history',
  templateUrl: './symptom-patient-view-history.component.html',
  styleUrls: ['./symptom-patient-view-history.component.scss']
})
export class SymptomPatientViewHistoryComponent implements OnInit {
  symptom!: Symptom;


  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

}
