import { Component, Input, OnInit } from '@angular/core';
import { FileUploader} from 'ng2-file-upload';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { PhotoAddedSuccessfullyComponent } from 'src/app/modals/pop-up-modals/photo-added-successfully/photo-added-successfully.component';
import { Member } from 'src/app/models/member';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';

@Component({
  selector: 'app-addphoto',
  templateUrl: './addphoto.component.html',
  styleUrls: ['./addphoto.component.scss']
})
export class AddphotoComponent{

@Input() doctor!: Member;
uploader!: FileUploader;
hasBaseDropzoneOver = false;
baseUrl = 'https://localhost:44338/api/Photo/add-photo';
user!: User;

  constructor(
    private accountService: AccountService,
    public bsModalRef: BsModalRef,
    private toastr: ToastrService,
    private modalService: BsModalService
    ) {
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
    }

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e: any){
    this.hasBaseDropzoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl,
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response){
        const photo = JSON.parse(response);
        this.doctor.photos.push(photo);
      }

      const config = {
        class: 'modal-dialog-centered',
        initialState: {
        }
      }
      this.bsModalRef = this.modalService.show(PhotoAddedSuccessfullyComponent, config);
    }

  }

}
