import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesCalificacionComponent } from './detalles-calificacion.component';

describe('DetallesCalificacionComponent', () => {
  let component: DetallesCalificacionComponent;
  let fixture: ComponentFixture<DetallesCalificacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetallesCalificacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetallesCalificacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
