import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Componets/login/login.component';
import { HomeComponent } from './componets/home/home.component';
import { AuthenticationGuard } from './helpers/authentication.guard';
import { UserManagementSettlerComponent } from './componets/user-management-settler/user-management-settler.component';
import { UserManagementAdminComponent } from './componets/user-management-admin/user-management-admin.component';
import { Role } from './Models/role';
import { NotFoundComponent } from './componets/not-found/not-found.component';
import { VisitsManagementSettlerComponent } from './componets/visits-management-settler/visits-management-settler.component';
import { UserManagementAdminListComponent } from './componets/user-management-admin-list/user-management-admin-list.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'myPartners',
    component: UserManagementSettlerComponent,
    canActivate: [AuthenticationGuard],
    data: { roles: [Role.Representative, Role.Settler] }
  },
  {
    path: 'userManagement',
    component: UserManagementAdminComponent,
    canActivate: [AuthenticationGuard],
    data: { roles: [Role.Ceo, Role.Administrator] }
  },
  {
    path: 'myVisits',
    component: VisitsManagementSettlerComponent,
    canActivate: [AuthenticationGuard],
    data: { roles: [Role.Representative, Role.Settler] }
  },
  {
    path: 'userManagementList',
    component: UserManagementAdminListComponent,
    canActivate: [AuthenticationGuard],
    data: { roles: [Role.Ceo, Role.Administrator] }
  },

  // otherwise redirect to not found
  {
    path: '**',
    component: NotFoundComponent,
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);