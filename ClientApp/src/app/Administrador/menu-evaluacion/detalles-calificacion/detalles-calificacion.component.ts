import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Calificaciones } from "../../../models/calificaciones";
import { Docente }from "../../../models/docente"
import { ActivatedRoute } from '@angular/router';
import { CalificadorService } from '../../../services/calificador.service';
import { Location } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalAsignarJefeComponent} from "../../Modals/modal-asignar-jefe/modal-asignar-jefe.component";
import { ModalAsignarParComponent} from "../../Modals/modal-asignar-par/modal-asignar-par.component";

@Component({
  selector: 'app-detalles-calificacion',
  templateUrl: './detalles-calificacion.component.html',
  styleUrls: ['./detalles-calificacion.component.css']
})
export class DetallesCalificacionComponent implements OnInit {

  calificaciones : Calificaciones[];
  constructor( private calificadorService: CalificadorService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.calificadorService.getAll().subscribe(calificacion => this.calificaciones = calificacion);
  }

}
