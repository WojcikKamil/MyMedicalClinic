import { Component, Input, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';
import { PrescriptionRequestModalComponent } from 'src/app/modals/prescription-modals/prescription-request-modal/prescription-request-modal.component';
import { SymptonRequestModalComponent } from 'src/app/modals/symptom-modals/sympton-request-modal/sympton-request-modal.component';
import { Member } from 'src/app/models/member';
import { Prescription } from 'src/app/models/prescription';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { PrescriptionService } from 'src/app/services/prescription.service';

@Component({
  selector: 'app-my-pofile-dialog',
  templateUrl: './my-pofile-dialog.component.html',
  styleUrls: ['./my-pofile-dialog.component.scss']
})
export class MyPofileDialogComponent implements OnInit {
  member!: Member;
  user! : User;
  RequestNumber! : number;
  bsModalRef!: BsModalRef;

  constructor(private modalService: BsModalService) {

   }

  ngOnInit(): void {
    this.RequestNumber;
  }

  openPrescription(member: Member){
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
      }
    }
    this.bsModalRef = this.modalService.show(PrescriptionRequestModalComponent, config);

  }

  openSymptom(){
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
      }
    }
    this.bsModalRef = this.modalService.show(SymptonRequestModalComponent, config)
  }


}
