import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RealiazarCalificacionComponent } from './realiazar-calificacion.component';

describe('RealiazarCalificacionComponent', () => {
  let component: RealiazarCalificacionComponent;
  let fixture: ComponentFixture<RealiazarCalificacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RealiazarCalificacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RealiazarCalificacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
