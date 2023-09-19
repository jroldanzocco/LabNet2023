import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Employee } from '../models/employee';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class EmpleadoService {
  private apiUrl: string = 'https://localhost:44395/api/employee/';

  constructor(private http: HttpClient) {}

  public addEmployee(empleado: Employee): Observable<any> {
    return this.http.post(this.apiUrl, empleado);
  }
  public getEmployee(): Observable<Array<Employee>> {
    return this.http.get<Array<Employee>>(this.apiUrl);
  }
  public deleteEmployee(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}${id}`);
  }

  public updateEmployee(id: number, empleado: Employee): Observable<any> {
    empleado.Id = id;
    return this.http.put(`${this.apiUrl}`, empleado);
  }
}
