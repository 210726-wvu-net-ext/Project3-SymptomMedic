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
import { RegisterComponent } from './register/register.component';
import { RegisterClientComponent } from './register-client/register-client.component';
import { RegisterDoctorComponent } from './register-doctor/register-doctor.component';
import { AuthGuard } from './gaurds/auth-guard.service';
import { BookAppointmentComponent } from './book-appointments/book-appointments.component';


const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: '', component: HomeComponent },
  { path: 'doctor/:id', component: DoctorProfileComponent }, // client views doc profile
  { path: 'profile/:id', component: ClientProfileComponent }, // patient sees their profile
  { path: 'account/:id', component: DoctorAccountComponent }, // see their account
  { path: 'login/client', component: LoginClientComponent},
  { path: 'login/doctor', component: LoginDoctorComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register/client', component: RegisterClientComponent},
  { path: 'register/doctor', component: RegisterDoctorComponent},
  { path: 'register', component: RegisterComponent },
  { path: 'book-appointment', component: BookAppointmentComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule { }
