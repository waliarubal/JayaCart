import { Routes, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';
import { NotFoundComponent } from '@app/not-found/not-found.component';
import { DashboardComponent } from '@app/dashboard/dashboard.component';
import { AccountsComponent } from '@app/user-account/accounts/accounts.component';
import { AccountComponent } from '@app/user-account/account/account.component';
import { SidebarItem } from '@models/sidebar-item.model';
import { AuthGuardService } from '@services/auth-guard.service';
import { LoginComponent } from '@app/user-account/login/login.component';
import { ArticlesComponent } from '@app/article/articles/articles.component';
import { CategoriesComponent } from '@app/article/categories/categories.component';
import { CategoryComponent } from '@app/article/category/category.component';

const APP_ROUTES: Routes = [
    {
        path: 'Dashboard',
        data: { Label: "Dashboard", IconClass: "fas fa-chart-line" },
        component: DashboardComponent,
        canActivate: [AuthGuardService]
    },
    {
        path: 'Articles',
        data: { Label: 'Articles', IconClass: 'fas fa-boxes' },
        canActivate: [AuthGuardService],
        children: [
            {
                path: '',
                data: { Label: "Manage Articles", IconClass: "fas fa-box" },
                component: ArticlesComponent
            },
            {
                path: 'Categories',
                data: { Label: "Manage Categories", IconClass: "fas fa-tags" },
                component: CategoriesComponent
            },
            { path: 'Categories/New', component: CategoryComponent },
            { path: 'Categories/Edit/:Code', component: CategoryComponent }
        ]
    },
    {
        path: 'UserAccounts',
        data: { Label: "User Accounts", IconClass: "fas fa-users" },
        canActivate: [AuthGuardService],
        children: [
            {
                path: '',
                data: { Label: "Manage Users", IconClass: "fas fa-user-friends" },
                component: AccountsComponent
            },
            { path: 'New', component: AccountComponent },
            { path: 'Edit/:PhoneNumber', component: AccountComponent },
            {
                path: 'Profile',
                data: { Label: 'My Profile', IconClass: 'fas fa-user' },
                component: AccountComponent
            }
        ]
    },
    { path: 'Login', component: LoginComponent },
    { path: '', redirectTo: '/Dashboard', pathMatch: 'full' },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(APP_ROUTES)],
    exports: [RouterModule]
})
export class RoutesModule {

    static GetSidebarItems(): SidebarItem[] {
        let items: SidebarItem[] = [];

        for (let route of APP_ROUTES) {
            if (!route.data)
                continue;

            let item = new SidebarItem(route.data.Label, route.data.IconClass);
            if (route.children && route.children.length > 0) {
                for (let subRoute of route.children) {
                    if (!subRoute.data)
                        continue;

                    let subItem = new SidebarItem(subRoute.data.Label, subRoute.data.IconClass);
                    subItem.RouterLink = `/${route.path}/${subRoute.path}`
                    item.Items.push(subItem);
                }
            } else
                item.RouterLink = `/${route.path}`;

            items.push(item);
        }

        return items;
    }

}