import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { DoctorCardComponent } from './doctor-card/doctor-card.component';
import { DoctorSearchComponent } from './doctor-search/doctor-search.component';
import { InsuranceSearchComponent } from './insurance-search/insurance-search.component';
import { LoginDoctorComponent } from './login-doctor/login-doctor.component';
import { LoginClientComponent } from './login-client/login-client.component';
import { ClientProfileComponent } from './client-profile/client-profile.component';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';
import { SymptomSearchComponent } from './symptom-search/symptom-search.component';
import { BookAppointmentComponent } from './book-appointments/book-appointments.component';
import { UpdateClientInformationComponent } from './update-client-information/update-client-information.component';
import { UpdateDoctorInformationComponent } from './update-doctor-information/update-doctor-information.component';
import { AppRoutingModule } from './app-routing.module';
import { DoctorAccountComponent } from './doctor-account/doctor-account.component';
import { RegisterDoctorComponent } from './register-doctor/register-doctor.component';
import { RegisterClientComponent } from './register-client/register-client.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { environment as env } from 'src/environments/environment';
import { JwtModule } from "@auth0/angular-jwt";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FilterPipe } from './filter-pipe/filter.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EditClientDetailsComponent } from './edit-client-details/edit-client-details.component';
import { EditDoctorDetailsComponent } from './edit-doctor-details/edit-doctor-details.component';
import { SpecialtySearchComponent } from './specialty-search/specialty-search.component';
import { SpfilterPipe } from './spfilter-pipe/spfilter.pipe';
import { CitySearchComponent } from './city-search/city-search.component';
import { CfilterPipe } from './cfilter/cfilter.pipe';
import { SyfilterPipe } from './syfilter/syfilter.pipe';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatDividerModule } from '@angular/material/divider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { DoctorInformationComponent } from './doctor-information/doctor-information.component';
import { DatePipe } from '@angular/common';


export function tokenGetter() {
  return localStorage.getItem("jwt");
}

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
    UpdateClientInformationComponent,
    UpdateDoctorInformationComponent,
    DoctorAccountComponent,
    RegisterDoctorComponent,
    RegisterClientComponent,
    LoginComponent,
    RegisterComponent,
    FilterPipe,
    EditClientDetailsComponent,
    EditDoctorDetailsComponent,
    SpecialtySearchComponent,
    SpfilterPipe,
    CitySearchComponent,
    CfilterPipe,
    SyfilterPipe,
    DoctorInformationComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44365", "symptomedic-api.eastus.cloudapp.azure.com","https://symptomedic-api.eastus.cloudapp.azure.com"],
        disallowedRoutes:[]
      }
    }),
    BrowserAnimationsModule,
    MatToolbarModule,
  MatInputModule,
  MatCardModule,
  MatMenuModule,
  MatIconModule,
  MatButtonModule,
  MatSelectModule,

  MatProgressSpinnerModule,
  MatSnackBarModule


  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
