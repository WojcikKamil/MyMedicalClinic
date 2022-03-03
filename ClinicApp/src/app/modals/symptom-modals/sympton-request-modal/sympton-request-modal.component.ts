import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Member } from 'src/app/models/member';
import { Symptom } from 'src/app/models/symptom';
import { SymptomService } from 'src/app/services/symptom.service';
import { SuccessfullyRequestedSymptomModalComponent } from '../../successfully-requested-symptom-modal/successfully-requested-symptom-modal.component';

@Component({
  selector: 'app-sympton-request-modal',
  templateUrl: './sympton-request-modal.component.html',
  styleUrls: ['./sympton-request-modal.component.scss']
})
export class SymptonRequestModalComponent implements OnInit {
  userName!: string;
  worryingSymptom!: string;
  member!: Member;
  symptom!: Symptom;
  specialization!: string;

  constructor(public bsModalRef: BsModalRef,
    private modalService: BsModalService,
    public symptomService: SymptomService) { }

  ngOnInit(): void {
  }

  sendRequest(){
    this.symptomService.sendSymptomRequest(this.specialization, this.worryingSymptom)
    .subscribe(symptom =>{
      this.symptom = symptom;
      this.bsModalRef.hide();

      const config = {
        class: 'modal-dialog-centered',
        initialState: {
        }
      }
      this.bsModalRef = this.modalService.show(SuccessfullyRequestedSymptomModalComponent, config);
    })
  }

}
