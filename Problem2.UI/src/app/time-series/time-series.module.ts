import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TimeSeriesRoutingModule } from './time-series-routing.module';
import { TimeSeriesComponent } from './time-series.component';


@NgModule({
  declarations: [
    TimeSeriesComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    TimeSeriesRoutingModule,
  ]
})
export class TimeSeriesModule { }
