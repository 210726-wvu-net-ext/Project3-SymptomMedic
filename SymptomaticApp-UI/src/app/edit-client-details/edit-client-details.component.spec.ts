import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditClientDetailsComponent } from './edit-client-details.component';

describe('EditClientDetailsComponent', () => {
  let component: EditClientDetailsComponent;
  let fixture: ComponentFixture<EditClientDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditClientDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditClientDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
