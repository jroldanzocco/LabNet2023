import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmpleadoService } from 'src/app/services/empleado.service';
import { AgregarEditarEmpleadoComponent } from '../agregar-editar-empleado/agregar-editar-empleado.component';
import { Employee } from 'src/app/models/employee';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];

@Component({
  selector: 'app-listar-empleados',
  templateUrl: './listar-empleados.component.html',
  styleUrls: ['./listar-empleados.component.css'],
})
export class ListarEmpleadosComponent implements OnInit {
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;

  public listaEmployee: Array<Employee> = [];

  constructor(
    private cuadroDialogo: MatDialog,
    private _empService: EmpleadoService
  ) {}

  ngOnInit(): void {
    this.getEmployees();
  }

  openAddEmployee() {
    this.cuadroDialogo.open(AgregarEditarEmpleadoComponent);
  }

  getEmployees() {
    this._empService.getEmployee().subscribe({
      next: (r) => {
        this.listaEmployee = r;
        console.log(r);
      },
    });
  }
}
