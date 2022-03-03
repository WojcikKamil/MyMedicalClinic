import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import PatientService from 'src/app/services/patients.service';

@Component({
  selector: 'app-patient-edit',
  templateUrl: './patient-edit.component.html',
  styleUrls: ['./patient-edit.component.scss']
})
export class PatientEditComponent implements OnInit {
  @Input() patient!: Member;
  @ViewChild('editFormPatientCard') editFormPatientCard!: NgForm;
  user!: User;
  startDate = new Date(2000, 0, 1);

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if (this.editFormPatientCard.dirty){
      $event.returnValue = true;
    }
  }

  constructor(private accountService: AccountService,
    private patientService: PatientService,
    private toastr: ToastrService
    ) {
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
     }

  ngOnInit(): void {
  }

  updatePatientCard(){
    this.patientService.updatePatientCard(this.patient).subscribe(() =>{
      this.toastr.success('Profile updated succesfully')
    this.editFormPatientCard.reset(this.patient);
    })
  }
}
