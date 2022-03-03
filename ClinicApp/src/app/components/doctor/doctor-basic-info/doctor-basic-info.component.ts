import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Member } from 'src/app/models/member';

@Component({
  selector: 'app-doctor-basic-info',
  templateUrl: './doctor-basic-info.component.html',
  styleUrls: ['./doctor-basic-info.component.scss']
})
export class DoctorBasicInfoComponent implements OnInit {
@Input() doctor!: Member;


  constructor() { }

  ngOnInit(): void {
  }

}
