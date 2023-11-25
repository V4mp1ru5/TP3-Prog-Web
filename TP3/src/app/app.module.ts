import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { VoyagesComponent } from './voyages/voyages.component';
import { VoyageComponent } from './voyage/voyage.component';
import {FormsModule} from "@angular/forms";
import {RouterModule, RouterOutlet} from "@angular/router";
import {NgOptimizedImage} from "@angular/common";
import {MonInterceptorInterceptor} from "./mon-interceptor.interceptor";

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    VoyagesComponent,
    VoyageComponent


  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterOutlet,
    FormsModule,

    RouterModule.forRoot([
      {path: '', redirectTo: '/voyages', pathMatch: 'full'},
      {path: 'voyages', component: VoyagesComponent},
      {path: 'voyage/:Id', component: VoyageComponent},
      {path: 'login', component: LoginComponent},
      {path: 'register', component: RegisterComponent}
    ]),
    NgOptimizedImage
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: MonInterceptorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
