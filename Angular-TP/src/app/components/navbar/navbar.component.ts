import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AgregarEditarEmpleadoComponent } from '../agregar-editar-empleado/agregar-editar-empleado.component';
import { ListarEmpleadosComponent } from '../listar-empleados/listar-empleados.component';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent {
  constructor(private cuadroDialogo: MatDialog) {}
}
