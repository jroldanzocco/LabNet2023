import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class EmpleadoService {
  private apiUrl: string = 'https://localhost:44395/api/';
  private endPoint: string = 'employee/';
  constructor(private http: HttpClient) {}

  public addEmployee(empleado: Employee): Observable<any> {
    let completeUrl = this.apiUrl + this.endPoint;
    return this.http.post(completeUrl, empleado);
  }
  public getEmployee(): Observable<Array<Employee>> {
    let completeUrl = this.apiUrl + this.endPoint;
    return this.http.get<Array<Employee>>(completeUrl);
  }
  public deleteEmployee(id: number): Observable<any> {
    let completeUrl = this.apiUrl + this.endPoint;
    return this.http.delete(`${completeUrl}${id}`);
  }
}
