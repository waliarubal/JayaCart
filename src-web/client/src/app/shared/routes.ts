import { Routes } from "@angular/router";
import { NotFoundComponent } from '../not-found/not-found.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { UserAccountComponent } from '../user-account/user-account.component';

export const AppRoutes: Routes = [
    { path: 'UserAccounts', component: UserAccountComponent },
    { path: 'Dashboard', component: DashboardComponent },
    { path: '', redirectTo: '/Dashboard', pathMatch: 'full' },
    { path: '**', component: NotFoundComponent }
];