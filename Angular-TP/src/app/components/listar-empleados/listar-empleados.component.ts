import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmpleadoService } from 'src/app/services/empleado.service';
import { AgregarEditarEmpleadoComponent } from '../agregar-editar-empleado/agregar-editar-empleado.component';
import { Employee } from 'src/app/models/employee';

//SweetAlert2
import Swal from 'sweetalert2';

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
    const dialog = this.cuadroDialogo.open(AgregarEditarEmpleadoComponent);
    dialog.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getEmployees();
        }
      },
    });
  }

  openEditEmployee(data: any) {
    const dialog = this.cuadroDialogo.open(AgregarEditarEmpleadoComponent, {
      data,
    });
    dialog.afterClosed().subscribe({
      next: (val) => {
        if (val) {
          this.getEmployees();
        }
      },
    });
  }

  getEmployees() {
    this._empService.getEmployee().subscribe({
      next: (r) => {
        this.dataSource = r;
      },
    });
  }

  deleteEmployee(id: number) {
    Swal.fire({
      title: '¿Estas seguro?',
      text: 'No podras revertir esta accion!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, borrar!',
    }).then((result) => {
      if (result.isConfirmed) {
        this._empService.deleteEmployee(id).subscribe({
          next: () => {
            Swal.fire('Eliminado!', 'El registro fue eliminado.', 'success');
            this.getEmployees();
          },
          error: () => {
            Swal.fire(
              'Error!',
              'No puede eliminarse (Conflicto de referencias).',
              'error'
            );
          },
        });
      }
    });
  }
}
