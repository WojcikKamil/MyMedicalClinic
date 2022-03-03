import { Component, Input, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import PatientService from 'src/app/services/patients.service';

@Component({
  selector: 'app-patient-card-tab',
  templateUrl: './patient-card-tab.component.html',
  styleUrls: ['./patient-card-tab.component.scss']
})
export class PatientCardTabComponent implements OnInit {
  @Input() patient!: Member;
  patientuserName!: string;
  user!: User;

  constructor(private accountService: AccountService,
    private patientService: PatientService,
    private route : ActivatedRoute
    ) {
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
     }

     ngOnInit(): void {
      this.loadPatient();
    }

    loadPatient(){
      this.patientService.getPatientByEmail(this.user.userName).subscribe(member =>{
      this.patient = member
      this.patientuserName = this.patient.userName;
      })
    }

}
