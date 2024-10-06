import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './Component/employee-list/employee-list.component';
import { EditEmployeeComponent } from './Component/edit-employee/edit-employee.component';
import { EmployeeAddComponent } from './Component/employee-add/employee-add.component';
import { EmployeeDetailsComponent } from './Component/employee-details/employee-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'AllEmployees', pathMatch: 'full' },
  { path: 'AllEmployees', component: EmployeeListComponent },
  { path: 'EditEmployee/:id', component: EditEmployeeComponent },
  { path: 'AddEmployee', component: EmployeeAddComponent },
  { path: 'EmployeeDetails/:id', component: EmployeeDetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
