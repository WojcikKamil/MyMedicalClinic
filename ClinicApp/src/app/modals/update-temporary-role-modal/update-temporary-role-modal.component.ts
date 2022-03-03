import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/models/user';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-update-temporary-role-modal',
  templateUrl: './update-temporary-role-modal.component.html',
  styleUrls: ['./update-temporary-role-modal.component.scss']
})
export class UpdateTemporaryRoleModalComponent implements OnInit {
  user!: User;
  @ViewChild('updateTemporaryRole') updateTemporaryRole!: NgForm;
  constructor(public bsModalRef: BsModalRef,
    private toastr: ToastrService,
    private adminService: AdminService) { }

  ngOnInit(): void {
  }

  updateRoles() {
    console.log(this.user)
    this.adminService.updateTemporaryRole(this.user).subscribe(() => {
      this.toastr.success('Profile updated succesfully');
      this.bsModalRef.hide();
      window.location.reload();
    })
  }
}
