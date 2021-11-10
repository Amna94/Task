import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CityDetailsComponent } from './city-details/city-details.component';
import { CityDetailFormComponent } from './city-details/city-detail-form/city-detail-form.component';
import { HttpClientModule } from '@angular/common/http';
import { CountryDetailsComponent } from './country-details/country-details.component';
import { CountryDetailFormComponent } from './country-details/country-detail-form/country-detail-form.component';
import { RoleDetailsComponent } from './role-details/role-details.component';
import { RoleDetailFormComponent } from './role-details/role-detail-form/role-detail-form.component';
import { PermissionDetailsComponent } from './permission-details/permission-details.component';
import { PermissionDetailFormComponent } from './permission-details/permission-detail-form/permission-detail-form.component';
import { RpDetailsComponent } from './rp-details/rp-details.component';
import { RpDetailFormComponent } from './rp-details/rp-detail-form/rp-detail-form.component';
import { UsersDetailsComponent } from './users-details/users-details.component';
import { UsersDetailFormComponent } from './users-details/users-detail-form/users-detail-form.component';

@NgModule({
  declarations: [
    AppComponent,
    CityDetailsComponent,
    CityDetailFormComponent,
    CountryDetailsComponent,
    CountryDetailFormComponent,
    RoleDetailsComponent,
    RoleDetailFormComponent,
    PermissionDetailsComponent,
    PermissionDetailFormComponent,
    RpDetailsComponent,
    RpDetailFormComponent,
    UsersDetailsComponent,
    UsersDetailFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
