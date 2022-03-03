import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { PrescriptionPatientViewModalComponent } from 'src/app/modals/prescription-modals/prescription-patient-view-modal/prescription-patient-view-modal.component';
import { Prescription } from 'src/app/models/prescription';
import { PrescriptionService } from 'src/app/services/prescription.service';

@Component({
  selector: 'app-prescription-history',
  templateUrl: './prescription-history.component.html',
  styleUrls: ['./prescription-history.component.scss']
})
export class PrescriptionHistoryComponent implements OnInit {
  prescription$!: Observable<Prescription[]>;
  bsModalRef!: BsModalRef;

  constructor( private prescriptionService: PrescriptionService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.getRequestsHistory()
  }

  getRequestsHistory(){
    this.prescription$ = this.prescriptionService.getPrescriptionHistory();
    }

    openPrescription(prescription: Prescription){
      const config = {
        class: 'modal-dialog-centered',
        initialState: {
          prescription,
        }
      }
      this.bsModalRef = this.modalService.show(PrescriptionPatientViewModalComponent, config);

    }

}
