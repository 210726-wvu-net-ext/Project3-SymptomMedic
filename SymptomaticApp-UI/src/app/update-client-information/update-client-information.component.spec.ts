import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateClientInformationComponent } from './update-client-information.component';

describe('UpdateClientInformationComponent', () => {
  let component: UpdateClientInformationComponent;
  let fixture: ComponentFixture<UpdateClientInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateClientInformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateClientInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
