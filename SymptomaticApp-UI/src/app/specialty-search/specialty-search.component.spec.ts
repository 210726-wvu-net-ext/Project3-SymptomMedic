import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialtySearchComponent } from './specialty-search.component';

describe('SpecialtySearchComponent', () => {
  let component: SpecialtySearchComponent;
  let fixture: ComponentFixture<SpecialtySearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpecialtySearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialtySearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
