import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/interfaces/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css'],
})
export class EmployeeDetailsComponent implements OnInit {
  employeeId?: number;
  employee?: Employee;

  constructor(
    private _route: ActivatedRoute,
    private _employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    this._route.params.subscribe((params) => {
      this.employeeId = +params['id'];
      this._employeeService.getEmployee(this.employeeId).subscribe({
        next: (respnse) => {
          if (respnse.message === 'Success') {
            this.employee = respnse.data;
            this.populateForm();
          }
        },
      });
    });
  }

  detailsEmployeeForm: FormGroup = new FormGroup({
    employeeID: new FormControl(''),
    Name: new FormControl('', [Validators.required, Validators.minLength(5)]),
    Position: new FormControl('', [Validators.required]),
    Department: new FormControl('', [Validators.required]),
    Salary: new FormControl('', [Validators.required]),
    CreatedDate: new FormControl('', [Validators.required]),
    Address: new FormControl('', [Validators.required]),
    Project: new FormControl('', [Validators.required]),
    StartDate: new FormControl('', [Validators.required]),
    EndDate: new FormControl('', [Validators.required]),
  });

  populateForm(): void {
    this.detailsEmployeeForm.patchValue({
      employeeID: this.employeeId,
      Name: this.employee?.name,
      Position: this.employee?.position,
      Department: this.employee?.department,
      Salary: this.employee?.salary,
      Address: this.employee?.address,
      CreatedDate:this.employee?.createdDate,
      Project: this.employee?.project,
      StartDate: this.employee?.startDate,
      EndDate: this.employee?.endDate,
    });
  }
}
