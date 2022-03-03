import { Component, EventEmitter, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Symptom } from 'src/app/models/symptom';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { SymptomService } from 'src/app/services/symptom.service';

@Component({
  selector: 'app-symptom-details-modal',
  templateUrl: './symptom-details-modal.component.html',
  styleUrls: ['./symptom-details-modal.component.scss']
})
export class SymptomDetailsModalComponent implements OnInit {
  @Input() UpdateSymptom = new EventEmitter();
  @ViewChild('updateSymptom') updateSymptom!: NgForm;
  symptom!: Symptom;
  user!: User;

  constructor(
    public symptomService: SymptomService,
    private toastr: ToastrService,
    public bsModalRef: BsModalRef,
    private accountService: AccountService,
  ) { this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user); }

  ngOnInit(): void {
  }

  UpdateSymptomAnswer() {
    this.symptom.doctorName = this.user.name;
    this.symptom.doctorLastName = this.user.lastName;
    this.symptom.doctorEmail = this.user.userName;
    this.symptomService.UpdateSymptomAnswer(this.symptom).subscribe(() => {
      this.toastr.success('Successfully updated Status');
      this.bsModalRef.hide();
      window.location.reload();
    })
  }

}
