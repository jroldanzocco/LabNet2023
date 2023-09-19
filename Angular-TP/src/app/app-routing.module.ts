import { literalMap } from '@angular/compiler';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListarEmpleadosComponent } from './components/listar-empleados/listar-empleados.component';

const routes: Routes = [
  {
    path: '',
    component: ListarEmpleadosComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
