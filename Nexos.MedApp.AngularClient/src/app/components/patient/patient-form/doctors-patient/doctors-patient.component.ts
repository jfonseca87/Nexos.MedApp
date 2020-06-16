import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { DoctorService } from 'src/app/services/doctor.service';
import { Doctor } from 'src/app/models/doctor';
import { PatientDoctorService } from 'src/app/services/patient-doctor.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-doctors-patient',
  templateUrl: './doctors-patient.component.html',
  styleUrls: ['./doctors-patient.component.css']
})
export class DoctorsPatientComponent implements OnInit, OnChanges {
  @Input() patientId = 0;
  doctors: Doctor[];
  doctorsDrop: Doctor[];
  doctorIdSelected = 0;

  constructor(private doctorService: DoctorService,
              private patientDoctorService: PatientDoctorService,
              private message: MessageService) { }

  ngOnInit() {
    this.getDoctors();
  }

  ngOnChanges() {
    if (this.patientId > 0) {
      this.getDoctorByPatient();
    }
  }

  getDoctors() {
    this.doctorService.getDoctors().subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.doctorsDrop = res.response;
        } else {
          this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
          console.error(res.error);
        }
      },
      error => {
        console.error(error);
        this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
      }
    );
  }

  getDoctorByPatient() {
    this.doctorService.getDoctorsByPatient(this.patientId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.doctors = res.response;
          this.verifyDoctorList();
          this.doctorIdSelected = 0;
        } else {
          this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
          console.error(res.error);
        }
      },
      error => {
        console.error(error);
        this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
      }
    );
  }

  savePatientDoctor() {
    const record = {
      PatientId: this.patientId,
      DoctorId: this.doctorIdSelected
    };

    this.patientDoctorService.createRecord(record).subscribe(
      res => {
        if (res.httpResponse === 201) {
          this.getDoctorByPatient();
          this.message.showMessage('success', 'Se ha agregado exitosamente el doctor a la lista');
        } else {
          this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
          console.error(res.error);
        }
      },
      error => {
        console.error(error);
        this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
      }
    );
  }

  getValue(control: any) {
    const index = control.currentTarget.selectedIndex;
    this.doctorIdSelected = index > 0 ? this.doctorsDrop[(index - 1)].doctorId : 0;
  }

  verifyDoctorList() {
    for (const doctor of this.doctors) {
      this.doctorsDrop = this.doctorsDrop.filter(x => x.doctorId !== doctor.doctorId);
    }
  }
}
