import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { DoctorProfileComponent } from './doctor-profile/doctor-profile.component';
import { HomeComponent } from './home/home.component';
import { ClientProfileComponent } from './client-profile/client-profile.component';
import { DoctorAccountComponent } from './doctor-account/doctor-account.component';
import { LoginClientComponent } from './login-client/login-client.component';
import { LoginDoctorComponent } from './login-doctor/login-doctor.component';
import { LoginComponent } from './login/login.component';
import { BookAppointmentComponent } from './book-appointments/book-appointments.component';
import { RegisterComponent } from './register/register.component';
import { RegisterClientComponent } from './register-client/register-client.component';
import { RegisterDoctorComponent } from './register-doctor/register-doctor.component';
import { AuthGuard } from './gaurds/auth-guard.service';
import { DoctorSearchComponent } from './doctor-search/doctor-search.component';
import { SpecialtySearchComponent } from './specialty-search/specialty-search.component';
import { CitySearchComponent } from './city-search/city-search.component';
import { SymptomSearchComponent } from './symptom-search/symptom-search.component';



const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: '', component: HomeComponent },
  { path: 'doctor/:id', component: DoctorProfileComponent,  canActivate: [AuthGuard]}, // client views doc profile
  { path: 'profile/:id', component: ClientProfileComponent,  canActivate: [AuthGuard] }, // patient sees their profile
  { path: 'account/:id', component: DoctorAccountComponent,  canActivate: [AuthGuard]}, // see their account
  { path: 'login/client', component: LoginClientComponent},
  { path: 'login/doctor', component: LoginDoctorComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register/client', component: RegisterClientComponent },
  { path: 'appointment/:id', component: BookAppointmentComponent },
  { path: 'register/doctor', component: RegisterDoctorComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'doctor-search', component: DoctorSearchComponent},
  { path: 'specialty-search', component: SpecialtySearchComponent},
  { path: 'city-search', component: CitySearchComponent},
  { path: 'symptom-search', component: SymptomSearchComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
