import { Component, OnInit } from '@angular/core';
import { PreguntaService } from '../../services/pregunta.service';
import { Pregunta } from '../../models/pregunta';
import { CalificadorService } from '../../services/calificador.service';
import { Calificaciones } from 'src/app/models/calificaciones';


@Component({
  selector: 'app-realiazar-calificacion',
  templateUrl: './realiazar-calificacion.component.html',
  styleUrls: ['./realiazar-calificacion.component.css']
})
export class RealiazarCalificacionComponent implements OnInit {

  preguntas : Pregunta[];
  preguntasActivas : Pregunta[];

  constructor(private preguntaService:PreguntaService,  private calificadorService: CalificadorService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll(){
    this.preguntaService.getActivas().subscribe(preguntas=>this.preguntas=preguntas);
  }

  lll(){
    sessionStorage.getItem('identificacion')
  }

  calificacion: Calificaciones;
  update() {

    
    this.calificadorService.get("800").subscribe(aux => {
      //alert(JSON.stringify(aux));
      this.calificacion = aux;

      this.calificadorService.update(this.calificacion)
        .subscribe();
        setTimeout(()=> {
          location.reload();
        },1300)
    });
  }

}
