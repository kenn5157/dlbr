import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { FormsModule} from "@angular/forms";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule} from "@angular/material/input";
import { DashboardComponent } from './dashboard/dashboard.component';
import { AppRoutingModule } from './app-routing.module';
import { JobsComponent } from './jobs/jobs.component';
import { FieldDetailComponent } from './field-detail/field-detail.component';
import { FieldsComponent } from './assets/fields/fields.component';
import { HttpClientModule } from '@angular/common/http';
import { FieldsFormComponent } from './assets/fields-form/fields-form.component';
import { MessagesComponent } from './assets/messages/messages.component';
import { MyFieldsComponent } from './assets/fields/my-fields/my-fields.component';
import { FormComponent } from './assets/fields/form/form.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    JobsComponent,
    FieldDetailComponent,
    FieldsComponent,
    FieldsFormComponent,
    MessagesComponent,
    MyFieldsComponent,
    FormComponent
  ],
    imports: [
        BrowserModule,
        FormsModule,
        BrowserAnimationsModule,
        MatInputModule,
        AppRoutingModule,
        HttpClientModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
