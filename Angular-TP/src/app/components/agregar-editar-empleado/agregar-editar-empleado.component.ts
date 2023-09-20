import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EmpleadoService } from 'src/app/services/empleado.service';

@Component({
  selector: 'app-agregar-editar-empleado',
  templateUrl: './agregar-editar-empleado.component.html',
  styleUrls: ['./agregar-editar-empleado.component.css'],
})
export class AgregarEditarEmpleadoComponent implements OnInit {
  employeeForm: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private _empService: EmpleadoService,
    private dialogRef: MatDialogRef<AgregarEditarEmpleadoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.employeeForm = this._formBuilder.group({
      FirstName: [
        '',
        this.crearValidacion(2, 10, true, /^[A-Za-z]+( [A-Za-z]+)*$/),
      ],
      LastName: [
        '',
        this.crearValidacion(2, 20, true, /^[A-Za-z]+( [A-Za-z]+)*$/),
      ],
      Title: [
        '',
        this.crearValidacion(2, 30, true, /^[A-Za-z]+( [A-Za-z]+)*$/),
      ],
    });
  }

  crearValidacion(
    minLength: number,
    maxLength: number,
    requerido: boolean,
    regex?: RegExp
  ) {
    const validado = [];
    if (requerido) {
      validado.push(Validators.required);
    }
    validado.push(Validators.minLength(minLength));
    validado.push(Validators.maxLength(maxLength));
    if (regex) {
      validado.push(Validators.pattern(regex));
    }
    return validado;
  }
  ngOnInit(): void {
    this.employeeForm.patchValue(this.data);
  }
  formSubmit() {
    if (this.employeeForm.valid) {
      if (this.data) {
        this._empService
          .updateEmployee(this.data.Id, this.employeeForm.value)
          .subscribe({
            next: (e) => {
              alert('Usuario modificado correctamente');
              this.dialogRef.close(true);
            },
            error: console.log,
          });
      } else {
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
}
