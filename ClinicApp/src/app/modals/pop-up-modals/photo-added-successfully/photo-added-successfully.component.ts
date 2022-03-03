import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-photo-added-successfully',
  templateUrl: './photo-added-successfully.component.html',
  styleUrls: ['./photo-added-successfully.component.scss']
})
export class PhotoAddedSuccessfullyComponent implements OnInit {

  constructor(public bsModalRef: BsModalRef) { }

  ngOnInit(): void {
  }

  destroy(){
    this.bsModalRef.hide();
    window.location.reload();
  }

}
