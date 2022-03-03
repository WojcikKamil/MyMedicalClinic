import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/models/member';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import DoctorsService from 'src/app/services/doctors.service';

@Component({
  selector: 'app-doctor-edit',
  templateUrl: './doctor-edit.component.html',
  styleUrls: ['./doctor-edit.component.scss']
})
export class DoctorEditComponent implements OnInit {
  @ViewChild('editForm') editForm!: NgForm;
  doctor!: Member;
  user!: User;
  startDate = new Date(2000, 0, 1);

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if (this.editForm.dirty){
      $event.returnValue = true;
    }
  }

  constructor(private accountService: AccountService,
    private doctorService: DoctorsService,
    private route: ActivatedRoute,
    private toastr: ToastrService){
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
    }
    ngOnInit(): void{
      this.loadDoctor();
    }

    loadDoctor() {
      this.doctorService.getDoctorByEmail(this.user.userName).subscribe(member =>{
        this.doctor = member;
      })
    }

    updateDoctorProfile(){
      this.doctorService.updateDoctor(this.doctor).subscribe(() =>{
        this.toastr.success('Profile updated succesfully')
      this.editForm.reset(this.doctor);
      })
    }

    deletePhoto(photoId: number){
      this.doctorService.deletePhoto(photoId).subscribe(() =>{
        this.doctor.photos = this.doctor.photos.filter(x => x.id !== photoId);
      })
      setTimeout(() => {
        window.location.reload();
      }, 600)
    }
}
