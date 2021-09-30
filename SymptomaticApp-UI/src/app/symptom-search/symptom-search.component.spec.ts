import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SymptomSearchComponent } from './symptom-search.component';

describe('SymptomSearchComponent', () => {
  let component: SymptomSearchComponent;
  let fixture: ComponentFixture<SymptomSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SymptomSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SymptomSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
