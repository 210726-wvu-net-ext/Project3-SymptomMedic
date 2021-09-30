import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateDoctorInformationComponent } from './update-doctor-information.component';

describe('UpdateDoctorInformationComponent', () => {
  let component: UpdateDoctorInformationComponent;
  let fixture: ComponentFixture<UpdateDoctorInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateDoctorInformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateDoctorInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
