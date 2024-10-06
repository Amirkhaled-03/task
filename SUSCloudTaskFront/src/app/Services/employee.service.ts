import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../interfaces/employee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private _httpClient: HttpClient) {}

  baseUrl: string = 'https://localhost:7287/api/';

  getAllEmployees(): Observable<any> {
    return this._httpClient.get(`${this.baseUrl}Employees`);
  }

  addEmployee(employee: Employee): Observable<any> {
    return this._httpClient.post(`${this.baseUrl}Employees`, employee);
  }

  editEmployee(employee: Employee): Observable<any> {
    return this._httpClient.put(`${this.baseUrl}Employees`, employee);
  }

  deleteEmployee(id: number): Observable<any> {
    return this._httpClient.delete(`${this.baseUrl}Employees?id=${id}`);
  }

  getEmployee(id: number): Observable<any> {
    return this._httpClient.get(`${this.baseUrl}Employees/id?id=${id}`);
  }
}
