import { Component, OnInit, OnDestroy } from '@angular/core';
import { PatientService } from 'src/app/services/patient.service';
import { Patient } from 'src/app/models/patient';
import { ReponseMessage } from 'src/app/models/response-message';
import { Router } from '@angular/router';
import { MessageService } from 'src/app/services/message.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit, OnDestroy {
  messageSubscription: Subscription;
  response: ReponseMessage;
  patients: Patient[];
  patientId = 0;
  codeMessage = {
    delete: 1
  };

  constructor(private patientService: PatientService,
              private route: Router,
              private message: MessageService) { }

  ngOnInit() {
    this.messageSubscription = this.message.getActionConfirm().subscribe(
      res => {
        switch (res) {
          case this.codeMessage.delete:
            this.deletePatient();
            break;
          default:
            break;
        }
      }
    );

    this.getData();
  }

  ngOnDestroy() {
    this.messageSubscription.unsubscribe();
  }

  getData() {
    this.patientService.getPatients().subscribe(
      res => {
        this.response = res;

        if (this.response.httpResponse === 200) {
          this.patients = this.response.response;
        } else {
          console.error(this.response.error);
        }
      },
      error => console.error(error)
    );
  }

  patientEdit(patientId: number) {
    this.route.navigate(['/patient', { id: patientId }]);
  }

  confirmDelete(id: number) {
    this.patientId = id;
    this.message.showConfirm('Desea borrar al paciente?', 'Eliminar', this.codeMessage.delete);
  }

  deletePatient() {
    this.patientService.deletePatient(this.patientId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.getData();
          this.message.showMessage('success', 'Se ha eliminado exitosamente el paciente');
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
}
