import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonComponent } from './Component/button/button.component';
import { EmployeeListComponent } from './Component/employee-list/employee-list.component';
import { NavbarComponent } from './Component/navbar/navbar.component';
import { EditEmployeeComponent } from './Component/edit-employee/edit-employee.component';
import { EmployeeDetailsComponent } from './Component/employee-details/employee-details.component';
import { EmployeeAddComponent } from './Component/employee-add/employee-add.component';
import { IconComponent } from './Component/icon/icon.component';

@NgModule({
  declarations: [
    AppComponent,
    ButtonComponent,
    EmployeeListComponent,
    NavbarComponent,
    EditEmployeeComponent,
    EmployeeDetailsComponent,
    EmployeeAddComponent,
    IconComponent,
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
