import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppRoutes } from './shared/routes';
import { AppComponent } from './app.component';
import { NotFoundModule } from './not-found/not-found.module';
import { UserAccountModule } from './user-account/user-account.module';
import { DashboardModule } from './dashboard/dashboard.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(AppRoutes, { enableTracing: true }),
    NgbModule,
    NotFoundModule,
    DashboardModule,
    UserAccountModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
