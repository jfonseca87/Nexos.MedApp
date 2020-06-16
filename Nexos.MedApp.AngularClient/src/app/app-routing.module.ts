import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PatientListComponent } from './components/patient/patient-list/patient-list.component';
import { PatientFormComponent } from './components/patient/patient-form/patient-form.component';
import { DoctorFormComponent } from './components/doctor/doctor-form/doctor-form.component';


const routes: Routes = [
  { path: 'doctor', component: DoctorFormComponent },
  { path: 'patients', component: PatientListComponent },
  { path: 'patient', component: PatientFormComponent },
  { path: 'patient/:id', component: PatientFormComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
