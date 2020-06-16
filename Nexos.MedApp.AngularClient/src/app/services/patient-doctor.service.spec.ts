import { TestBed } from '@angular/core/testing';

import { PatientDoctorService } from './patient-doctor.service';

describe('PatientDoctorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PatientDoctorService = TestBed.get(PatientDoctorService);
    expect(service).toBeTruthy();
  });
});
