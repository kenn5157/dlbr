import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FieldsComponent } from './assets/fields/fields.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { JobsComponent } from './jobs/jobs.component';

const routes: Routes = [
  { path: `field`, component: FieldsComponent },
  { path: `jobs`, component: JobsComponent },
  { path: `home`, component: DashboardComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
