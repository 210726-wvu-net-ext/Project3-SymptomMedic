import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginDoctorComponent } from './logindoctor.component';

describe('LoginComponent', () => {
  let component: LoginDoctorComponent;
  let fixture: ComponentFixture<LoginDoctorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginDoctorComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginDoctorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
