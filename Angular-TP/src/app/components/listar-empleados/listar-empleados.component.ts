import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmpleadoService } from 'src/app/services/empleado.service';
import { AgregarEditarEmpleadoComponent } from '../agregar-editar-empleado/agregar-editar-empleado.component';
import { Employee } from 'src/app/models/employee';

@Component({
  selector: 'app-listar-empleados',
  templateUrl: './listar-empleados.component.html',
  styleUrls: ['./listar-empleados.component.css'],
})
export class ListarEmpleadosComponent implements OnInit {
  displayedColumns: string[] = [
    'Id',
    'LastName',
    'FirstName',
    'Title',
    'Action',
  ];
  dataSource: Array<Employee> = [];

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
        this.dataSource = r;
      },
    });
  }

  deleteEmployee(id: number) {
    this._empService.deleteEmployee(id).subscribe({
      next: (e) => {
        alert('Empleado borrado');
        this.getEmployees();
      },
      error: console.log,
    });
  }
}
