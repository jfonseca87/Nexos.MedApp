import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { PatientService } from 'src/app/services/patient.service';
import { Patient } from 'src/app/models/patient';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-patient-form',
  templateUrl: './patient-form.component.html',
  styleUrls: ['./patient-form.component.css']
})
export class PatientFormComponent implements OnInit {
  patientForm: FormGroup;
  patient: Patient;
  patientId = 0;
  patientName = 'Nuevo';
  textoBoton = 'Guardar';

  constructor(private fb: FormBuilder,
              private location: Location,
              private patientService: PatientService,
              private route: ActivatedRoute,
              private message: MessageService) { }

  ngOnInit() {
    this.createForm();
    this.patientId = Number(this.route.snapshot.paramMap.get('id'));

    if (this.patientId > 0) {
      this.getPatient();
    }
  }

  createForm() {
    this.patientForm = this.fb.group({
      socialSecurityNumber: ['', Validators.required],
      name: ['', Validators.required],
      zipCode: [''],
      address: [''],
      phoneNumber: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  setValuesEdit(patient: Patient) {
    this.patientForm.controls.socialSecurityNumber.setValue(patient.socialSecurityNumber);
    this.patientForm.controls.name.setValue(patient.name);
    this.patientForm.controls.zipCode.setValue(patient.zipCode);
    this.patientForm.controls.address.setValue(patient.address);
    this.patientForm.controls.phoneNumber.setValue(patient.phoneNumber);
    this.patientForm.controls.email.setValue(patient.email);
  }

  getPatient() {
    this.patientService.getPatient(this.patientId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.patient = res.response;
          this.patientName = this.patient.name;
          this.cambiarTextoBoton('Actualizar');
          this.setValuesEdit(this.patient);
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

  savePatient() {
    const patient = this.patientForm.value;

    if (this.patientId > 0) {
      this.updatePatient(patient);
    } else {
      this.createPatient(patient);
    }
  }

  createPatient(patient: Patient) {
    this.patientService.createPatient(patient).subscribe(
      res => {
        if (res.httpResponse === 201) {
          this.patient = res.response;
          this.patientId = this.patient.patientId;
          this.patientName = this.patient.name;
          this.cambiarTextoBoton('Actualizar');
          this.message.showMessage('success', 'Se ha creado exitosamente el paciente');
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

  updatePatient(patient: Patient) {
    patient.patientId = this.patientId;

    this.patientService.updatePatient(patient).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.message.showMessage('success', 'Se ha modificado exitosamente el paciente');
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

  pageBack() {
    this.location.back();
  }

  cambiarTextoBoton(nuevoTexto: string) {
    this.textoBoton = nuevoTexto;
  }
}
