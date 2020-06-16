import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from '../models/patient';
import { environment } from 'src/environments/environment';
import { ReponseMessage  } from '../models/response-message';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private client: HttpClient) { }

  getPatients() {
    return this.client.get<ReponseMessage>(`${environment.baseUrl}/patient`);
  }

  getPatient(id: number) {
    return this.client.get<ReponseMessage>(`${environment.baseUrl}/patient/${id}`);
  }

  getPatientsByDoctor(idDoctor: number) {
    return this.client.get<ReponseMessage>(`${environment.baseUrl}/patient/patientsByDoctor/${idDoctor}`);
  }

  createPatient(patient: Patient) {
    return this.client.post<ReponseMessage>(`${environment.baseUrl}/patient`, patient);
  }

  updatePatient(patient: Patient) {
    return this.client.put<ReponseMessage>(`${environment.baseUrl}/patient`, patient);
  }

  deletePatient(idPatient: number) {
    return this.client.delete<ReponseMessage>(`${environment.baseUrl}/patient/${idPatient}`);
  }
}
