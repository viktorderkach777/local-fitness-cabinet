import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoadPhotoComponent } from './load-photo/load-photo.component';
import { PersonComponent } from './person/person.component';
import { AppRoutingModule } from './app-routing/app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatButtonModule, MatMenuModule, MatDatepickerModule } from '@angular/material';
import { MatNativeDateModule, MatIconModule, MatCardModule } from '@angular/material';
import { MatSidenavModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { MatTooltipModule, MatToolbarModule } from '@angular/material';
import { MatPaginatorModule } from '@angular/material/paginator';

import { PersonService } from './person.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoadPhotoComponent,
    PersonComponent   
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatPaginatorModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'load-photo', component: LoadPhotoComponent },
    ]),
    AppRoutingModule
  ],
  providers: [
    HttpClientModule,
    PersonService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
