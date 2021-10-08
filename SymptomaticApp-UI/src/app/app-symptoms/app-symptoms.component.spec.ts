import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppSymptomsComponent } from './app-symptoms.component';

describe('AppSymptomsComponent', () => {
  let component: AppSymptomsComponent;
  let fixture: ComponentFixture<AppSymptomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppSymptomsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppSymptomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
