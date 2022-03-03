import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/models/member';
import { Prescription } from 'src/app/models/prescription';
import { PrescriptionService } from 'src/app/services/prescription.service';
import { SuccessfullyRequestModalComponent } from '../../successfully-request-modal/successfully-request-modal.component';

@Component({
  selector: 'app-prescription-request-modal',
  templateUrl: './prescription-request-modal.component.html',
  styleUrls: ['./prescription-request-modal.component.scss']
})
export class PrescriptionRequestModalComponent implements OnInit {

  prescription!: Prescription;
  doctorEmail!: string;
  member!: Member;
  content!: string;
  medicines!: string;
  dose!: string;
  specialization!: string;

  constructor(private prescriptionService: PrescriptionService,
    public bsModalRef: BsModalRef,
    private toastr: ToastrService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
  }

  sendRequest(){
    this.prescriptionService.sendPrescriptionRequest(this.specialization, this.medicines, this.dose, this.content)
    .subscribe(prescription =>{
      this.prescription = prescription;
      this.bsModalRef.hide();

      const config = {
        class: 'modal-dialog-centered',
        initialState: {
        }
      }
      this.bsModalRef = this.modalService.show(SuccessfullyRequestModalComponent, config);
    })
  }

}
