import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Prescription } from 'src/app/models/prescription';

@Component({
  selector: 'app-prescription-patient-view-modal',
  templateUrl: './prescription-patient-view-modal.component.html',
  styleUrls: ['./prescription-patient-view-modal.component.scss']
})
export class PrescriptionPatientViewModalComponent implements OnInit {
  prescription!: Prescription;
  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

}
