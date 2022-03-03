import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import AccountService from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent{
  hide = true;
  model: any = {};

  constructor(
    public accountService: AccountService,
    private router : Router,
    private toastr: ToastrService,
  ) { }

  img1: string = "assets/images/bg4.jpg";

  login(){
    this.accountService.login(this.model).subscribe(response => {
      this.toastr.info('Login Successfully');
      this.router.navigate(['/']);
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    })
  }
}
