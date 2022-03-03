import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import PatientService from 'src/app/services/patients.service';
import { PatientAppointmentHistoryComponent } from '../patient-appointment-history/patient-appointment-history.component';

@Component({
  selector: 'app-patient-card',
  templateUrl: './patient-card.component.html',
  styleUrls: ['./patient-card.component.scss']
})
export class PatientCardComponent implements OnInit {
  @Input() patient!: Member;
  user!: User;
  patientuserName!: string;


  constructor(private accountService: AccountService,
    private patientService: PatientService,
    private toastr: ToastrService,
    private route : ActivatedRoute
    ) {

     }

     ngOnInit(): void {
      this.loadPatient();
    }

    loadPatient() {
      this.patientService.getPatient(this.route.snapshot.paramMap.get('id')!).subscribe(response =>{
        this.patient = response;
        this.patientuserName = this.patient.userName;
        console.log('Parent', this.patientuserName)
      })
    }


}
