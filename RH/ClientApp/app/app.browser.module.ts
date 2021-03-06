import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { CandidatoService } from './service/candidato.service';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import 'rxjs/add/operator/map';
import { ProcessoService } from './service/processo.service';
import { TecnologiaService } from './service/tecnologia.service';
import { TriagemService } from './service/triagem.service';


@NgModule({
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppModuleShared,
        HttpModule,
        FormsModule,
    ],
    providers: [
        CandidatoService, ProcessoService, TecnologiaService, TriagemService, { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
