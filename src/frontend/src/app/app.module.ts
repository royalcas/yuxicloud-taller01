import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ValueFormComponent } from './value-form/value-form.component';
import { CreateValueComponent } from './create-value/create-value.component';
import { UpdateValueComponent } from './update-value/update-value.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    ValueFormComponent,
    CreateValueComponent,
    UpdateValueComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    SharedModule,
    CoreModule
  ],
  entryComponents: [CreateValueComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
