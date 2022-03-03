import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { PrescriptionPatientViewModalComponent } from 'src/app/modals/prescription-modals/prescription-patient-view-modal/prescription-patient-view-modal.component';
import { Member } from 'src/app/models/member';
import { Prescription } from 'src/app/models/prescription';
import { PrescriptionService } from 'src/app/services/prescription.service';

@Component({
  selector: 'app-patient-written-out-medicines',
  templateUrl: './patient-written-out-medicines.component.html',
  styleUrls: ['./patient-written-out-medicines.component.scss']
})
export class PatientWrittenOutMedicinesComponent implements OnInit {
  @Input() patientuserName!: string;
  prescriptions!: any [];
  smt! : any[];
  bsModalRef!: BsModalRef;

  constructor(
    private prescriptionService: PrescriptionService,
    private route : ActivatedRoute,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.getMedicines();
  }


  getMedicines(){
    console.log("teoretycznie przed", this.patientuserName)
    console.log(this.patientuserName);
    this.prescriptionService.GetPatientWrittenOutMedicines(this.patientuserName).subscribe(response =>{
      this.prescriptions = response as any;
    })
  }

  openPrescription(prescription: Prescription){
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        prescription,
      }
    }
    this.bsModalRef = this.modalService.show(PrescriptionPatientViewModalComponent, config);

  }
}
