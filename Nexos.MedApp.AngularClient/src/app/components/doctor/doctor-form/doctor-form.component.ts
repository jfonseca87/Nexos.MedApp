import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { Doctor } from 'src/app/models/doctor';
import { DoctorService } from 'src/app/services/doctor.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-doctor-form',
  templateUrl: './doctor-form.component.html',
  styleUrls: ['./doctor-form.component.css']
})
export class DoctorFormComponent implements OnInit {
  doctorForm: FormGroup;
  doctor: Doctor;
  doctorName = 'Nuevo';
  textoBoton = 'Guardar';

  constructor(private fb: FormBuilder,
              private location: Location,
              private doctorService: DoctorService,
              private message: MessageService) { }

  ngOnInit() {
    this.createForm();
  }

  createForm() {
    this.doctorForm = this.fb.group({
      credentialNumber: ['', Validators.required],
      name: ['', Validators.required],
      hospitalName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  saveDoctor() {
    const doctor = this.doctorForm.value;
    this.doctorService.createDoctor(doctor).subscribe(
      res => {
        if (res.httpResponse === 201) {
          this.doctor = res.response;
          this.doctorName = this.doctor.name;
          this.message.showMessage('success', 'Se ha creado exitosamente el doctor');
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
