import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { RegisterSuccessfullyModalComponent } from 'src/app/modals/register-successfully-modal/register-successfully-modal.component';
import AccountService from 'src/app/services/account.service';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  hide = true;
  model: any = {};
  registerForm!: FormGroup;
  bsModalRef!: BsModalRef;

  constructor(private accountService: AccountService,
    private router : Router,
    private toastr: ToastrService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  img1: string = "assets/images/bg4.jpg";

  initializeForm(){
    this.registerForm = new FormGroup({
      userName: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required,
        Validators.minLength(4), Validators.maxLength(12)]),
        accesCode: new FormControl('', [Validators.required,
          Validators.maxLength(6), Validators.minLength(6)]),
      confirmPassword: new FormControl('', Validators.required)
    },{

      validators: this.checkPasswords

    })
  }

  checkPasswords: ValidatorFn = (group: AbstractControl): ValidationErrors | null => {
    let pass = group.get('password')!.value;
    let confirmPass = group.get('confirmPassword')!.value

    return pass === confirmPass ? null : {notSame: true}

  }

  register() {
    this.accountService.register(this.registerForm.value).subscribe(response => {
      const config = {
        class: 'modal-dialog-centered',
        initialState: {
        }
      }
      this.bsModalRef = this.modalService.show(RegisterSuccessfullyModalComponent, config);
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  }

}
