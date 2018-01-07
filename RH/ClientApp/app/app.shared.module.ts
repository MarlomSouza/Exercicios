import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { ListaTecnologiaComponent } from './components/lista-tecnologia/lista-tecnologia.component';
import { ListaCandidatoComponent } from './components/lista-candidato/lista-candidato.component';
import { ListaProcessoComponent } from './components/lista-processo/lista-processo.component';
import { CadastraCandidatoComponent } from './components/cadastra-candidato/cadastra-candidato.component';
import { CadastraTecnologiaComponent } from './components/cadastra-tecnologia/cadastra-tecnologia.component';
import { CadastraProcessoComponent } from './components/cadastra-processo/cadastra-processo.component';
import { ListaTriagemComponent } from './components/lista-triagem/lista-triagem.component';
import { CadastraTriagemComponent } from './components/cadastra-triagem/cadastra-triagem.component';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        ListaTecnologiaComponent,
        ListaCandidatoComponent,
        ListaProcessoComponent,
        CadastraCandidatoComponent,
        CadastraTecnologiaComponent,
        CadastraProcessoComponent,
        CadastraTriagemComponent,
        ListaTriagemComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'lista-tecnologia', component: ListaTecnologiaComponent },
            { path: 'lista-candidato', component: ListaCandidatoComponent },
            { path: 'lista-processo', component: ListaProcessoComponent },
            { path: 'lista-triagem', component: ListaTriagemComponent },
            { path: 'cadastra-candidato', component: CadastraCandidatoComponent },
            { path: 'cadastra-candidato/:id', component: CadastraCandidatoComponent },
            { path: 'cadastra-tecnologia', component: CadastraTecnologiaComponent },
            { path: 'cadastra-tecnologia/:id', component: CadastraTecnologiaComponent },
            { path: 'cadastra-processo', component: CadastraProcessoComponent },
            { path: 'cadastra-processo/:id', component: CadastraProcessoComponent },
            
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
