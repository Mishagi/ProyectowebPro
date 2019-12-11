import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Calificaciones } from "../../../models/calificaciones";
import { Docente }from "../../../models/docente"
import { ActivatedRoute } from '@angular/router';
import { CalificadorService } from '../../../services/calificador.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalDatosDocenteComponent } from '../modal-datos-docente/modal-datos-docente.component';
import {
  DocenteServiceService
} from '../../../services/docente.service';

@Component({
  selector: 'app-modal-asignar-par',
  templateUrl: './modal-asignar-par.component.html',
  styleUrls: ['./modal-asignar-par.component.css']
})
export class ModalAsignarParComponent implements OnInit {

  calificacion: Calificaciones;

  constructor(private docenteservice: DocenteServiceService, private calificadorService: CalificadorService) { }

  @Input() docente: Docente;

  docentes: Docente[];
  ngOnInit() {
    this.getAll();
    this.calificacion = new Calificaciones();
  }

  getAll() {
    this.docenteservice.getAll().subscribe(docentes => this.docentes = docentes);
  }

  update(par: string) {
    this.calificadorService.get(this.docente.identificacion).subscribe(aux => {
      //alert(JSON.stringify(aux));
      this.calificacion = aux;

      this.calificacion.id_Par = par;
      this.calificadorService.update(this.calificacion)
        .subscribe();
        setTimeout(()=> {
          location.reload();
        },1300)
    });
  }
}
