import { Component, OnInit } from '@angular/core';
import * as Highcharts from 'highcharts';
import { SelectList } from '../_model';
import { TimeSeriesService } from '../_service';
declare var require: any;
const More = require('highcharts/highcharts-more');
More(Highcharts);

const Exporting = require('highcharts/modules/exporting');
Exporting(Highcharts);

const ExportData = require('highcharts/modules/export-data');
ExportData(Highcharts);

const Accessibility = require('highcharts/modules/accessibility');
Accessibility(Highcharts);
@Component({
  selector: 'app-time-series',
  templateUrl: './time-series.component.html',
  styleUrls: ['./time-series.component.css']
})
export class TimeSeriesComponent implements OnInit {

  public reportData:any=[];  

  buildingList?: SelectList[];
  objectList?: SelectList[];
  dataFieldList?: SelectList[];
  dataFieldId:number=0;
  objectId:number=0;
  buildingId:number=0;
  timeStamp?: string;
 constructor(private timeSeriesService: TimeSeriesService){}

 ngOnInit(): void {
   this.getData();

 }

 getData(){
   this.timeSeriesService.getTimeSeriesChart().subscribe(res=>{
     this.buildingList=res.buildingSelectList; 
     this.objectList=res.objectsSelectList; 
     this.dataFieldList=res.dataFieldSelectList; 
   }, error => {
         console.log(error);
       });
   }
   getDataTest(n:number) {
    var arr = [],
      i,
      x,
      a=0,
      b=0,
      c=0,
      spike;
    for (
      i = 0, x = Date.UTC(new Date().getUTCFullYear(), 0, 1) - n * 36e5; i < n; i = i + 1, x = x + 36e5
    ) {
      if (i % 100 === 0) {
        a = 2 * Math.random();
      }
      if (i % 1000 === 0) {
        b = 2 * Math.random();
      }
      if (i % 10000 === 0) {
        c = 2 * Math.random();
      }
      if (i % 50000 === 0) {
        spike = 10;
      } else {
        spike = 0;
      }
      arr.push([
        x,
        2 * Math.sin(i / 100) + a + b + c + spike + Math.random()
      ]);
    }
    console.log(arr);
    return arr;
  }
   getSearchRestult(){
    

       this.timeSeriesService.getTimeSeriesChartData(this.dataFieldId,this.objectId,this.dataFieldId,this.timeStamp!).subscribe(res=>{
        this.reportData= res;
        var arr = [];
        for (var item of this.reportData) {
          arr.push([
            item.text,
            item.value
          ]);
          
        }
        
console.log(arr);
        let options: any = {
           chart: {
              zoomType: 'x'
           },
           title: {
               text: 'Timeseries Data'
           },
           subtitle: {
               text: document.ontouchstart === undefined ?
                   'Drag in the plot area to zoom in' : 'Pinch the chart to zoom in'
           },
           xAxis: {
               type: 'string'
           },
           yAxis: {
               title: {
                   text: 'Value'
               }
           },
           legend: {
               enabled: false
           },
           plotOptions: {
                       area: {
                           fillColor: {
                               linearGradient: {
                                   x1: 0,
                                   y1: 0,
                                   x2: 0,
                                   y2: 1
                               },
                               stops: [ ]
                           },
                           marker: {
                               radius: 2
                           },
                           lineWidth: 1,
                           states: {
                               hover: {
                                   lineWidth: 1
                               }
                           },
                           threshold: null
                       }
                   },
           series: [{
                       type: 'area',
                       name: 'Value',
                        data: arr
                   }]
         }
         Highcharts.chart('container', options);       
       }, error => {
         console.log(error);
       });

    
   }

   
}
