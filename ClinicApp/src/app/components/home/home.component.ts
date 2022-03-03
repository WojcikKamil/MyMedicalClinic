import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  constructor(public accountService: AccountService,
    private translate: TranslateService) {
      translate.addLangs(['en', 'pl']);
      translate.setDefaultLang('en');
    }

  ngOnInit(): void {

  }

  img: string = "assets/images/bg3.jpg";

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user')as string);
    this.accountService.setCurrentUser(user);
  }
}
