import { NgModule } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {TextFieldModule} from '@angular/cdk/text-field';
import { CommonModule } from '@angular/common';
import {MatTabsModule} from '@angular/material/tabs';
import {MatIconModule} from '@angular/material/icon';
import {ScrollingModule} from '@angular/cdk/scrolling';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatCardModule} from '@angular/material/card';
import {MatBadgeModule} from '@angular/material/badge';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatTableModule} from '@angular/material/table';

const modules = [
  MatToolbarModule,
  MatButtonModule,
  MatInputModule,
  MatGridListModule,
  MatFormFieldModule,
  MatSelectModule,
  MatDialogModule,
  FormsModule,
  TextFieldModule,
  CommonModule,
  ReactiveFormsModule,
  MatTabsModule,
  MatIconModule,
  ScrollingModule,
  MatDatepickerModule,
  MatCardModule,
  MatBadgeModule,
  MatSidenavModule,
  MatSnackBarModule,
  MatTableModule,

];

@NgModule({
  imports: [...modules],
  exports: [...modules],
})
export default class MaterialModule {}
