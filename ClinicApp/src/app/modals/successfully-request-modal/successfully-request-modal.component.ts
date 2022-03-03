import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-successfully-request-modal',
  templateUrl: './successfully-request-modal.component.html',
  styleUrls: ['./successfully-request-modal.component.scss']
})
export class SuccessfullyRequestModalComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  destroy(){
    this.bsModalRef.hide();
  }
}
