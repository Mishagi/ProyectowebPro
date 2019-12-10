import { Component, OnInit } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { AuthService } from '../../services/auth.service';
import { LoginService } from '../../services/login.service';
import { ActivatedRoute } from'@angular/router';
import { Login } from 'src/app/models/login';

declare var JQuery:any;
declare var $:any;

@Component({
  selector: 'app-barra-de-navegacion',
  templateUrl: './barra-de-navegacion.component.html',
  styleUrls: ['./barra-de-navegacion.component.css'],
  animations: [
    trigger('slide', [
      state('up', style({ height: 0 })),
      state('down', style({ height: '*' })),
      transition('up <=> down', animate(200))
    ])
  ]
})

export class BarraDeNavegacionComponent implements OnInit {
   
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  constructor(private authorizeService: AuthService, private authService: AuthService, private loginService:LoginService, private route: ActivatedRoute) { }

  log:Login;
  objeto:Login;

  getUsuario(objeto:Login): void {

    this.loginService.getUsuario(objeto.usuario).subscribe(aux => {
      //alert(JSON.stringify(aux));
      this.log = aux;
      alert(JSON.stringify(this.log.clave));
      alert(JSON.stringify(objeto.clave));

      if(objeto.clave === this.log.clave){
        this.authService.login(this.log.usuario, this.log.clave ,this.log.rol);
      }else{
        alert("Contraseña o Usuario Incorrecto");
      }
    });
  }

  sw=false;

  logout() {
    this.authService.logout();
    this.sw=false;
  }

  userName(): string {
    return this.authorizeService.getUserName();
  }
  
  public isAuthenticated(): boolean
  {
    let isAuth=this.authorizeService.isAuthenticated();
    if(isAuth && !this.sw)
    {
      this.sw=true;
      setTimeout(()=> {
        this.activar();
      },1300)
    }
    return isAuth;
  }


  isAuthenticatedRole(role: string): boolean {
    
    if (this.isAuthenticated && role != null ) {
      return this.authorizeService.hasRole(role);
    }
  }

  public activar(){
    
    $(".sidebar-dropdown > a").click(function() {
      $(".sidebar-submenu").slideUp(200);
      if (
        $(this)
          .parent()
          .hasClass("active")
      ) {
        $(".sidebar-dropdown").removeClass("active");
        $(this)
          .parent()
          .removeClass("active");
      } else {
        $(".sidebar-dropdown").removeClass("active");
        $(this)
          .next(".sidebar-submenu")
          .slideDown(200);
        $(this)
          .parent()
          .addClass("active");
      }
    });
    
    $("#close-sidebar").click(function() {
      $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function() {
      $(".page-wrapper").addClass("toggled");
    });
   
  }

  ngOnInit() { 
    this.activar();
    this.objeto = new Login();
  }

}
