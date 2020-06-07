import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

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

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    UserManagementAdminComponent,
    UserManagementSettlerComponent,
    NotFoundComponent,
    VisitsManagementSettlerComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule,
    FontAwesomeModule,
    ReactiveFormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: InvalidSessionInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
