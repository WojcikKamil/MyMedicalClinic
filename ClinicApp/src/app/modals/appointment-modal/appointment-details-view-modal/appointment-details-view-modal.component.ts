import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Appointment } from 'src/app/models/appointment';

@Component({
  selector: 'app-appointment-details-view-modal',
  templateUrl: './appointment-details-view-modal.component.html',
  styleUrls: ['./appointment-details-view-modal.component.scss']
})
export class AppointmentDetailsViewModalComponent implements OnInit {
  appointment!: Appointment

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

}
