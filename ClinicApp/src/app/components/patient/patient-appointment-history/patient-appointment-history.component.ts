import { Component, EventEmitter, Input, OnInit, ViewChild } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AddAppointmentModalComponent } from 'src/app/modals/appointment-modal/add-appointment-modal/add-appointment-modal.component';
import { AppointmentDetailsViewModalComponent } from 'src/app/modals/appointment-modal/appointment-details-view-modal/appointment-details-view-modal.component';
import { Appointment } from 'src/app/models/appointment';
import { Member } from 'src/app/models/member';
import { AppointmentService } from 'src/app/services/appointment.service';
import { PatientCardComponent } from '../patient-card/patient-card.component';

@Component({
  selector: 'app-patient-appointment-history',
  templateUrl: './patient-appointment-history.component.html',
  styleUrls: ['./patient-appointment-history.component.scss']
})
export class PatientAppointmentHistoryComponent implements OnInit {
  @Input() patientuserName!: string;
 emitUserName = new EventEmitter();
  appointments!: any [];
  bsModalRef!: BsModalRef;

  constructor(
    public appointmentService: AppointmentService,
    private modalService: BsModalService,
    private _snackBar: MatSnackBar
  ) { }


  ngOnInit(): void {
    this.getAppointmentList();
  }

  async getAppointmentList(){
    console.log('Child first', this.patientuserName)
    this.appointmentService.getAppointmentList(this.patientuserName).subscribe( response => {
    this.appointments = response as any;
    console.log('Child second', this.patientuserName)
    })
  }

  openAppointment(appointment: Appointment){
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        appointment,
      }
    }
    this.bsModalRef = this.modalService.show(AppointmentDetailsViewModalComponent, config);

  }

  addAppointment(){
      const config = {
        class: 'modal-dialog-centered modal-xl',
        initialState: {
          userName : this.patientuserName,
        },
      }
      this.bsModalRef = this.modalService.show(AddAppointmentModalComponent, config)
  }

}
