import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {
  FormGroup,
  FormControl,
  FormBuilder,
  Validators,
} from '@angular/forms';
import { EmployeeService } from 'src/app/Services/employee.service';
@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css'],
})
export class EmployeeAddComponent implements OnInit {
  constructor(
    private _employeeService: EmployeeService,
    private _router: Router
  ) {}

  AddEmployeeForm: FormGroup = new FormGroup({
    Name: new FormControl('', [Validators.required, Validators.minLength(5)]),
    Position: new FormControl('', [Validators.required]),
    Department: new FormControl('', [Validators.required]),
    Salary: new FormControl('', [Validators.required]),
    Address: new FormControl('', [Validators.required]),
    Project: new FormControl('', [Validators.required]),
    StartDate: new FormControl('', [Validators.required]),
    EndDate: new FormControl('', [Validators.required]),
  });
  ngOnInit(): void {}
  onSubmit() {
    if (this.AddEmployeeForm.valid) {
      console.log();
      this._employeeService.addEmployee(this.AddEmployeeForm.value).subscribe({
        next: (response) => {
          console.log(response);
          if (response.message === 'Success') {
            this._router.navigate(['/AllEmployees']);
          }
        },
      });
    } else {
      console.log('Form is not valid');
    }
  }
}
