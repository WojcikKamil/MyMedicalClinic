import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { PrescriptionRequestModalComponent } from 'src/app/modals/prescription-modals/prescription-request-modal/prescription-request-modal.component';
import { SymptonRequestModalComponent } from 'src/app/modals/symptom-modals/sympton-request-modal/sympton-request-modal.component';
import { Member } from 'src/app/models/member';
import { Prescription } from 'src/app/models/prescription';
import { User } from 'src/app/models/user';
import DoctorsService from 'src/app/services/doctors.service';

@Component({
  selector: 'app-doctor-profil',
  templateUrl: './doctor-profil.component.html',
  styleUrls: ['./doctor-profil.component.scss']
})
export class DoctorProfilComponent implements OnInit {
 @Input() member!: Member;
 emitUserName = new EventEmitter();
 user!: User;
 bsModalRef!: BsModalRef;

  constructor(private doctorService: DoctorsService,
    private route : ActivatedRoute,
    private dialog: MatDialog,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.loadDoctor();
  }

  loadDoctor() {
    this.doctorService.getDoctor(this.route.snapshot.paramMap.get('id')!).subscribe(member =>{
      this.member = member;
    })
  }

}
