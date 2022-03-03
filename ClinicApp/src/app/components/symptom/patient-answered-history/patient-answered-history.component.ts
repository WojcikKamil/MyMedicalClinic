import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { Symptom } from 'src/app/models/symptom';
import { SymptomService } from 'src/app/services/symptom.service';
import { SymptomPatientViewHistoryComponent } from '../symptom-patient-view-history/symptom-patient-view-history.component';

@Component({
  selector: 'app-patient-answered-history',
  templateUrl: './patient-answered-history.component.html',
  styleUrls: ['./patient-answered-history.component.scss']
})
export class PatientAnsweredHistoryComponent implements OnInit {
  symptom: Partial<Symptom[]> | any;
  symptom$!: Observable<Symptom[]>;
  bsModalRef!: BsModalRef;

  constructor(
    private symptomService: SymptomService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.getRequestsHistory();
  }

  getRequestsHistory(){
    this.symptom$ = this.symptomService.getSymptomAnsweredRequestHistory();
    }

    openSymptom(symptom: Symptom){
      const config = {
        class: 'modal-dialog-centered',
        initialState: {
          symptom,
        }
      }
      this.bsModalRef = this.modalService.show(SymptomPatientViewHistoryComponent, config);

    }
}
