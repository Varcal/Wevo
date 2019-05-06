import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from "@angular/common/http";


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientePageComponent } from './pages/cliente-page/cliente-page.component';
import { HomePageComponent } from './pages/home-page/home-page.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { ClientListComponent } from './components/client-list/client-list.component';

import {PhonePipe} from '../app/utils/phone.pipe';
import {SexoPipe} from '../app/utils/sexo.pipe';


@NgModule({
  declarations: [
    AppComponent,
    ClientePageComponent,
    HomePageComponent,
    HeaderComponent,
    FooterComponent,
    ClientListComponent,
    PhonePipe,
    SexoPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
