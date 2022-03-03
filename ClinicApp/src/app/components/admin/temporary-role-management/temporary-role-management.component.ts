import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { UpdateTemporaryRoleModalComponent } from 'src/app/modals/update-temporary-role-modal/update-temporary-role-modal.component';
import { User } from 'src/app/models/user';
import { AdminService } from 'src/app/services/admin.service';

@Component({
  selector: 'app-temporary-role-management',
  templateUrl: './temporary-role-management.component.html',
  styleUrls: ['./temporary-role-management.component.scss']
})
export class TemporaryRoleManagementComponent implements OnInit {
  users: Partial<User[]> | any;
  user$!: Observable<User[]>;
  bsModalRef!: BsModalRef;
  userName!: string;

  constructor(private modalService: BsModalService,
    private adminService: AdminService,) { }

  ngOnInit(): void {
    this.getRequests();
  }

  getRequests(){
    this.adminService.getUsersTemporaryRole().subscribe(users =>{
      this.users = users;
      this.userName = '';
    })

    }

  openTemporaryRole(user: User){
    console.log('user')
    console.log(user);
    const config = {
      class: 'modal-dialog-centered',
      initialState: {
        user,
      }
    }
    this.bsModalRef = this.modalService.show(UpdateTemporaryRoleModalComponent, config);

  }

  Search(){
    this.users = this.users!.filter((res: { userName: string; }) =>{
      return res.userName?.toLocaleLowerCase().match(this.userName?.toLocaleLowerCase());
    })
  }

}
