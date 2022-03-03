import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, HostListener, Input, NgZone, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import PatientService from 'src/app/services/patients.service';

@Component({
  selector: 'app-patient-medical-information',
  templateUrl: './patient-medical-information.component.html',
  styleUrls: ['./patient-medical-information.component.scss']
})
export class PatientMedicalInformationComponent implements OnInit {
  @ViewChild('editFormPatientMedicalInformation') editFormPatientMedicalInformation!: NgForm;
  @ViewChild('autosize') autosize!: CdkTextareaAutosize;
  @Input() patient!: Member;
  user!: User;

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if (this.editFormPatientMedicalInformation.dirty){
      $event.returnValue = true;
    }
  }

  constructor(private accountService: AccountService,
    private patientService: PatientService,
    private toastr: ToastrService,
    private _ngZone: NgZone
    ) {
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
     }

  ngOnInit(): void {
  }

  updatePatientCard(){
    this.patientService.updatePatientCard(this.patient).subscribe(() =>{
      this.toastr.success('Profile updated succesfully')
      this.editFormPatientMedicalInformation.reset(this.patient);
    })
  }
}
