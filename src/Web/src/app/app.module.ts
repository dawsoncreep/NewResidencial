import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';

import { AppRoutingModule } from './app.routing';

import { LoginComponent } from './Componets/login/login.component';
import { HomeComponent } from './componets/home/home.component';
import { AppComponent } from './componets/main/app.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { InvalidSessionInterceptor } from './helpers/sessionvalidator.interceptor';
import { TokenInterceptor } from './helpers/token.interceptor';
import { UserManagementAdminComponent } from './componets/user-management-admin/user-management-admin.component';
import { UserManagementSettlerComponent } from './componets/user-management-settler/user-management-settler.component';
import { NotFoundComponent } from './componets/not-found/not-found.component';
import { VisitsManagementSettlerComponent } from './componets/visits-management-settler/visits-management-settler.component';
import { UserManagementAdminListComponent } from './componets/user-management-admin-list/user-management-admin-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatNativeDateModule } from '@angular/material/core';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    UserManagementAdminComponent,
    UserManagementSettlerComponent,
    NotFoundComponent,
    VisitsManagementSettlerComponent,
    UserManagementAdminListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatInputModule,
    MatTableModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: InvalidSessionInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
    { provide: LocationStrategy, useClass: HashLocationStrategy}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
