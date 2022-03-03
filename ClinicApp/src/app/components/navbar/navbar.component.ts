import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';
import { User } from 'src/app/models/user';
import AccountService from 'src/app/services/account.service';
import { MyPofileDialogComponent } from '../dialog/my-pofile-dialog/my-pofile-dialog.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent{
  public isMenuCollapsed = true;
  user!: User;
  constructor(public accountService:AccountService,
    private router : Router,
    private dialog: MatDialog,
    private translate: TranslateService) {
      translate.addLangs(['en', 'pl']);
      translate.setDefaultLang('en');
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
     }

  logout(){
    this.accountService.logout();
    this.router.navigate(['/']);
  }

  openMyProfileDialog(): void{
    this.dialog.open(MyPofileDialogComponent)
  }

  useLanguage(language: string): void {
    this.translate.use(language);
}

}
