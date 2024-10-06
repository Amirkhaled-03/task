import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'src/app/Services/employee.service';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { Employee } from 'src/app/interfaces/employee';
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
  providers: [DatePipe],
})
export class EmployeeListComponent implements OnInit {
  employees: Employee[] = [];

  constructor(
    private _employeeService: EmployeeService,
    private datePipe: DatePipe,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this._employeeService.getAllEmployees().subscribe({
      next: (response) => {
        if (response.message === 'Success') {
          this.employees = response.data.map((employee: any) => ({
            ...employee,
            createdDate: this.datePipe.transform(
              employee.createdDate,
              ' dd/MM/yyyy'
            ),
            startDate: this.datePipe.transform(
              employee.startDate,
              ' dd/MM/yyyy'
            ),
            endDate: this.datePipe.transform(employee.endDate, ' dd/MM/yyyy'),
          }));
        }
      },
      error: (err) => {
        console.error('Error fetching employees:', err);
      },
    });
  }

  deleteEmployee(id: number) {
    this._employeeService.deleteEmployee(id).subscribe({
      next: (response) => {
        if (response.message === 'Success') {
          this.ngOnInit();
        }
      },
    });
  }

  editEmployee(id: number): void {
    this._router.navigate(['/EditEmployee', id]);
  }

  getEmployee(id: number): void {
    this._router.navigate(['/EmployeeDetails', id]);
  }
}
