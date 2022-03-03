import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-successfully-requested-symptom-modal',
  templateUrl: './successfully-requested-symptom-modal.component.html',
  styleUrls: ['./successfully-requested-symptom-modal.component.scss']
})
export class SuccessfullyRequestedSymptomModalComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  destroy(){
    this.bsModalRef.hide();
  }

}
