import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/models/member';

@Component({
  selector: 'app-patient-list-card',
  templateUrl: './patient-list-card.component.html',
  styleUrls: ['./patient-list-card.component.scss']
})
export class PatientListCardComponent implements OnInit {
@Input()patients!: Member[] ;
  constructor() { }

  ngOnInit(): void {
  }

}
