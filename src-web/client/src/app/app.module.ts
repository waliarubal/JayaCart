import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { UserAccountModule } from './user-account/user-account.module';
import { AccountsComponent } from './user-account/accounts/accounts.component';

const routes: Routes = [
  { path: 'UserAccounts', component: AccountsComponent },
  { path: '', redirectTo: '/Dashboard', pathMatch: 'full' },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes, { enableTracing: true }),
    NgbModule,
    UserAccountModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
