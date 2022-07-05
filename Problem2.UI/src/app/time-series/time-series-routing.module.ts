import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TimeSeriesComponent } from './time-series.component';

const routes: Routes = [{ path: '', component: TimeSeriesComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimeSeriesRoutingModule { }
