import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReportData, TimeSeries } from '../_model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimeSeriesService {

  baseUrl = 'http://localhost:5165/api/';
  constructor(private http: HttpClient) {}

  getTimeSeriesChart(){
    return this.http.get<TimeSeries>(this.baseUrl + 'timeSeries/get-time-series');
  }

  getTimeSeriesChartData(buildingId:number,objectId:number,datafildId:number,timeStamp:string){
    return this.http.get<ReportData>(this.baseUrl + 'timeSeries/get-time-series-chart-data?buildingId='+buildingId+"&objectId="+objectId+"&datafildId="+datafildId+"&timeStamp="+timeStamp);
  }
}
