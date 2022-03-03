import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { PrescriptionDetailsModalComponent } from 'src/app/modals/prescription-modals/prescription-details-modal/prescription-details-modal.component';
import { Member } from 'src/app/models/member';
import { Prescription } from 'src/app/models/prescription';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { PrescriptionService } from 'src/app/services/prescription.service';

@Component({
  selector: 'app-prescription-requests',
  templateUrl: './prescription-requests.component.html',
  styleUrls: ['./prescription-requests.component.scss']
})
export class PrescriptionRequestsComponent implements OnInit {
  prescriptions: Partial<Prescription[]> | any;
  prescription$!: Observable<Prescription[]>;
  specialization!: string;
  user!: User;
  bsModalRef!: BsModalRef;
  doctors!: Member;

  columnsToDisplay = ['PrescriptionRequestSent', 'patientName', 'patientLastName']

  constructor(
    private prescriptionService: PrescriptionService,
    private accountService: AccountService,
    private modalService: BsModalService,
    private toastr: ToastrService,
  ) {
  }

  ngOnInit(): void {
    this.getRequestsV1();
  }

  getRequests(){
    this.prescription$ = this.prescriptionService.getPrescriptionRequestV1();
    }

  getRequestsV1(){
   this.prescriptionService.getPrescriptionRequestV1().subscribe(response => {
     this.prescriptions = response;
   })
  }

  openPrescription(prescription: Prescription){

    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        prescription,
      }
    }
    this.bsModalRef = this.modalService.show(PrescriptionDetailsModalComponent, config);

  }



}

