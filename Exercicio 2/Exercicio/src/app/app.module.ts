import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import 'rxjs/add/operator/map';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { ListagemComponent } from './listagem/listagem.component';
import { HttpModule } from '@angular/http';
import { RepositoriosComponent } from './repositorios/repositorios.component';
import { FormsModule } from "@angular/forms";

@NgModule({
  imports: [BrowserModule, HttpModule, FormsModule],
  declarations: [AppComponent, LoginComponent, UsuarioComponent, ListagemComponent, RepositoriosComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
