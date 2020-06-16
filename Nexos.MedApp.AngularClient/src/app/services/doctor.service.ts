import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doctor } from '../models/doctor';
import { environment } from 'src/environments/environment';
import { ReponseMessage } from '../models/response-message';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private client: HttpClient) { }

  getDoctors() {
    return this.client.get<ReponseMessage>(`${environment.baseUrl}/doctor`);
  }

  getDoctorsByPatient(patientId: number) {
    return this.client.get<ReponseMessage>(`${environment.baseUrl}/doctor/doctorsByPatient/${patientId}`);
  }

  createDoctor(doctor: Doctor) {
    return this.client.post<ReponseMessage>(`${environment.baseUrl}/doctor`, doctor);
  }
}
