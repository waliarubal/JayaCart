import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { RoutesModule } from './shared/routes.module';
import { AppComponent } from './app.component';
import { NotFoundModule } from './not-found/not-found.module';
import { UserAccountModule } from './user-account/user-account.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { UserAccountService } from '@services/user-account.service';
import { AuthGuardService } from '@services/auth-guard.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RoutesModule,
    NgbModule,
    NotFoundModule,
    DashboardModule,
    UserAccountModule,
  ],
  providers: [
    UserAccountService,
    AuthGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
