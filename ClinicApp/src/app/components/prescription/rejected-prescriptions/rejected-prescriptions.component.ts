import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { PrescriptionDetailsModalComponent } from 'src/app/modals/prescription-modals/prescription-details-modal/prescription-details-modal.component';
import { Prescription } from 'src/app/models/prescription';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { PrescriptionService } from 'src/app/services/prescription.service';

@Component({
  selector: 'app-rejected-prescriptions',
  templateUrl: './rejected-prescriptions.component.html',
  styleUrls: ['./rejected-prescriptions.component.scss']
})
export class RejectedPrescriptionsComponent implements OnInit {

  prescriptions: Partial<Prescription[]> | any;
  prescription$!: Observable<Prescription[]>;
  user!: User;
  bsModalRef!: BsModalRef;

  constructor(
    private prescriptionService: PrescriptionService,
    private accountService: AccountService,
    private modalService: BsModalService,
    private toastr: ToastrService,
  ) {
  }

  ngOnInit(): void {
    this.getRequests();
  }
  getRequests(){
    this.prescription$ = this.prescriptionService.getRejectedPrescriptionRequest();
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
