import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/models/member';
import { Pagination } from 'src/app/models/Pagination';
import DoctorsService from 'src/app/services/doctors.service';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.scss']
})
export class DoctorListComponent implements OnInit {

  doctors!: Member[] | null;
  filterDoctors!: Member[] | null;
  Specialization! : string;

  pagination!: Pagination;
  pageNumber = 1;
  pageSize = 8;
  constructor( private doctorService: DoctorsService) { }

  ngOnInit(): void {
    this.loadDoctors();
  }

  loadDoctors(){
    this.doctorService.getDoctors(this.pageNumber, this.pageSize).subscribe(response => {
      this.doctors = response.result;
      this.pagination = response.pagination;
      this.Specialization = '';
    })
  }

  pageChanged(event: any){
    this.pageNumber = event.page;
    this.loadDoctors();
  }

  Search(){
    this.doctors = this.doctors!.filter(res =>{
      return res.specialization.match(this.Specialization.toLocaleUpperCase());
    })
  }


}
