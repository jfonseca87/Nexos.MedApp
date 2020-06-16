import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReponseMessage } from '../models/response-message';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientDoctorService {

  constructor(private client: HttpClient) { }

  createRecord(data: any) {
    return this.client.post<ReponseMessage>(`${environment.baseUrl}/PatientDoctor`, data);
  }

}
