import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { Patient } from 'src/app/models/patient';
import { PatientService } from 'src/app/services/patient.service';
import { PatientDoctorService } from 'src/app/services/patient-doctor.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-patients-doctor',
  templateUrl: './patients-doctor.component.html',
  styleUrls: ['./patients-doctor.component.css']
})
export class PatientsDoctorComponent implements OnInit, OnChanges {
  @Input() doctorId = 0;
  patients: Patient[];
  patientsDrop: Patient[];
  patientIdSelected = 0;

  constructor(private patientService: PatientService,
              private patientDoctorService: PatientDoctorService,
              private message: MessageService) { }

  ngOnInit() {
    this.getDoctors();
  }

  ngOnChanges() {
    if (this.doctorId > 0) {
      this.getPatientsByDoctor();
    }
  }

  getDoctors() {
    this.patientService.getPatients().subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.patientsDrop = res.response;
        } else {
          console.error(res.error);
        }
      },
      error => console.error(error)
    );
  }

  getPatientsByDoctor() {
    this.patientService.getPatientsByDoctor(this.doctorId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.patients = res.response;
          this.verifyDoctorList();
          this.patientIdSelected = 0;
        } else {
          console.error(res.error);
        }
      },
      error => console.error(error)
    );
  }

  savePatientDoctor() {
    const record = {
      PatientId: this.patientIdSelected,
      DoctorId: this.doctorId
    };

    this.patientDoctorService.createRecord(record).subscribe(
      res => {
        if (res.httpResponse === 201) {
          this.getPatientsByDoctor();
          this.message.showMessage('success', 'Se ha agregado exitosamente el paciente a la lista');
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
    this.patientIdSelected = index > 0 ? this.patientsDrop[(index - 1)].patientId : 0;
  }

  verifyDoctorList() {
    for (const patient of this.patients) {
      this.patientsDrop = this.patientsDrop.filter(x => x.patientId !== patient.patientId);
    }
  }
}
