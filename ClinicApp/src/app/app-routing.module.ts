import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminPanelComponent } from './components/admin/admin-panel/admin-panel.component';
import { DoctorEditComponent } from './components/doctor/doctor-edit/doctor-edit.component';
import { DoctorListComponent } from './components/doctor/doctor-list/doctor-list.component';
import { DoctorProfilComponent } from './components/doctor/doctor-profil/doctor-profil.component';
import { AboutUsComponent } from './components/home/about-us/about-us.component';
import { HomeComponent } from './components/home/home.component';
import { OfferComponent } from './components/home/offer/offer.component';
import { LoginComponent } from './components/login/login.component';
import { MemberMessagesComponent } from './components/message/member-messages/member-messages.component';
import { MessagesComponent } from './components/message/messages/messages.component';
import { PanelComponent } from './components/panel/panel.component';
import { PatientCardTabComponent } from './components/patient/patient-card-tab/patient-card-tab.component';
import { PatientCardComponent } from './components/patient/patient-card/patient-card.component';
import { PatientEditComponent } from './components/patient/patient-edit/patient-edit.component';
import { PatientListComponent } from './components/patient/patient-list/patient-list.component';
import { PatientMedicalInformationComponent } from './components/patient/patient-medical-information/patient-medical-information.component';
import { PatientProfilComponent } from './components/patient/patient-profil/patient-profil.component';
import { PrescriptionHistoryComponent } from './components/prescription/prescription-history/prescription-history.component';
import { PrescriptionRequestsComponent } from './components/prescription/prescription-requests/prescription-requests.component';
import { RegisterComponent } from './components/register/register.component';
import { HistoryPatientRequestsComponent } from './components/symptom/history-patient-requests/history-patient-requests.component';
import { PatientRequestedHistoryComponent } from './components/symptom/patient-requested-history/patient-requested-history.component';
import { SymptomRequestsComponent } from './components/symptom/symptom-requests/symptom-requests.component';
import { WardClerkComponent } from './components/ward-clerk/ward-clerk.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { AdminGuard } from './guard/admin.guard';
import { AuthGuard } from './guard/auth.guard';
import { DoctorGuard } from './guard/doctor.guard';
import { PatientGuard } from './guard/patient.guard';
import { PatientDoctorGuard } from './guard/patientdoctor.guard';
import { PreventUnsavedChangesGuard } from './guard/prevent-unsaved-changes.guard';
import { WardclerkGuard } from './guard/wardclerk.guard';

const routes: Routes = [
  {path: '', component:HomeComponent},
  {
    path:'',
    children: [
      {path: 'SignUp', component:RegisterComponent},
      {path: 'SignIn', component:LoginComponent},
      {path: 'Panel', component:PanelComponent},
      {path: 'AboutUs', component:AboutUsComponent},
      {path: 'Offer', component:OfferComponent},
      {path: 'DoctorList', component:DoctorListComponent, canActivate: [AuthGuard]},
      {path: 'DoctorProfile/:id', component:DoctorProfilComponent, canActivate: [PatientDoctorGuard]},
      {path: 'EditProfile/edit', component:DoctorEditComponent,canActivate: [DoctorGuard], canDeactivate: [PreventUnsavedChangesGuard]},
      {path: 'Messages', component:MessagesComponent, canActivate: [DoctorGuard]},
      {path: 'PatientList', component:PatientListComponent, canActivate: [DoctorGuard]},
      {path: 'PatientProfil/:id',component:PatientCardComponent, canActivate: [DoctorGuard]},
      {path: 'admin', component: AdminPanelComponent, canActivate: [AdminGuard]},
      {path: 'PatientBasicInformation', component: PatientCardTabComponent, canActivate: [PatientGuard]},
      {path: 'PrescriptionRequests', component: PrescriptionRequestsComponent, canActivate: [DoctorGuard]},
      {path: 'PrescriptionRequestHistory', component: PrescriptionHistoryComponent, canActivate: [PatientGuard]},
      {path: 'SymptomRequests', component: SymptomRequestsComponent, canActivate: [DoctorGuard]},
      {path: 'SymptomRequestedHistory', component:HistoryPatientRequestsComponent, canActivate: [PatientGuard]},
      {path: 'WardClerkManagement', component: WardClerkComponent, canActivate: [WardclerkGuard]}
    ]

  },
  {path: 'errors', component: TestErrorsComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component:NotFoundComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
