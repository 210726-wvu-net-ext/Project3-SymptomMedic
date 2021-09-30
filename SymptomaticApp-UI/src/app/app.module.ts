import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { DoctorCardComponent } from './doctor-card/doctor-card.component';
import { DoctorSearchComponent } from './doctor-search/doctor-search.component';
import { InsuranceSearchComponent } from './insurance-search/insurance-search.component';
import { LoginDoctorComponent } from './login-doctor/login-doctor.component';
import { LoginClientComponent } from './login-client/login-client.component';
import { ClientProfileComponent } from './client-profile/client-profile.component';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';
import { SymptomSearchComponent } from './symptom-search/symptom-search.component';
import { BookAppointmentComponent } from './book-appointment/book-appointment.component';
import { AddInsuranceComponent } from './add-insurance/add-insurance.component';
import { UpdateClientInformationComponent } from './update-client-information/update-client-information.component';
import { UpdateDoctorInformationComponent } from './update-doctor-information/update-doctor-information.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavBarComponent,
    DoctorCardComponent,
    DoctorSearchComponent,
    InsuranceSearchComponent,
    LoginDoctorComponent,
    LoginClientComponent,
    ClientProfileComponent,
    DoctorProfileComponent,
    SymptomSearchComponent,
    BookAppointmentComponent,
    AddInsuranceComponent,
    UpdateClientInformationComponent,
    UpdateDoctorInformationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
    
  ],


  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
