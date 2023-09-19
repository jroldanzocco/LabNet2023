import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { EmpleadoService } from 'src/app/services/empleado.service';

@Component({
  selector: 'app-agregar-editar-empleado',
  templateUrl: './agregar-editar-empleado.component.html',
  styleUrls: ['./agregar-editar-empleado.component.css'],
})
export class AgregarEditarEmpleadoComponent {
  employeeForm: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private _empService: EmpleadoService,
    private dialogRef: MatDialogRef<AgregarEditarEmpleadoComponent>
  ) {
    this.employeeForm = this._formBuilder.group({
      FirstName: '',
      LastName: '',
      Title: '',
    });
  }

  formSubmit() {
    if (this.employeeForm.valid) {
      this._empService.addEmployee(this.employeeForm.value).subscribe({
        next: (e) => {
          alert('Usuario agregado correctamente');
          this.dialogRef.close(true);
        },
        error: console.log,
      });
    }
  }
}
