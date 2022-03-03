import { Component, Input, OnInit } from '@angular/core';
import { Prescription } from 'src/app/models/prescription';
import { PrescriptionService } from 'src/app/services/prescription.service';

@Component({
  selector: 'app-add-prescription-request',
  templateUrl: './add-prescription-request.component.html',
  styleUrls: ['./add-prescription-request.component.scss']
})
export class AddPrescriptionRequestComponent implements OnInit {
  @Input() userName!: any;
  prescription!: Prescription;
  content!: string;
  medicines!: string;
  dose!: string;

  constructor(private prescriptionService: PrescriptionService) { }

  ngOnInit(): void {
  }

  sendRequest(){
    console.log(this.content, this.medicines, this.userName)
    this.prescriptionService.sendPrescriptionRequest(this.userName, this.medicines, this.dose, this.content)
    .subscribe(prescription =>{
      this.prescription = prescription;
    })
  }
}
