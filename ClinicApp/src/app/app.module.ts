import { HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import ComponentsModule from './components.module';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoadingInterceptor } from './interceptors/loading.interceptor';
import { FileSelectDirective, FileUploadModule } from 'ng2-file-upload';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TimeagoModule } from 'ngx-timeago';
import { BsModalRef, ModalModule } from 'ngx-bootstrap/modal'
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { PhotoAddedSuccessfullyComponent } from './modals/pop-up-modals/photo-added-successfully/photo-added-successfully.component';
import { AddphotoComponent } from './components/addphoto/addphoto.component';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import {TranslateLoader, TranslateModule} from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ComponentsModule,
    FormsModule,
    FileUploadModule,
    NgbModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    TimeagoModule.forRoot(),
    ModalModule.forRoot(),
    MatDatepickerModule,
    MatNativeDateModule,
    LazyLoadImageModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
  ],
  exports: [
    FileUploadModule,
    ModalModule,
    TranslateModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    {provide:HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide:HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    BsModalRef,
  ],
  bootstrap: [AppComponent],
  entryComponents: [
  ]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient){
  return new TranslateHttpLoader(http);
}
