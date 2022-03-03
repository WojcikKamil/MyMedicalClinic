import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-register-successfully-modal',
  templateUrl: './register-successfully-modal.component.html',
  styleUrls: ['./register-successfully-modal.component.scss']
})
export class RegisterSuccessfullyModalComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  destroy(){
    this.bsModalRef.hide();
  }

}
