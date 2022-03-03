import MaterialModule from './materials.module';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { PanelComponent } from './components/panel/panel.component';
import { DoctorListComponent } from './components/doctor/doctor-list/doctor-list.component';
import { DoctorCardComponent } from './components/doctor/doctor-card/doctor-card.component';
import { MyPofileDialogComponent } from './components/dialog/my-pofile-dialog/my-pofile-dialog.component';
import { DoctorProfilComponent } from './components/doctor/doctor-profil/doctor-profil.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { DoctorEditComponent } from './components/doctor/doctor-edit/doctor-edit.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { AddphotoComponent } from './components/addphoto/addphoto.component';
import { FileUploadModule } from 'ng2-file-upload';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { MessagesComponent } from './components/message/messages/messages.component';
import { MemberMessagesComponent } from './components/message/member-messages/member-messages.component';
import { PatientListComponent } from './components/patient/patient-list/patient-list.component';
import { PatientCardComponent } from './components/patient/patient-card/patient-card.component';
import { PatientEditComponent } from './components/patient/patient-edit/patient-edit.component';
import { PatientProfilComponent } from './components/patient/patient-profil/patient-profil.component';
import { AdminPanelComponent } from './components/admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './directives/has-role.directive';
import { UsersRolesManagementComponent } from './components/admin/users-roles-management/users-roles-management.component';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { PatientMedicalInformationComponent } from './components/patient/patient-medical-information/patient-medical-information.component';
import { PatientMedicalCardMedicalComponent } from './components/patient/patient-medical-card-medical/patient-medical-card-medical.component';
import { PatientCardTabComponent } from './components/patient/patient-card-tab/patient-card-tab.component';
import { PatientListCardComponent } from './components/patient/patient-list-card/patient-list-card.component';
import { DoctorBasicInfoComponent } from './components/doctor/doctor-basic-info/doctor-basic-info.component';
import { PrescriptionRequestsComponent } from './components/prescription/prescription-requests/prescription-requests.component';
import { PrescriptionHistoryComponent } from './components/prescription/prescription-history/prescription-history.component';
import { AddPrescriptionRequestComponent } from './components/prescription/add-prescription-request/add-prescription-request.component';
import { PrescriptionDetailsModalComponent } from './modals/prescription-modals/prescription-details-modal/prescription-details-modal.component';
import { SuccessfullyRequestModalComponent } from './modals/successfully-request-modal/successfully-request-modal.component';
import { RegisterSuccessfullyModalComponent } from './modals/register-successfully-modal/register-successfully-modal.component';
import { ConfirmedPrescriptionsComponent } from './components/prescription/confirmed-prescriptions/confirmed-prescriptions.component';
import { RejectedPrescriptionsComponent } from './components/prescription/rejected-prescriptions/rejected-prescriptions.component';
import { TemporaryRoleManagementComponent } from './components/admin/temporary-role-management/temporary-role-management.component';
import { UpdateTemporaryRoleModalComponent } from './modals/update-temporary-role-modal/update-temporary-role-modal.component';
import { PrescriptionPatientViewModalComponent } from './modals/prescription-modals/prescription-patient-view-modal/prescription-patient-view-modal.component';
import { PrescriptionRequestModalComponent } from './modals/prescription-modals/prescription-request-modal/prescription-request-modal.component';
import { SymptonRequestModalComponent } from './modals/symptom-modals/sympton-request-modal/sympton-request-modal.component';
import { SymptomRequestsComponent } from './components/symptom/symptom-requests/symptom-requests.component';
import { SymptomActiveRequestsComponent } from './components/symptom/symptom-active-requests/symptom-active-requests.component';
import { SymptomAnsweredRequestsComponent } from './components/symptom/symptom-answered-requests/symptom-answered-requests.component';
import { SymptomDetailsModalComponent } from './modals/symptom-modals/symptom-details-modal/symptom-details-modal.component';
import { PatientRequestedHistoryComponent } from './components/symptom/patient-requested-history/patient-requested-history.component';
import { SymptomPatientViewHistoryComponent } from './components/symptom/symptom-patient-view-history/symptom-patient-view-history.component';
import { SuccessfullyRequestedSymptomModalComponent } from './modals/successfully-requested-symptom-modal/successfully-requested-symptom-modal.component';
import { PhotoAddedSuccessfullyComponent } from './modals/pop-up-modals/photo-added-successfully/photo-added-successfully.component';
import { PatientAnsweredHistoryComponent } from './components/symptom/patient-answered-history/patient-answered-history.component';
import { HistoryPatientRequestsComponent } from './components/symptom/history-patient-requests/history-patient-requests.component';
import { PatientWrittenOutMedicinesComponent } from './components/patient/patient-written-out-medicines/patient-written-out-medicines.component';
import { PatientAppointmentHistoryComponent } from './components/patient/patient-appointment-history/patient-appointment-history.component';
import { AppointmentDetailsViewModalComponent } from './modals/appointment-modal/appointment-details-view-modal/appointment-details-view-modal.component';
import { AddAppointmentModalComponent } from './modals/appointment-modal/add-appointment-modal/add-appointment-modal.component';
import { AboutUsComponent } from './components/home/about-us/about-us.component';
import { OfferComponent } from './components/home/offer/offer.component';
import { TranslateModule } from '@ngx-translate/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { WardClerkComponent } from './components/ward-clerk/ward-clerk.component';
import { AccescodeComponent } from './components/ward-clerk/accescode/accescode.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    RegisterComponent,
    LoginComponent,
    PanelComponent,
    DoctorListComponent,
    DoctorCardComponent,
    MyPofileDialogComponent,
    DoctorProfilComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    DoctorEditComponent,
    AddphotoComponent,
    MessagesComponent,
    MemberMessagesComponent,
    PatientListComponent,
    PatientCardComponent,
    PatientEditComponent,
    PatientProfilComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UsersRolesManagementComponent,
    RolesModalComponent,
    PatientMedicalInformationComponent,
    PatientMedicalCardMedicalComponent,
    PatientCardTabComponent,
    PatientListCardComponent,
    DoctorBasicInfoComponent,
    PrescriptionRequestsComponent,
    PrescriptionHistoryComponent,
    AddPrescriptionRequestComponent,
    PrescriptionDetailsModalComponent,
    PrescriptionPatientViewModalComponent,
    PrescriptionRequestModalComponent,
    SuccessfullyRequestModalComponent,
    RegisterSuccessfullyModalComponent,
    ConfirmedPrescriptionsComponent,
    RejectedPrescriptionsComponent,
    TemporaryRoleManagementComponent,
    UpdateTemporaryRoleModalComponent,
    SymptonRequestModalComponent,
    SymptomRequestsComponent,
    SymptomActiveRequestsComponent,
    SymptomAnsweredRequestsComponent,
    SymptomDetailsModalComponent,
    PatientRequestedHistoryComponent,
    SymptomPatientViewHistoryComponent,
    SuccessfullyRequestedSymptomModalComponent,
    PhotoAddedSuccessfullyComponent,
    PatientAnsweredHistoryComponent,
    HistoryPatientRequestsComponent,
    PatientWrittenOutMedicinesComponent,
    PatientAppointmentHistoryComponent,
    AppointmentDetailsViewModalComponent,
    AddAppointmentModalComponent,
    AboutUsComponent,
    OfferComponent,
    WardClerkComponent,
    AccescodeComponent
  ],

  imports:[
    RouterModule,
    MaterialModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    NgbModule,
    FileUploadModule,
    PaginationModule.forRoot(),
    TranslateModule.forChild(),


    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),

    SweetAlert2Module.forRoot(),
  ],
  exports: [
    PaginationModule,
    TranslateModule,
  ],

  providers:[

  ],
})

export default class ComponentsModule {}
