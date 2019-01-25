import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatCheckboxModule,
  MatFormFieldModule,
  MatOptionModule,
  MatSliderModule,
  MatInputModule,
  MatCardModule,
  MatSelectModule,
  MatDatepickerModule,
  MatNativeDateModule, MatProgressSpinnerModule, MatTabsModule, MatTableModule, MatListModule
} from '@angular/material';


import { AppComponent } from './app.component';
import { PetListComponent } from '../pet-list/pet-list.component';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import {PetService} from "../services/pet.service";
import { NewPetComponent } from '../new-pet/new-pet.component';

@NgModule({
  declarations: [
    AppComponent,
    PetListComponent,
    NewPetComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    BrowserAnimationsModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatOptionModule,
    MatSliderModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatProgressSpinnerModule,
    MatTabsModule,
    MatTableModule,
    MatListModule,

    BrowserModule
  ],
  providers: [ PetService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
