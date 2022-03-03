import { Component, EventEmitter, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Prescription } from 'src/app/models/prescription';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { PrescriptionService } from 'src/app/services/prescription.service';

@Component({
  selector: 'app-prescription-details-modal',
  templateUrl: './prescription-details-modal.component.html',
  styleUrls: ['./prescription-details-modal.component.scss']
})
export class PrescriptionDetailsModalComponent implements OnInit {
  @Input() updateSelectedRoles = new EventEmitter();
  @ViewChild('updatePrescription') updatePrescription!: NgForm;
  prescription!: Prescription;
  user!: User;
  constructor(public bsModalRef: BsModalRef,
    private toastr: ToastrService,
    private prescriptionService: PrescriptionService,
    private accountService: AccountService
    ) { this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);}

  ngOnInit(): void {
  }


  updateRoles() {
    this.prescription.doctorName = this.user.name;
    this.prescription.doctorLastName = this.user.lastName;
    this.prescription.doctorEmail = this.user.userName;
    console.log(this.prescription);
    console.log(this.prescription.doctorName);
    this.prescriptionService.updateStatus(this.prescription).subscribe(() => {
      this.toastr.success('Successfully updated Status');
      this.bsModalRef.hide();
      window.location.reload();
    })
  }

}
