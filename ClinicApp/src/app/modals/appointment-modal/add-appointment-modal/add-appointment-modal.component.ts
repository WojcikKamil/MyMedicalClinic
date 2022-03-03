import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { Appointment } from 'src/app/models/appointment';
import { AppointmentService } from 'src/app/services/appointment.service';

@Component({
  selector: 'app-add-appointment-modal',
  templateUrl: './add-appointment-modal.component.html',
  styleUrls: ['./add-appointment-modal.component.scss']
})
export class AddAppointmentModalComponent implements OnInit {


  appointment!: Appointment;
  reason!: string;
  diagnosis!: string;
  recommendation!:string;
  medicines!: string
  dose!: string
  recommendedDose!: string
  userName!: string;

  constructor(
    public bsModalRef: BsModalRef,
    private toastr: ToastrService,
    private modalService: BsModalService,
    public appointmentService: AppointmentService,
  ) { }

  ngOnInit(): void {
  }



  sendRequest(){
    this.appointmentService.addAppointment(this.userName, this.reason, this.diagnosis, this.recommendation,
      this.medicines, this.dose, this.recommendedDose)
      .subscribe(appointment =>{
        this.appointment = appointment;
        this.bsModalRef.hide();
      })
  }

}
