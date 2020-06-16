import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

// Business Components
import { PatientListComponent } from './components/patient/patient-list/patient-list.component';
import { PatientFormComponent } from './components/patient/patient-form/patient-form.component';

// Business Services
import { MessageService } from './services/message.service';
import { PatientService } from './services/patient.service';
import { DoctorService } from './services/doctor.service';
import { DoctorsPatientComponent } from './components/patient/patient-form/doctors-patient/doctors-patient.component';
import { DoctorFormComponent } from './components/doctor/doctor-form/doctor-form.component';
import { PatientsDoctorComponent } from './components/doctor/doctor-form/patients-doctor/patients-doctor.component';

@NgModule({
  declarations: [
    AppComponent,
    PatientListComponent,
    PatientFormComponent,
    DoctorsPatientComponent,
    DoctorFormComponent,
    PatientsDoctorComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    MessageService,
    PatientService,
    DoctorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
